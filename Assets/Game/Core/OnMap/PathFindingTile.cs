using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Game.Core.OnMap
{
    [CreateAssetMenu(fileName = "PathFindingTile", menuName = "Tiles/PathFindingTile")]
    public class PathFindingTile : Tile
    {
        [SerializeField] private float _cost;
        public float Cost => _cost;
    }
}
