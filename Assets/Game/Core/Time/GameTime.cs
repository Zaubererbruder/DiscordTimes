using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Time
{
    public class GameTime
    {
        private DateTime _time = DateTime.MinValue;

        public DateTime Time => _time;

        public event Action TimeChanged;
        public void Update(float deltaTime)
        {
            var hour = _time.Hour;
            _time = _time.AddSeconds(deltaTime);

            if (hour != _time.Hour)
                TimeChanged?.Invoke();
        }
    }

}
