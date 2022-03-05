using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
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
        [SerializeField] private GameObject _pathObj;

        private Transform _transform;
        private Grid2D _grid;
        private PlayerPawn _player;
        private LevelMap _map;
        private bool _isMoving = false;
        private Vector2Int _pathEndPos;

        private void Awake()
        {
            _transform = transform;  
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

        public void Init(Grid2D grid, PlayerPawn player, LevelMap map)
        {
            _grid = grid;
            _player = player;
            _player.PathUpdated += (path) => { if (path.Count == 0) _isMoving = false; };
            _map = map;
            _pathEndPos = new Vector2Int(_player.X, _player.Y);
        }

        public void OnMoveHandler(CallbackContext context)
        {
            if (!context.performed)
                return;

            if (_player == null)
                return;

            var goalPosition = _grid.GridPositionFromWorldPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

            if (goalPosition.x == _player.X && goalPosition.y == _player.Y)
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
                _player.SetPath(goalPosition.x, goalPosition.y);
            }
            _pathEndPos = goalPosition;
        }

    }
}
