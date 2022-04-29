using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.AstarPathfinding
{
    public interface IGridGraph<TNode> where TNode:INode
    {
        public TNode GetNode(int x, int y);
        public IEnumerable<TNode> Neighbours(TNode node);
        public float GCost(GridPath<TNode> path);
        public float Cost(TNode startNode, TNode endNode);
        public float Heuristic(TNode startNode, TNode endNode);
    }
}
