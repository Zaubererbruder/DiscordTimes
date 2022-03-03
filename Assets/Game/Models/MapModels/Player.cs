using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class Player
    {
        private int _x, _y;
        private LevelMap _map;
        private AStarGridPathfinding _pathfinding;
        private GridPath _path;
        private GridNode _nextNode;
        private bool _needToEndMove;
        private bool _moves;
        private float _movementProgress;
        private float _movementCost;

        public Player(LevelMap map, int x, int y)
        {
            _map = map;
            _pathfinding = new AStarGridPathfinding(_map.Graph);
            _x = x;
            _y = y;
        }

        public event Action<GridPath> PathUpdated;
        public event Action<int, int> PositionUpdated;

        private bool PathExist(INode endNode)
        {
            return _path != null && _path.EndNode == endNode;
        }

        public int X => _x;
        public int Y => _y;

        public void SetPathOrMove(int x, int y)
        {
            var startNode = _map.Graph[_x, _y];
            var endNode = _map.Graph[x, y];
            if (endNode == null)
                return;

            if (startNode == endNode)
                return;

            if (PathExist(endNode))
            { 
                SetMove(true);
            }
            else
            {
                _moves = false;
                _path = _pathfinding.Search(startNode, endNode);
                PathUpdated?.Invoke(_path);
            }            
        }

        private void SetMove(bool value)
        {
            SetNewNodeToMove();
            _moves = value;
        }

        public void Update(float deltatime)
        {
            if(_needToEndMove || _moves)
            {
                _movementProgress += deltatime;
                _needToEndMove = true;
                if (_movementProgress >= _movementCost)
                {
                    EndMoveToNode();
                    SetNewNodeToMove();
                }
                _map.Update(deltatime);
            }
        }

        private void EndMoveToNode()
        {
            _x = _nextNode.X;
            _y = _nextNode.Y;
            PositionUpdated?.Invoke(_x, _y);

            if (_path.NextNode == _nextNode)
            {
                _path.Dequeue();
                PathUpdated?.Invoke(_path);
            }
            else
            {
                _path = _pathfinding.Search(_nextNode, _path.EndNode);
                PathUpdated?.Invoke(_path);
            }
        }

        private void SetNewNodeToMove()
        {
            _needToEndMove = false;

            if (_path.Count == 0)
            {
                EndMovement();
                return;
            }

            _nextNode = _path.NextNode;
            _movementCost = _map.Graph.Cost(_path.StartNode, _nextNode) / 5;
            _movementProgress = 0;       
        }

        private void EndMovement()
        {
            _needToEndMove = false;
            _moves = false;
            _path = null;
        }
    }
}
