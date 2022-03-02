using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace Assets.Game.Core.Presenters.UI
{
    public class UIPresenter : MonoBehaviour
    {
        [SerializeField] private string _propertyName;
        [SerializeField] private Component _component;

        public T BindField<T>()
        {
            var componentType = _component.GetType();
            var propertyInfo = componentType.GetProperty(_propertyName);
            return (T)propertyInfo.GetValue(_component);
        }
    }
}
