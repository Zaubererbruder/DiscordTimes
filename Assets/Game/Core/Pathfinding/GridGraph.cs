using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public class GridGraph : IGraph<GridNode>
    {
        private GridNode[,] _grid;
        private float _diagMovementRate = 1;
        private int gridSizeX => _grid.GetLength(0);
        private int gridSizeY => _grid.GetLength(1);

        public float DiagMovementRate => _diagMovementRate;

        public IEnumerable<GridNode> Nodes => from i in Enumerable.Range(0, _grid.GetLength(0))
                                           from j in Enumerable.Range(0, _grid.GetLength(1))
                                           where _grid[i, j] != null
                                           select _grid[i, j];

        public GridGraph(int xLength, int yLength)
        {
            _grid = new GridNode[xLength, yLength];
        }

        public void AddNode(int xPos, int yPos, float cost)
        {
            _grid[xPos, yPos] = new GridNode(this, xPos, yPos, cost);
        }

        public void SetDiagMovementRate(float newRate)
        {
            _diagMovementRate = newRate;
        }

        public GridNode this[int x, int y]
        {
            get { return _grid[x,y]; }
            set { _grid[x, y] = value; } 
        }

        private bool Node2DAccessible(int x, int y)
        {
            if(x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
            {
                return _grid[x, y] != null;
            }
            
            return false;
        }

        private bool DiagonalNodes(GridNode first, GridNode second)
        {
            if (Math.Min(first.GridPosition.x, second.GridPosition.x) + 1 == Math.Max(first.GridPosition.x, second.GridPosition.x) &&
                    Math.Min(first.GridPosition.y, second.GridPosition.y) + 1 == Math.Max(first.GridPosition.y, second.GridPosition.y))
                return true;

            return false;
        }

        public IEnumerable<GridNode> Neighbours(GridNode node)
        {
            var node2d = node as GridNode;
            if (node2d == null)
                yield return null;

            if (Node2DAccessible(node2d.GridPosition.x, node2d.GridPosition.y + 1))
                yield return _grid[node2d.GridPosition.x, node2d.GridPosition.y + 1];

            //checks and adds bottom neighbor
            if (Node2DAccessible(node2d.GridPosition.x, node2d.GridPosition.y - 1))
                yield return _grid[node2d.GridPosition.x, node2d.GridPosition.y - 1];

            //checks and adds right neighbor
            if (Node2DAccessible(node2d.GridPosition.x + 1, node2d.GridPosition.y))
                yield return _grid[node2d.GridPosition.x + 1, node2d.GridPosition.y];

            //checks and adds left neighbor
            if (Node2DAccessible(node2d.GridPosition.x - 1, node2d.GridPosition.y))
                yield return _grid[node2d.GridPosition.x - 1, node2d.GridPosition.y];


            //checks and adds top right neighbor
            if (Node2DAccessible(node2d.GridPosition.x + 1, node2d.GridPosition.y + 1))
                yield return _grid[node2d.GridPosition.x + 1, node2d.GridPosition.y + 1];

            //checks and adds bottom right neighbor
            if (Node2DAccessible(node2d.GridPosition.x + 1, node2d.GridPosition.y - 1))
                yield return _grid[node2d.GridPosition.x + 1, node2d.GridPosition.y - 1];

            //checks and adds top left neighbor
            if (Node2DAccessible(node2d.GridPosition.x - 1, node2d.GridPosition.y + 1))
                yield return _grid[node2d.GridPosition.x - 1, node2d.GridPosition.y + 1];

            //checks and adds bottom left neighbor
            if (Node2DAccessible(node2d.GridPosition.x - 1, node2d.GridPosition.y - 1))
                yield return _grid[node2d.GridPosition.x - 1, node2d.GridPosition.y - 1];
        }

        public float Cost(GridNode first, GridNode second)
        {
            if (DiagonalNodes(first, second))
                return second.Cost * _diagMovementRate;
            
            return second.Cost;
        }
    }
}
