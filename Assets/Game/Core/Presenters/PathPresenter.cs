using Assets.Game.Core.Pathfinding;
using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Core.Presenters
{
    public class PathPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _pathObj;
        [SerializeField] private Transform _parentForPathObjs;

        private Grid2D _grid;
        private List<GameObject> _pointsObjects = new List<GameObject>();
        private PawnPathMovement _pawnMovement;

        private Pawn _player;
        public void OnEnable()
        {
            if (_pawnMovement == null)
                return;

            _pawnMovement.PathUpdated += OnPathUpdateHandler;
        }

        public void OnDisable()
        {
            if (_pawnMovement == null)
                return;

            _pawnMovement.PathUpdated -= OnPathUpdateHandler;
        }

        public PathPresenter Init(Grid2D grid, Pawn player)
        {
            _grid = grid;
            _player = player;
            _pawnMovement = player.GetComponent<PawnPathMovement>();

            if (enabled)
                OnEnable();

            return this;
        }


        private void OnPathUpdateHandler(GridPath path)
        {
            UpdatePath(path);
        }

        private void ClearExistedPath()
        {
            foreach(var obj in _pointsObjects)
            {
                Destroy(obj);
            }
            _pointsObjects.Clear();
        }

        public void UpdatePath(GridPath path)
        {
            ClearExistedPath();

            foreach (var node in path.PathNodes)
            {
                var obj = Instantiate(_pathObj, _grid.WorldPointFromGridPosition(node.GridPosition), Quaternion.identity, _parentForPathObjs);
                _pointsObjects.Add(obj);
            }

        }
    }
}
