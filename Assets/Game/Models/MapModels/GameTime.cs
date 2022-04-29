using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Time
{
    [Serializable]
    public class GameTime
    {
        private float _multiplier = 3600;

        public GameTime()
        {
            
        }

        public DateTime Time { get; private set; }

        public event Action TimeChanged;

        public void Update(float deltaTime)
        {
            var hour = Time.Hour;
            Time = Time.AddSeconds(deltaTime * _multiplier);

            if (hour != Time.Hour)
                TimeChanged?.Invoke();
        }
    }

}
