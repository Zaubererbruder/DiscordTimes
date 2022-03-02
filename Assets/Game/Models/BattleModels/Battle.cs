using System.Collections;
using System.Collections.Generic;

namespace Assets.Core.Models
{
    public class Battle
    {
        private Army _attackersArmy;
        private Army _defendersArmy;

        public Battle(Army attackersArmy, Army defendersArmy)
        {
            _attackersArmy = attackersArmy;
            _defendersArmy = defendersArmy;
        }

        public Army AttackersArmy => _attackersArmy;
        public Army DefendersArmy => _defendersArmy;
        public int TurnCounter = 0;

        public void Start()
        {
            TurnCounter = 1;
        }
    }
}
