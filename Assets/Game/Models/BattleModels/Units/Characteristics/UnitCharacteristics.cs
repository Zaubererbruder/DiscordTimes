using Assets.Core.Models.Units.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Models.Units.Characteristics
{
    [Serializable]
    public class UnitCharacteristics
    {
        public float _health;
        public float _maxHealth;
        public List<DamageCharacteristic> _damageValues = new List<DamageCharacteristic>();
        public float _initiative;
        

    }

    [Serializable]
    public enum DamageType
    {
        Physical,
        Magical
    }
}
