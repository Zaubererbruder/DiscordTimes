using Assets.Game.Models.MapModels.PawnModels.AIMovementActions;
using Assets.Game.Models.MapModels.PawnModels.AIMovementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels
{
    public class AIMovement : PawnComponent
    {
        private PawnPathMovement _pathMovement;
        private List<AIMovementRule> _rules = new List<AIMovementRule>();
        private AIMovementAction _currentAction;

        public AIMovement()
        {
            
        }

        public List<AIMovementRule> Rules => _rules;

        internal override void Init()
        {
            _pathMovement = GetComponent<PawnPathMovement>();
            base.Init();
        }

        internal override void Update(float deltaTime)
        {
            if (_currentAction != null)
            {
                if (_currentAction.ActionFinished())
                    _currentAction = null;
                return;
            }

            foreach (var rule in _rules)
            {
                if (rule.ConditionFulfilled())
                {
                    _currentAction = rule.MovementAction;
                    _currentAction.GetAction(_pathMovement).Invoke();
                    break;
                }
            }
        }
    }
}
