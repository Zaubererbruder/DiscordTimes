using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Core.Presenters.Map
{
    public class ModelPresenter<T> : MonoBehaviour
    {
        protected T Model;

        public void InitPresenter(T model)
        {
            Model = model;
        }
    }
}
