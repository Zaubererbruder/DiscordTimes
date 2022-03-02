using Assets.Core.Models.Units.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core.Units
{
    public class UnitTemplates
    {
        public static MeleeUnit Soldier(Texture2D texture)
        {
            var unit = new MeleeUnit(texture);
            unit.Name = "Soldier";
            UnitCharacteristics unitCharacteristics = new UnitCharacteristics();
            unitCharacteristics._maxHealth = 50;
            unitCharacteristics._health = 50;
            unitCharacteristics._initiative = 10;
            unitCharacteristics._damageValues.Add(new DamageCharacteristic(DamageType.Physical, 10));
            unit.UnitCharacteristics = unitCharacteristics;
            return unit;
        }
    }

}
