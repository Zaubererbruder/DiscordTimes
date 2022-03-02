using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
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
        private Player _player;

        private void Awake()
        {
            _transform = transform;  
        }

        private void Start()
        {
        }

        public void Init(Grid2D grid, Player player)
        {
            _grid = grid;
            _player = player;
        }

        public void OnMoveHandler(CallbackContext context)
        {
            if (!context.performed)
                return;

            if (_player == null)
                return;

            var goalPosition = _grid.GridPositionFromWorldPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

            _player.SetPathOrMove(goalPosition.x, goalPosition.y);
        }

    }
}
