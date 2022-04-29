using Assets.Game.Core.ModelExtenders;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.Spawners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Game.Core.OnMap
{
    public class LevelDataFromSceneBuilder : ILevelDataBuilder
    {
        private Grid2D _grid;
        private IPawnFactory _pawnFactory;
        public LevelDataFromSceneBuilder(Grid2D grid, IPawnFactory factory)
        {
            _grid = grid;
            _pawnFactory = factory;
        }

        private Tilemap PathfindingTilemap => _grid.Tilemaps.PathfindingTilemap;
        private Tilemap SpawnerTilemap => _grid.Tilemaps.SpawnerTilemap;

        public LevelData Build()
        {
            var cells = new MapCellNode[_grid.Size.GridWidth, _grid.Size.GridHeight];

            for (int x = 0; x < _grid.Size.GridWidth; x++)
            {
                for (int y = 0; y < _grid.Size.GridHeight; y++)
                {
                    Vector3 worldPoint = _grid.WorldPointFromGridPosition(x, y);
                    var pathfindingTile = PathfindingTilemap.GetTile<PathFindingTile>(PathfindingTilemap.WorldToCell(worldPoint));
                    if (pathfindingTile != null)
                    {
                        cells[x, y] = new MapCellNode(x, y);
                        cells[x, y].Cost = pathfindingTile.Cost;
                    }
                    var spawnerTile = SpawnerTilemap.GetTile<SpawnerTile>(SpawnerTilemap.WorldToCell(worldPoint));
                    if (spawnerTile != null)
                    {
                        cells[x, y].Pawn = _pawnFactory.Create(x,y, spawnerTile.TeamNumber);
                    }
                }
            }
            var mapData = new MapDataGraph(cells);
            var levelData = new LevelData(mapData);
            return levelData;
        }
    }
}
