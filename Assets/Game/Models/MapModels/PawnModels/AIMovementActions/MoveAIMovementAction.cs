using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels.AIMovementActions
{
    public class MoveAIMovementAction : AIMovementAction
    {
        private GridNode _goalNode;
        PawnPathMovement _movementComp;
        PawnTransform _pawnTransform;

        public MoveAIMovementAction(GridNode node)
        {
            _goalNode = node;
        }

        public override bool ActionFinished()
        {
            if (_pawnTransform.CurrentNode == _goalNode)
                return true;

            return false;
        }

        public override Action GetAction(PawnPathMovement movementComp)
        {
            _movementComp = movementComp;
            _pawnTransform = _movementComp.GetComponent<PawnTransform>();
            return () => { movementComp.GeneratePath(_goalNode.X, _goalNode.Y); };
        }
    }
}
