using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public abstract class PawnSpawner<TPawn> where TPawn : Pawn, new()
    {
        protected LevelMap _map;
        protected int _x, _y;

        public PawnSpawner(LevelMap map, int x, int y)
        {
            _map = map;
            _x = x;
            _y = y;
        }

        public event Action<TPawn> PawnSpawned;

        protected virtual void Spawn()
        {
            TPawn pawn = new TPawn();
            pawn.SetMap(_map, _x, _y);
            _map.AddPawnToMap(pawn);
            PawnSpawned?.Invoke(pawn);
        }
    }
}
