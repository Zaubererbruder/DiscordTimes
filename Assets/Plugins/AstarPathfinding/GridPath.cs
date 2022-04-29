using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.AstarPathfinding
{
    public class GridPath<TNode> where TNode : INode
    {
        private Queue<TNode> _path = new Queue<TNode>();
        public TNode EndNode { get; private set; }
        public IEnumerable<TNode> Nodes => _path;

        internal void AddNodeToPath(TNode node)
        {
            _path.Enqueue(node);
            EndNode = node;
        }

        internal GridPath<TNode> Copy()
        {
            var copy = new GridPath<TNode>();
            copy._path = new Queue<TNode>(_path);
            copy.EndNode = EndNode;
            return copy;
        }
    }
}
