using Assets.Core.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core.Units
{
    public class MeleeUnit : Unit
    {
        Texture2D _texture;

        public Texture2D Texture => _texture;

        public MeleeUnit(Texture2D texture)
        {
            _texture = texture;
        }
    }
}
