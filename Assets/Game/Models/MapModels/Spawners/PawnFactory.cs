using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.Spawners
{
    public class PawnFactory : IPawnFactory
    {
        public PawnFactory()
        {

        }

        public Pawn Create(int x, int y, int teamNumber)
        {
            var pawn = new Pawn(x,y,teamNumber);

            return pawn;
        }


    }
}
