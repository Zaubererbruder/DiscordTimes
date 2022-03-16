using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementRules
{
    public class AIBehaviourNode
    {
        private List<AIBehaviourNode> _nextNodes = new List<AIBehaviourNode>();

        public AIBehaviourNode()
        {

        }

        public List<AIBehaviourNode> Nodes => _nextNodes;
    }
}
