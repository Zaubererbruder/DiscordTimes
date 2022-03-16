using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Game.Debug
{
    public class DebugBehaviour : MonoBehaviour
    {
        private GridDebug _gridDebug;

        private void Awake()
        {
            //_gridDebug = new GridDebug();
            
        }

        private void OnEnable()
        {
            
        }

        private void OnGUI()
        {
            Handles.Label(new Vector3(10,10,-1), "Hello");
        }
    }
}
