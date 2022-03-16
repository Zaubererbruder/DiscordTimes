using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels.PawnModels.AIMovementActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementRules
{
    public class WhenTimeAIMovementRule : AIMovementRule
    {
        private GameTime _gametime;
        private Func<GameTime, bool> _condition;
        private AIMovementAction _action;

        public WhenTimeAIMovementRule(GameTime gameTime, Func<GameTime, bool> condition, AIMovementAction action)
        {
            _gametime = gameTime;
            _condition = condition;
            _action = action;
        }

        public override bool ConditionFulfilled()
        {
            return _condition(_gametime);
        }

        public override AIMovementAction MovementAction => _action;

        public override bool Finished()
        {
            return _action.ActionFinished();
        }
    }
}
