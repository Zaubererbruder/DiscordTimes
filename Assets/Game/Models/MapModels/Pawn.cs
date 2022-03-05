using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public abstract class Pawn
    {
        private LevelMap _map;
        private AStarGridPathfinding _pathfinding;
        private PawnMovement _movement;

        public Pawn()
        {
            
        }

        public void SetMap(LevelMap map, int x, int y)
        {
            _map = map;
            _movement = new PawnMovement(map, x, y);
            _movement.PositionUpdated += () => PositionUpdated?.Invoke(X, Y);
            _movement.PathUpdated += () => PathUpdated?.Invoke(_movement.Path);
            _movement.SetSpeed(5);
            _pathfinding = new AStarGridPathfinding(_map.Graph);
        }

        public event Action<GridPath> PathUpdated;
        public event Action<int, int> PositionUpdated;

        public int X => _movement.X;
        public int Y => _movement.Y;

        public void SetPath(int x, int y)
        {
            var startNode = _map.Graph[X, Y];
            var endNode = _map.Graph[x, y];
            if (endNode == null)
                return;

            if (startNode == endNode)
                return;

            var path = _pathfinding.Search(startNode, endNode);
            _movement.SetPath(path);
        }


        internal void Update(float deltatime)
        {
            _movement?.Update(deltatime);
        }
    }
}
