using Assets.Core.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core.Presenters
{
    public class BattlePresenter : MonoBehaviour
    {
        [SerializeField] private ArmyPresenter _playerArmy;
        [SerializeField] private ArmyPresenter _enemyArmy;

        private Battle _battle;

        public void Init(Battle battle)
        {
            _battle = battle;
            _playerArmy.Init(_battle.AttackersArmy);
            _enemyArmy.Init(_battle.DefendersArmy);
        }

        private void Awake()
        {
            
            
        }
    }
}
