using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public class AStarGridPathfinding : AStarPathfinding<GridGraph, GridNode, GridPath>
    {
        public AStarGridPathfinding(GridGraph graph) : base (graph)
        {

        }

        public override float GCost(GridPath path)
        {
            var cost = 0f;
            GridNode lastNode = null;
            foreach (var node in path.PathNodes)
            {
                if (lastNode == null)
                {
                    lastNode = node;
                    continue;
                }

                cost += Graph.Cost(lastNode, node);
                lastNode = node;
            }
            return cost;
        }

        public override float Heuristic(GridNode a, GridNode b)
        {
            var xAbs = MathF.Abs(a.GridPosition.x - b.GridPosition.x);
            var yAbs = MathF.Abs(a.GridPosition.y - b.GridPosition.y);
            var minAbs = MathF.Min(xAbs, yAbs);
            return minAbs*Graph.DiagMovementRate + MathF.Abs(xAbs-yAbs);
        }

        public override GridPath Search(GridNode start, GridNode goal)
        {
            return base.Search(start, goal);
        }
    }
}
