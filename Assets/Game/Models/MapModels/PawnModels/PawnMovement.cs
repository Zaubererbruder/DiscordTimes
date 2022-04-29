using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels
{
    public class PawnMovement
    {
        private Position _destination;
        private bool _destinationSetted;
        private float _timeCost;
        private float _progress;

        private bool MovingActive => _destinationSetted;

        public event Action MovementEnded;

        internal void Update(float deltatime)
        {
            if (!MovingActive)
                return;

            if(_progress>_timeCost)
            {
                _progress = 0;
                _timeCost = 0;
                _destinationSetted = false;
                MovementEnded?.Invoke();
            }


            _progress += deltatime;
        }

        internal void SetDestination(Position pos, float timecost)
        {
            _destination = pos;
            _timeCost = timecost;
            _destinationSetted = true;
        }
    }
}
