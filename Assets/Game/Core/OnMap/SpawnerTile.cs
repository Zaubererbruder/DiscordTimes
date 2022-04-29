using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Game.Core.OnMap
{
    [CreateAssetMenu(fileName = "SpawnerTile", menuName = "Tiles/SpawnerTile")]
    public class SpawnerTile : Tile
    {
        [SerializeField] private int _teamNumber;
        public int TeamNumber => _teamNumber;
    }
}
