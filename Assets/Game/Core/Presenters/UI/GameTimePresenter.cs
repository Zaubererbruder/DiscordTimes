using Assets.Game.Core.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Game.Core.Presenters.UI
{
    public class GameTimePresenter : UIPresenter
    {
        [SerializeField] private TMP_Text _textComp;
        private GameTime _gameTime;

        private void Start()
        {
            _gameTime = BindField<GameTime>();
            UpdateText();
            _gameTime.TimeChanged += UpdateText;
        }

        private void UpdateText()
        {
            _textComp.text = _gameTime.Time.ToString("dd MMMM yyyy dddd HHч. ");
        }
    }
}
