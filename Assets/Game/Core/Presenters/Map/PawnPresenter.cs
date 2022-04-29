using Assets.Game.Models.MapModels.PawnModels;
using UnityEngine;
using Zenject;

namespace Assets.Game.Core.Presenters.Map
{
    public class PawnPresenter : ModelPresenter<Pawn>
    {
        private Transform _transform;
        private Grid2D _grid;

        private void Awake()
        {
            _transform = transform;
        }

        [Inject]
        public void Construct(Grid2D grid)
        {
            _grid = grid;
        }

        private void Update()
        {
            if (_grid == null) 
                return;

            _transform.position = _grid.WorldPointFromGridPosition(new Vector2Int(Model.X, Model.Y));
        }
    }
}
