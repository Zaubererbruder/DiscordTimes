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

        public Player(LevelMap map, int x, int y)
        {
            _map = map;
            _pathfinding = new AStarGridPathfinding(_map.Graph);
            _x = x;
            _y = y;
        }

        public event Action<GridPath> PathUpdated;

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

            if (PathExist(endNode))
            { //Move

            }
            else
            {
                _path = _pathfinding.Search(startNode, endNode);
                PathUpdated?.Invoke(_path);
            }            
        }

        
    }
}
