using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementActions
{
    public abstract class AIMovementAction
    {
        public abstract bool ActionFinished();
        public abstract Action GetAction(PawnPathMovement movementComp);
    }
}
