using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public interface INode
    {
        public IEnumerable<INodeLink> Links { get; }
    }
}
