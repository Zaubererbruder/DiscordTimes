using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Models.Units.Characteristics
{
    [Serializable]
    public struct DamageCharacteristic
    {
        public DamageType _damageType;
        public float _value;

        public DamageCharacteristic(DamageType type, float damageValue)
        {
            _damageType = type;
            _value = damageValue;
        }
    }
}
