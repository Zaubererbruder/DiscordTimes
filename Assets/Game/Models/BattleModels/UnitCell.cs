using Assets.Core.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Models
{
    public class UnitCell
    {
        private Unit _unit;
        public Unit Unit => _unit;

        public void AddUnit(Unit unit)
        {
            if (_unit != null)
                throw new InvalidOperationException("Неудачная попытка добавить юнита в уже занятую ячейку.");

            _unit = unit;
        }
    }
}
