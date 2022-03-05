using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public abstract class PawnComponent
    {
        protected Pawn _owner;

        public Pawn Owner { get => _owner; internal set => _owner = value; }

        public virtual void Init()
        {

        }

        public T GetComponent<T>() where T:PawnComponent
        {
            return _owner.GetComponent<T>();
        }

        internal virtual void Update(float deltaTime)
        {

        }
    }
}
