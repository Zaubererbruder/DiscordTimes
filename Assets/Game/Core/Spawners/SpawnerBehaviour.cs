using UnityEngine;

namespace Assets.Game.Core.Spawners
{
    public class SpawnerBehaviour : MonoBehaviour
    {
        [SerializeField] private int _team;
        [SerializeField] private bool _isPlayerControlled;
        private Transform _transform;

        public bool IsPlayerControlled =>_isPlayerControlled;
        public Vector3 WorldPosition => _transform.position;

        public void Init()
        {
            _transform = transform;
            if (_isPlayerControlled)
            {

            }
        }
    }
}
