using Assets.Game.Core.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class LevelData
    {
        public LevelData(MapData mapData)
        {
            Gametime = new GameTime();
            MapData = mapData;
        }

        public GameTime Gametime { get; private set; }
        public MapData MapData { get; private set; }
    }
}
