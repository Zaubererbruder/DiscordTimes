using Assets.Core.OnMap;
using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
using Assets.Game.Core.Presenters.Map;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Core
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObj;
        [SerializeField] private Vector2Int _gridWorldSize;
        [SerializeField] private float _nodeRadius;
        [SerializeField] private Tilemap _pathfindingMap;
        [SerializeField] private float _diagMovementrate;
        [SerializeField] private Transform _transformPlayerSpawner;
        [SerializeField] private Transform _playerPawnParent;

        private Grid2D _grid;
        private LevelMap _map;
        //private PlayerPawn _player;

        public GameTime GameTime => _map.GameTime;

        private void Awake()
        {
            _grid = new Grid2D();
            _grid.Init(_nodeRadius, _pathfindingMap, _gridWorldSize);

            _map = new LevelMap(_grid.ReadMapCells());
            _map.Graph.SetDiagMovementRate(_diagMovementrate);
            //var playerPoint = _grid.GridPositionFromWorldPoint(_playerObj.transform.position);

            var playerSpawnerPoint = _grid.GridPositionFromWorldPoint(_transformPlayerSpawner.position);
            var playerSpawner = new PlayerPawnSpawner(_map, playerSpawnerPoint.x, playerSpawnerPoint.y);
            playerSpawner.PawnSpawned += PlayerSpawner_PawnSpawned;
            _map.AddOnstartableModel(playerSpawner);

            _map.Start();

        }

        private void PlayerSpawner_PawnSpawned(PlayerPawn pawn)
        {
            var worldPos = _grid.WorldPointFromGridPosition(new Vector2Int(pawn.X, pawn.Y));
            var obj = Instantiate(_playerObj, worldPos, Quaternion.identity, _playerPawnParent);
            obj.GetComponent<PlayerInputHandler>().Init(_grid, pawn, _map);
            obj.GetComponent<PathPresenter>().Init(_grid, pawn);
            obj.GetComponent<PlayerPresenter>().Init(_grid, pawn);
        }
    }
}
