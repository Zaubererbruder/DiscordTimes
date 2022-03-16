using Assets.Game.Models.MapModels.PawnModels.AIMovementActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementRules
{
    public abstract class AIMovementRule
    {
        public abstract bool ConditionFulfilled();
        public abstract bool Finished();

        public abstract AIMovementAction MovementAction { get; }

    }
}
