using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class PlayerPawnSpawner : OneTimeSpawner<PlayerPawn>
    {
        public PlayerPawnSpawner(LevelMap map, int x, int y) :base(map, x, y)
        {

        }
    }
}
