using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class MapCell
    {
        private int _gridX, _gridY;
        private float _cost;

        public MapCell(int x, int y, float cost)
        {
            _gridX = x;
            _gridY = y;
            _cost = cost;
        }

        public int X => _gridX;
        public int Y => _gridY;
        public float Cost => _cost;
    }
}
