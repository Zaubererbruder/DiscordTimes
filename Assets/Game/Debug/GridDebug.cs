using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Debug
{
    internal class GridDebug
    {
        private LevelMap _map;

        public GridDebug(LevelMap map)
        {
            _map = map;
        }

        public void OnGUI()
        {

        }
    }
}
