using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.Spawners
{
    public interface IPawnFactory
    {
        public Pawn Create();
        public event Action<Pawn> PawnSpawned;
    }
}
