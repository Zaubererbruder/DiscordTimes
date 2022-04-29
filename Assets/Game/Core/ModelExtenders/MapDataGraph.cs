using Assets.Game.AstarPathfinding;
using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;

namespace Assets.Game.Core.ModelExtenders
{
    public class MapDataGraph : MapData, IGridGraph<MapCellNode>
    {
        private const float DIAG_MOVEMENT_RATE = 1.5f;

        public MapDataGraph(MapCellNode[,] map) : base(map)
        {

        }


        public float Cost(MapCellNode startNode, MapCellNode endNode)
        {
            if (DiagonalNodes(startNode, endNode))
                return startNode.Cost * DIAG_MOVEMENT_RATE;

            return endNode.Cost;

            bool DiagonalNodes(MapCell first, MapCell second)
            {
                if (Math.Min(first.X, second.X) + 1 == Math.Max(first.X, second.X) &&
                        Math.Min(first.Y, second.Y) + 1 == Math.Max(first.Y, second.Y))
                    return true;

                return false;
            }
        }

        public float GCost(GridPath<MapCellNode> path)
        {
            var cost = 0f;
            MapCellNode lastNode = null;
            foreach (var node in path.Nodes)
            {
                if (lastNode == null)
                {
                    lastNode = node;
                    continue;
                }

                cost += Cost(lastNode, node);
                lastNode = node;
            }
            return cost;
        }

        public MapCellNode GetNode(int x, int y)
        {
            return (MapCellNode)Map[x, y];
        }

        public float Heuristic(MapCellNode startNode, MapCellNode endNode)
        {
            var xAbs = MathF.Abs(startNode.X - endNode.X);
            var yAbs = MathF.Abs(startNode.Y - endNode.Y);
            var minAbs = MathF.Min(xAbs, yAbs);
            return minAbs * DIAG_MOVEMENT_RATE + MathF.Abs(xAbs - yAbs);
        }

        public IEnumerable<MapCellNode> Neighbours(MapCellNode node)
        {
            int mapXLength = Map.GetLength(0);
            int mapYLength = Map.GetLength(1);

            int xLeft = node.X == 0 ? 0 : -1;
            int xRight = node.X == mapXLength ? 0 : 1;
            int yBottom = node.Y == 0 ? 0 : -1;
            int yTop = node.Y == mapYLength ? 0 : 1;

            for (int x = xLeft; x <= xRight; x++)
            {
                for (int y = yBottom; y <= yTop; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    if (Map[x, y] == null)
                        continue;

                    yield return (MapCellNode)Map[x, y];
                }
            }
        }
    }
}
