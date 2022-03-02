using Assets.Core.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Models
{
    public class Army
    {
        Dictionary<RowType, FieldRow> rows;
        public Army()
        {
            rows = new Dictionary<RowType, FieldRow>();
            rows.Add(RowType.Melee, new FieldRow());
            rows.Add(RowType.Ranged, new FieldRow());
            rows.Add(RowType.Back, new FieldRow());
        }

        public UnitCell GetUnitCell(RowType rowType, int cellnumber)
        {
            return rows[rowType].GetUnitCell(cellnumber);
        }

        public void AddUnitToCell(RowType rowType, int cellnumber, Unit unit)
        {
            rows[rowType].AddUnitToCell(cellnumber, unit);
        }
    }

    internal class FieldRow
    {
        private UnitCell[] _unitCells = new UnitCell[4] { new UnitCell(), new UnitCell(), new UnitCell(), new UnitCell() };

        public UnitCell GetUnitCell(int cellnumber)
        {
            return _unitCells[cellnumber];
        }

        public void AddUnitToCell(int cellnumber, Unit unit)
        {
            _unitCells[cellnumber].AddUnit(unit);
        }
    }

    public enum RowType
    {
        Melee,
        Ranged,
        Back
    }
}
