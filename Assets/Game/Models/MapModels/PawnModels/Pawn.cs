using System;
using System.Collections.Generic;

namespace Assets.Game.Models.MapModels.PawnModels
{
    public class Pawn
    {
        private int _teamNumber;
        private bool _isPlayerControlled;
        private PawnMovement _movement;

        public Pawn(int x, int y, int team)
        {
            X = x;
            Y = y;
            _teamNumber = team;
            _isPlayerControlled = _teamNumber == 0;
            _movement = new PawnMovement();
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsPlayerControlled => _isPlayerControlled;
        public int Team => _teamNumber;

        public void Update(float deltatime)
        {
            _movement.Update(deltatime);
        }

        public void SetMovementDestination(Position goal, float timecost)
        {
            _movement.SetDestination(goal, timecost);
        }
    }
}
