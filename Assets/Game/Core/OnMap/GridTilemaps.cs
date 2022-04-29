using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;

namespace Assets.Game.Core.OnMap
{
    public class GridTilemaps
    {
        public GridTilemaps(Tilemap pathfindingTilemap, Tilemap spawnerTilemap)
        {
            PathfindingTilemap = pathfindingTilemap;
            SpawnerTilemap = spawnerTilemap;
        }

        public Tilemap PathfindingTilemap { get; set; }
        public Tilemap SpawnerTilemap { get; set; }
    }
}
