using Assets.Game.Core.Pathfinding;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Game.Core.Presenters
{
    public class PathPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _pathObj;
        [SerializeField] private Transform _parentForPathObjs;

        private Grid2D _grid;
        private List<GameObject> _pointsObjects = new List<GameObject>();

        private Pawn _player;

        [Inject]
        public void Construct(Grid2D grid)
        {
            _grid = grid;
        }

        public void Init(Pawn player)
        {
            _player = player;
        }

        private void ClearExistedPath()
        {
            foreach(var obj in _pointsObjects)
            {
                Destroy(obj);
            }
            _pointsObjects.Clear();
        }

        //public void UpdatePath(GridPath path)
        //{
        //    //ClearExistedPath();

        //    //foreach (var node in path.PathNodes)
        //    //{
        //    //    var obj = Instantiate(_pathObj, _grid.WorldPointFromGridPosition(node.GridPosition), Quaternion.identity, _parentForPathObjs);
        //    //    _pointsObjects.Add(obj);
        //    //}

        //}
    }
}
