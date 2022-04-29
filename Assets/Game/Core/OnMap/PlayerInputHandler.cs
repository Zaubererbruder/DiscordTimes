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
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Core.OnMap
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Transform _transform;
        private Grid2D _grid;
        private Pawn _player;
        private LevelMap _map;
        private bool _isMoving = false;

        private void Awake()
        {
            _transform = transform;  
        }

        private void Update()
        {
            if(_isMoving)
            {
                _map?.Update(Time.deltaTime);
            }
        }

        [Inject]
        public void Construct(Grid2D grid)
        {
            _grid = grid;
        }

        public void Init(Pawn player, LevelMap map)
        {
            _player = player;
            _map = map;
        }

        public void OnMoveHandler(CallbackContext context)
        {
            if (!context.performed)
                return;

            if (_player == null)
                return;

            var goalPosition = _grid.GridPositionFromWorldPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }

    }
}
