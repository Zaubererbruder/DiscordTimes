using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public interface IUpdateableModel
    {
        public void Update(float deltaTime);
    }
}
