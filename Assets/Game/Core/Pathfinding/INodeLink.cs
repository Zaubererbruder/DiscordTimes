using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public interface INodeLink
    {
        public INode SourceNode { get; }
        public INode TargetNode { get; }
        public float Cost { get; }
    }
}
