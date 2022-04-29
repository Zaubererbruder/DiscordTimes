using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Core.OnMap
{
    [Serializable]
    public class Grid2DSize
    {
        [SerializeField] private float _nodeRadius;
        [SerializeField] private Vector2Int _gridWorldSize;

        public Grid2DSize()
        { 
            
        }

        public float NodeRadius => _nodeRadius;
        public Vector2 GridWorldSize => _gridWorldSize;
        public float NodeDiameter => _nodeRadius * 2;
        public float GridWorldWidth => _gridWorldSize.x / NodeDiameter;
        public float GridWorldHeight => _gridWorldSize.y / NodeDiameter;
        public int GridWidth => _gridWorldSize.x;
        public int GridHeight => _gridWorldSize.y;
        public Vector3 WorldBottomLeft => Vector3.zero - Vector3.right * _gridWorldSize.x / 2 - Vector3.up * _gridWorldSize.y / 2;
    }
}
