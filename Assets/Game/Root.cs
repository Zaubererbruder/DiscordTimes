using Assets.Game.Core.OnMap;
using Assets.Game.Core.Presenters.Map;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels;
using UnityEngine;
using Zenject;

namespace Assets.Core
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _aiPrefab;
        [SerializeField] private Transform _playerPawnParent;

        private LevelMap _map;
        private ILevelDataBuilder _levelDataBuilder;
        private PawnPresenterFactory _pawnPresenterFactory;

        public GameTime GameTime => _map.Gametime;

        [Inject]
        public void Construct(ILevelDataBuilder levelDataBuilder, PawnPresenterFactory pawnPresenterFactory)
        {
            _levelDataBuilder = levelDataBuilder;
            _pawnPresenterFactory = pawnPresenterFactory;
        }

        private void Awake()
        {
            _map = new LevelMap(_levelDataBuilder.Build());
            foreach(var pawn in _map.Pawns)
            {
                _pawnPresenterFactory.Create(pawn, _map);
            }
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            _map.Start();
        }
    }
}
