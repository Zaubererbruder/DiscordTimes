using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Core.Presenters.Map
{
    public class PawnPresenter : MonoBehaviour
    {
        private Pawn _player;
        private PawnTransform _pawnTransform;
        private Transform _transform;
        private Grid2D _grid;

        private void Awake()
        {
            _transform = transform;
        }

        public PawnPresenter Init(Grid2D grid, Pawn player)
        {
            _grid = grid;
            _player = player;
            _pawnTransform = player.GetComponent<PawnTransform>();
            return this;
        }

        private void Update()
        {
            _transform.position = _grid.WorldPointFromGridPosition(new Vector2Int(_pawnTransform.X, _pawnTransform.Y));
        }
    }
}
