using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    internal class PawnMovement
    {
        private int _x, _y;
        private GridPath _path;
        private LevelMap _map;
        private GridNode _currentNode;
        private float _movementProgress;
        private float _movementCost;

        private float _costMultiplier = 1;

        public PawnMovement(LevelMap map, int x, int y)
        {
            _map = map;
            _x = x;
            _y = y;
        }

        internal int X => _x;
        internal int Y => _y;
        internal GridPath Path => _path;

        internal event Action PositionUpdated;
        internal event Action PathUpdated;

        private void SetNextNode()
        {
            _currentNode = _path.Dequeue();
            _x = _currentNode.X;
            _y = _currentNode.Y;
            PositionUpdated?.Invoke();
            _movementProgress = 0;
            PathUpdated?.Invoke();
            if (_path.Count == 0)
            {
                _path = null;
                return;
            }

            _movementCost = _map.Graph.Cost(_currentNode, _path.NextNode) * _costMultiplier;
        }

        /// <summary>
        /// Sets speed
        /// </summary>
        /// <param name="speed">1 speed = 1 cell with 1 cost for 1 second</param>
        internal void SetSpeed(float speed)
        {
            if (speed == 0)
                throw new ArgumentException("Speed cant be 0", nameof(speed));

            _costMultiplier = 1 / speed;
        }

        internal bool PathSetted(GridPath path)
        {
            if (_path == null)
                return false;

            return _path.Equals(path);
        }

        internal void SetPath(GridPath path)
        {
            if (path.NextNode.X != _x || path.NextNode.Y != _y)
                throw new ArgumentException("Wrong path. Path must be start from pawn position", nameof(path));

            _path = path;
            SetNextNode();
        }

        internal void Update(float deltaTime)
        {
            if (_path == null)
                return;

            _movementProgress += deltaTime;
            if(_movementProgress>=_movementCost)
            {
                SetNextNode();
            }
        }     
    }
}
