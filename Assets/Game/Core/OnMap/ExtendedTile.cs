using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Game.Core.OnMap
{
    [CreateAssetMenu(fileName = "ExtendedTile", menuName = "Tiles/ExtendedTile")]
    public class ExtendedTile : Tile
    {
        [SerializeField] private float _cost;
        public float Cost => _cost;
    }
}
