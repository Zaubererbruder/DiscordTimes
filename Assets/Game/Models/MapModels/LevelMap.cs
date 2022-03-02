using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class LevelMap
    {
        private MapCell[,] _map;
        private GridGraph _graph;

        public MapCell this[int x, int y]
        {
            get { return _map[x, y]; }
            set { _map[x, y] = value; }
        }

        public GridGraph Graph => _graph;

        public LevelMap(MapCell[,] map)
        {
            _map = map;
            _graph = new GridGraph(_map.GetLength(0), _map.GetLength(1));
            foreach(var mapCell in _map)
            {
                if (mapCell == null)
                    continue;

                _graph.AddNode(mapCell.X, mapCell.Y, mapCell.Cost);
            }
        }

        public Player CreatePlayer(int x, int y)
        {
            var player = new Player(this, x, y);
            //TODO Check mapcell accessibility
            return player;
        }

        //public GridNode NodeFromWorldPoint(Vector3 worldPosition)
        //{
        //    int x = Mathf.FloorToInt(worldPosition.x + (_map.GetLength(0) / 2));
        //    int y = Mathf.FloorToInt(worldPosition.y + (_map.GetLength(1) / 2));
        //    return _graph[x, y];
        //}
    }
}
