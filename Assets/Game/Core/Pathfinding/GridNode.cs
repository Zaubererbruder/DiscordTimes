using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Game.Core.Pathfinding
{
    public class GridNode : INode
    {
        private float _terrainCost;
        private float _tempCost = 0;
        private Vector2Int _gridPosition;
        private GridGraph _graph;
        private bool _obstacle;

        public GridNode(GridGraph graph, int xPos, int yPos, float cost)
        {
            _graph = graph;
            _gridPosition = new Vector2Int(xPos, yPos);
            _terrainCost = cost;
        }

        public int X => _gridPosition.x;
        public int Y => _gridPosition.y;

        public Vector2Int GridPosition => _gridPosition;

        public float Cost => _terrainCost + _tempCost;
        public float TerrainCost => _terrainCost;

        public float TempCost { get => _tempCost; set => _tempCost = value; }
        public bool Obstacle { get => _obstacle; set => _obstacle = value; }

        public IEnumerable<INodeLink> Links => (IEnumerable<INodeLink>)(from neighbour in _graph.Neighbours(this)
                                                                        where neighbour is GridNode
                                                                        select new GridLink(this, neighbour as GridNode, (neighbour as GridNode).Cost));
        
    }
}
