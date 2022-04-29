using Assets.Game.AstarPathfinding;
//using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class MapData 
    {
        public MapData(MapCell[,] map)
        {
            Map = map;

            var width = Map.GetLength(0);
            var height = Map.GetLength(1);
        }
        public MapCell[,] Map { get; private set; }
    }
}
