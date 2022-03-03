using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Core.Presenters.Map
{
    public class PlayerPresenter : MonoBehaviour
    {
        private Player _player;
        private Transform _transform;
        private Grid2D _grid;

        private void Awake()
        {
            _transform = transform;
        }

        public void Init(Grid2D grid, Player player)
        {
            _grid = grid;
            _player = player;
            _player.PositionUpdated += UpdatePosition;
        }

        private void UpdatePosition(int x, int y)
        {
            _transform.position = _grid.WorldPointFromGridPosition(new Vector2Int(_player.X, _player.Y));
        }

        private void Update()
        {

        }
    }
}
