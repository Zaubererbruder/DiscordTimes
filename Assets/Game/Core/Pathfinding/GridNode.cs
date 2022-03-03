using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Game.Core.Pathfinding
{
    public class GridNode : INode
    {
        private float _cost;
        private Vector2Int _gridPosition;
        private GridGraph _graph;


        public GridNode(GridGraph graph, int xPos, int yPos, float cost)
        {
            _graph = graph;
            _gridPosition = new Vector2Int(xPos, yPos);
            _cost = cost;
        }

        public int X => _gridPosition.x;
        public int Y => _gridPosition.y;

        public Vector2Int GridPosition => _gridPosition;

        public float Cost => _cost;

        public IEnumerable<INodeLink> Links => (IEnumerable<INodeLink>)(from neighbour in _graph.Neighbours(this)
                                                                        where neighbour is GridNode
                                                                        select new GridLink(this, neighbour as GridNode, (neighbour as GridNode).Cost));
    }
}
