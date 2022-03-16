using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementRules
{
    public class AIBehaviour : PawnComponent
    {
        private AIBehaviourNode _root;

        public AIBehaviourNode Root => _root;

        internal override void Init()
        {
            _root = new AIBehaviourNode();
        }

    }
}
