using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Core.Models.Units.Characteristics;

namespace Assets.Core.Models.Units
{
    [Serializable]
    public abstract class Unit
    {
        public UnitCharacteristics UnitCharacteristics;
        public string Name;

    }
}
