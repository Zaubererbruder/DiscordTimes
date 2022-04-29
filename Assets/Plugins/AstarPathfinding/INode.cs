using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.AstarPathfinding
{
    public interface INode
    {
        public int X { get; }
        public int Y { get; }
        public float Cost { get; }
    }
}
