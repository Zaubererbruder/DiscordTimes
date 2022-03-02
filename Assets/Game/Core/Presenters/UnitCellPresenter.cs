using Assets.Core.Models;
using Assets.Core.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core.Presenters
{
    public class UnitCellPresenter : MonoBehaviour
    {
        private UnitCell _unitCell;
        private Image buttonImage;

        private void Awake()
        {
            buttonImage = GetComponent<Image>();
        }

        public void Init(UnitCell unitCell)
        {
            _unitCell = unitCell;
            var unit = (MeleeUnit)_unitCell.Unit;
            if (unit != null)
            {
                var texture = unit?.Texture;
                buttonImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
    }
}
