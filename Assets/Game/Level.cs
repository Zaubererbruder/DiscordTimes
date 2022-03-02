using Assets.Core.OnMap;
using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
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

        private Grid2D _grid;
        private GameTime _gameTime;
        private LevelMap _map;
        private Player _player;

        public GameTime GameTime => _gameTime;

        private void Awake()
        {
            _grid = new Grid2D();
            _grid.Init(_nodeRadius, _pathfindingMap, _gridWorldSize);

            _gameTime = new GameTime();
            _map = new LevelMap(_grid.ReadMapCells());
            _map.Graph.SetDiagMovementRate(_diagMovementrate);
            var playerPoint = _grid.GridPositionFromWorldPoint(_playerObj.transform.position);
            _player = _map.CreatePlayer(playerPoint.x, playerPoint.y);
            _playerObj.GetComponent<PlayerInputHandler>().Init(_grid, _player);
            _playerObj.GetComponent<PathPresenter>().Init(_grid, _player);
        }
    }
}
