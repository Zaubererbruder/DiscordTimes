using System.Collections.Generic;
using System.Linq;
using Assets.Game.Core.Pathfinding.Priority_Queue;

namespace Assets.Game.Core.Pathfinding
{
    public abstract class AStarPathfinding<TGraph, TNode, TPath> 
        where TGraph:IGraph<TNode>
        where TNode:INode 
        where TPath:Path<TNode>,new()
    {
        private TGraph _graph;
        private HashSet<TNode> _closedValues = new HashSet<TNode>();
        private List<Queue<TNode>> _paths = new List<Queue<TNode>>();

        public TGraph Graph => _graph;

        public AStarPathfinding(TGraph graph)
        {
            _graph = graph;
        }

        public virtual float Heuristic(TNode a, TNode b)
        {
            return 0;
        }

        public virtual float GCost(TPath path)
        {
            return 0;
        }

        public virtual TPath Search(TNode start, TNode goal)
        {
            _closedValues.Clear();
            _paths.Clear();

            var frontier = new SimplePriorityQueue<TPath, float>();
            frontier.Enqueue(PathTo(null, start), 0);


            while (frontier.Count > 0)
            {
                var currentPath = frontier.First;
                var gcost = frontier.GetPriority(currentPath);
                frontier.Dequeue();

                var node = currentPath.EndNode;

                if (_closedValues.Contains(node))
                    continue;

                if (node.Equals(goal))
                {
                    return currentPath;
                }

                _closedValues.Add(node);

                foreach (var next in _graph.Neighbours(node))
                {                  
                    var newPath = PathTo(currentPath, next);
                    var newCost = GCost(newPath) + Heuristic(next, goal);
                    frontier.Enqueue(newPath, newCost);
                }
            }

            return null;
        }

        private TPath PathTo(TPath path, TNode node)
        {
            TPath result;
            if (path == null)
                result = new TPath();
            else
                result = (TPath)path.Copy();

            result.AddNodeToPath(node);
            return result;
        }
    }
}
