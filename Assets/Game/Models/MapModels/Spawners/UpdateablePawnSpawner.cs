using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.Spawners
{
    public class UpdateablePawnSpawner<TPawn> : PawnSpawner<TPawn>, IUpdateableModel where TPawn:Pawn, new()
    {
        public UpdateablePawnSpawner(LevelMap map, int x, int y) : base(map, x, y)
        {

        }

        public virtual bool SpawnNeeded(float deltaTime)
        {
            return false;
        }

        public virtual void Update(float deltaTime)
        {
            if (SpawnNeeded(deltaTime))
            {
                Spawn();
            }
        }
    }
}
