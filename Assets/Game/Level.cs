using Assets.Core.OnMap;
using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Presenters;
using Assets.Game.Core.Presenters.Map;
using Assets.Game.Core.Spawners;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.Spawners;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace Assets.Core
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _aiPrefab;
        [SerializeField] private Vector2Int _gridWorldSize;
        [SerializeField] private float _nodeRadius;
        [SerializeField] private Tilemap _pathfindingMap;
        [SerializeField] private float _diagMovementrate;
        [SerializeField] private Transform _transformPlayerSpawner;
        [SerializeField] private Transform _playerPawnParent;

        private Grid2D _grid;
        private LevelMap _map;
        private List<IPawnFactory> factories = new List<IPawnFactory>();

        public GameTime GameTime => _map.GameTime;

        private void Awake()
        {
            _grid = new Grid2D();
            _grid.Init(_nodeRadius, _pathfindingMap, _gridWorldSize);

            _map = new LevelMap(_grid.ReadMapCells());
            _map.Graph.SetDiagMovementRate(_diagMovementrate);

            var spawners = FindObjectsOfType<SpawnerBehaviour>();
            foreach (var spawner in spawners)
            {
                spawner.Init();
                var spawnerPoint = _grid.GridPositionFromWorldPoint(spawner.WorldPosition);
                if (spawner.IsPlayerControlled)
                {
                    var playerFactory = new PlayerPawnFactory(_map);
                    playerFactory.SetPosition(spawnerPoint.x, spawnerPoint.y);
                    _map.AddOnstartableModel(playerFactory);
                    factories.Add(playerFactory);
                }
                else
                {
                    var aiFactory = new AIPawnFactory(_map);
                    aiFactory.SetPosition(spawnerPoint.x, spawnerPoint.y);
                    _map.AddOnstartableModel(aiFactory);
                    factories.Add(aiFactory);
                }
            }
        }

        private void OnEnable()
        {
            factories.ForEach((factory) => factory.PawnSpawned += PlayerSpawner_PawnSpawned);
        }

        private void OnDisable()
        {
            factories.ForEach((factory) => factory.PawnSpawned -= PlayerSpawner_PawnSpawned);
        }

        private void Start()
        {
            _map.Start();
        }

        private void PlayerSpawner_PawnSpawned(Pawn pawn)
        {
            var transform = pawn.GetComponent<PawnTransform>();
            var worldPos = _grid.WorldPointFromGridPosition(new Vector2Int(transform.X, transform.Y));
            if (pawn.isPlayerControlled)
            {
                var obj = Instantiate(_playerPrefab, worldPos, Quaternion.identity, _playerPawnParent);
                obj.GetComponent<PawnPresenter>().Init(_grid, pawn).enabled = true;
                obj.GetComponent<PlayerInputHandler>().Init(_grid, pawn, _map).enabled = true;
                obj.GetComponent<PathPresenter>().Init(_grid, pawn).enabled = true;
            }
            else
            {
                var obj = Instantiate(_aiPrefab, worldPos, Quaternion.identity, _playerPawnParent);
                obj.GetComponent<PawnPresenter>().Init(_grid, pawn).enabled = true;
            }
            Debug.Log($"Pawn spawned {pawn}. Team:{pawn.Team}, IsPlayerControlled: {pawn.isPlayerControlled}");
        }
    }
}
