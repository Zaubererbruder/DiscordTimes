using Assets.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core.Presenters
{
    public class ArmyPresenter : MonoBehaviour
    {
        [SerializeField] private List<UnitCellPresenter> _meleeRowCellsPresenters;
        [SerializeField] private List<UnitCellPresenter> _rangedRowCellsPresenters;
        [SerializeField] private List<UnitCellPresenter> _backRowCellsPresenters;

        private Army _army;

        public void Init(Army army)
        {
            _army = army;
            for (int i = 0; i < _meleeRowCellsPresenters.Count; i++)
            {
                _meleeRowCellsPresenters[i].Init(_army.GetUnitCell(RowType.Melee, i));
            }
            for (int i = 0; i < _rangedRowCellsPresenters.Count; i++)
            {
                _rangedRowCellsPresenters[i].Init(_army.GetUnitCell(RowType.Ranged, i));
            }
            for (int i = 0; i < _backRowCellsPresenters.Count; i++)
            {
                _backRowCellsPresenters[i].Init(_army.GetUnitCell(RowType.Back, i));
            }
        }
    }
}
