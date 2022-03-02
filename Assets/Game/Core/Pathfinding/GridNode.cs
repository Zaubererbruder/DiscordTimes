using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Game.Core.Pathfinding
{
    public class GridNode : INode
    {
        private float _cost;
        //private bool _obstacle;
        //private Vector3 _worldPosition;
        private Vector2Int _gridPosition;
        private GridGraph _graph;

        //public Vector3 WorldPosition => _worldPosition;
        public Vector2Int GridPosition => _gridPosition;
        //public bool Obstacle => _obstacle;

        public GridNode(GridGraph graph, bool obstacle, Vector3 worldPosition, Vector2Int gridPosition, float cost)
        {
            _graph = graph;
            //_obstacle = obstacle;
            //_worldPosition = worldPosition;
            _gridPosition = gridPosition;
            _cost = cost;
        }

        public GridNode(GridGraph graph, int xPos, int yPos, float cost)
        {
            _graph = graph;
            //_obstacle = obstacle;
            //_worldPosition = worldPosition;
            _gridPosition = new Vector2Int(xPos, yPos);
            _cost = cost;
        }

        public float Cost => _cost;

        public IEnumerable<INodeLink> Links => (IEnumerable<INodeLink>)(from neighbour in _graph.Neighbours(this)
                                                                        where neighbour is GridNode
                                                                        select new GridLink(this, neighbour as GridNode, (neighbour as GridNode).Cost));
    }
}
