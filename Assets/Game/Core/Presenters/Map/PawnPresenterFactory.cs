using Assets.Core.OnMap;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.PawnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Game.Core.Presenters.Map
{
    public class PawnPresenterFactory
    {
        DiContainer _container;
        public GameObject _playerPrefab;
        public GameObject _aiPrefab;


        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
            _playerPrefab   = Resources.Load<GameObject>("PlayerPawnPrefab");
            _aiPrefab       = Resources.Load<GameObject>("AIPawnPrefab");
        }

        public void Create(Pawn pawn, LevelMap map)
        {
            GameObject prefab = null;
            if (pawn.IsPlayerControlled)
                prefab = _playerPrefab;
            else
                prefab = _aiPrefab;

            GameObject presenterObj = _container.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
            PawnPresenter pawnPresenter = presenterObj.GetComponent<PawnPresenter>();         
            pawnPresenter.InitPresenter(pawn);
            pawnPresenter.enabled = true;

            if (pawn.IsPlayerControlled)
            {
                PathPresenter pathPresenter = presenterObj.GetComponent<PathPresenter>();
                pathPresenter.Init(pawn);
                pathPresenter.enabled = true;

                PlayerInputHandler inputHandler = presenterObj.GetComponent<PlayerInputHandler>();
                inputHandler.Init(pawn, map);
                inputHandler.enabled = true;
            }

        }
    }
}
