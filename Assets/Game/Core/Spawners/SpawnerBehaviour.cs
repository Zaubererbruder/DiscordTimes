using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Awake()
        {
            _transform = transform;
            if(_isPlayerControlled)
            {
                
            }
        }
    }
}
