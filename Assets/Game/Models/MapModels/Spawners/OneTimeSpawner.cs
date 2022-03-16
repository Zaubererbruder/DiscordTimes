using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class OneTimeSpawner<TPawn> : PawnSpawner<TPawn>, IOnStartableModel where TPawn:Pawn, new()
    {
        public OneTimeSpawner(LevelMap map, int x, int y) : base(map, x, y)
        {

        }

        public void OnStart()
        {
            Spawn();
        }

    }
}
