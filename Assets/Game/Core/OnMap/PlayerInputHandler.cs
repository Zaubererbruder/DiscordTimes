using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Core.OnMap
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Transform _transform;
        private Grid2D _grid;
        private Pawn _player;
        private PawnPathMovement _pawnMovement;
        private PawnTransform _pawnTransform;
        private LevelMap _map;
        private bool _isMoving = false;
        private Vector2Int _pathEndPos;

        private void Awake()
        {
            _transform = transform;  
        }

        private void OnEnable()
        {
            if (_pawnMovement == null)
                return;

            _pawnMovement.PathUpdated += OnPathEndedHandler;
        }

        private void OnDisable()
        {
            if (_pawnMovement == null)
                return;

            _pawnMovement.PathUpdated -= OnPathEndedHandler;
        }

        private void Start()
        {

        }

        private void Update()
        {
            if(_isMoving)
            {
                _map?.Update(Time.deltaTime);
            }
        }

        public PlayerInputHandler Init(Grid2D grid, Pawn player, LevelMap map)
        {
            _grid = grid;
            _player = player;
            _pawnMovement = _player.GetComponent<PawnPathMovement>();
            _pawnTransform = _player.GetComponent<PawnTransform>();
            _map = map;
            _pathEndPos = new Vector2Int(_pawnTransform.X, _pawnTransform.Y);

            if (enabled)
                OnEnable();

            return this;
        }

        public void OnPathEndedHandler(GridPath path)
        {
            if (path.Count == 0) 
                _isMoving = false;
        }

        public void OnMoveHandler(CallbackContext context)
        {
            if (!context.performed)
                return;

            if (_player == null)
                return;

            var goalPosition = _grid.GridPositionFromWorldPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

            if (goalPosition.x == _pawnTransform.X && goalPosition.y == _pawnTransform.Y)
                return;

            if (goalPosition.x == _pathEndPos.x && goalPosition.y == _pathEndPos.y)
            {
                _isMoving = true;
                Debug.Log($"Player moving started to x:{goalPosition.x}, y:{goalPosition.y}");
            }
            else
            {
                Debug.Log($"Path setted x:{goalPosition.x}, y:{goalPosition.y}");
                _isMoving = false;
                _pawnMovement.GeneratePath(goalPosition.x, goalPosition.y);
            }
            _pathEndPos = goalPosition;
        }

    }
}
