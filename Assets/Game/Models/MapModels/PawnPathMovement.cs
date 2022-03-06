using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class PawnPathMovement : PawnComponent
    {
        private PawnTransform _transform;
        private AStarGridPathfinding _pathfinding;
        private GridPath _path;
        private GridNode _currentNode;
        private float _movementProgress;
        private float _movementCost;

        private float _costMultiplier = 1;

        public PawnPathMovement()
        {
            
        }

        public override void Init()
        {
            _transform = GetComponent<PawnTransform>();
            if (_transform == null)
                throw new InvalidOperationException("PawnMovement Component needs also PawnTransform Component");

            _pathfinding = new AStarGridPathfinding(_transform.Graph);
            _currentNode = _transform.CurrentNode;
            _currentNode.TempCost = 99;
            base.Init();
        }

        internal GridPath Path => _path;

        public event Action<GridPath> PathUpdated;

        private void SetNextNode()
        {
            _currentNode.TempCost = 0;
            _currentNode = _path.Dequeue();
            _currentNode.TempCost = 99;
            _transform.X = _currentNode.X;
            _transform.Y = _currentNode.Y;
            _movementProgress = 0;
            PathUpdated?.Invoke(_path);
            if (_path.Count == 0)
            {
                _path = null;
                return;
            }

            _movementCost = _transform.Graph.TerrainCost(_currentNode, _path.NextNode) * _costMultiplier;
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

        public void GeneratePath(int x, int y)
        {
            var startNode = _transform.CurrentNode;
            var endNode = _transform.Graph[x, y];

            if (endNode == null)
                return;

            if (startNode == endNode)
                return;

            var path = _pathfinding.Search(startNode, endNode);
            SetPath(path);
        }

        internal void SetPath(GridPath path)
        {
            if (path.NextNode.X != _transform.X || path.NextNode.Y != _transform.Y)
                throw new ArgumentException("Wrong path. Path must be start from pawn position", nameof(path));

            _path = path;
            SetNextNode();
        }

        internal override void Update(float deltaTime)
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
