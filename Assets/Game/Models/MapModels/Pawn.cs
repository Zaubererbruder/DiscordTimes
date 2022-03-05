using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class Pawn
    {
        List<PawnComponent> _components = new List<PawnComponent>();
        private int _teamNumber;

        public Pawn(int team)
        {
            _teamNumber = team;
        }

        public bool isPlayerControlled => _teamNumber == 0;

        public void AttachComponent(PawnComponent component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));

            component.Owner = this;
            component.Init();
            _components.Add(component);
        }

        public T GetComponent<T>() where T:PawnComponent
        {
            foreach(var comp in _components)
            {
                if (comp is T)
                    return (T)comp;
            }
            return null;
        }

        internal void Update(float deltatime)
        {
            _components.ForEach((comp) => comp.Update(deltatime));
        }
    }
}
