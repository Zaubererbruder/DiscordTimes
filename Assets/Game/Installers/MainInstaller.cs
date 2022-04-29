using Assets.Game.Core.OnMap;
using Assets.Game.Core.Presenters.Map;
using Assets.Game.Models.MapModels.Spawners;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Assets.Game.Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Tilemap _pathfindingMap;
        [SerializeField] private Tilemap _spawnerMap;
        [SerializeField] private Grid2DSize _gridSize;

        public override void InstallBindings()
        {
            InstallGrid();
            InstallLevelModels();
            InstallPresenters();
        }

        private void InstallPresenters()
        {
            Container.Bind<PawnPresenterFactory>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }

        private void InstallLevelModels()
        {
            Container.Bind<IPawnFactory>()
                .To<PawnFactory>()
                .AsSingle()
                .NonLazy();

            Container.Bind<ILevelDataBuilder>()
                .To<LevelDataFromSceneBuilder>()
                .AsSingle()
                .NonLazy();
        }

        public void InstallGrid()
        {
            GridTilemaps tilemaps = new GridTilemaps(_pathfindingMap, _spawnerMap);
            Container.Bind<GridTilemaps>()
                .FromInstance(tilemaps)
                .AsSingle()
                .NonLazy();

            Container.Bind<Grid2DSize>()
                .FromInstance(_gridSize)
                .AsSingle()
                .NonLazy();

            Container.Bind<Grid2D>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }


    }
}
