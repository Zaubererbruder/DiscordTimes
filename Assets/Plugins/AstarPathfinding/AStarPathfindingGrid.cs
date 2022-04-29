using Priority_Queue;
using System.Collections.Generic;

namespace Assets.Game.AstarPathfinding
{
    public class AStarPathfindingGrid<TGraph, TNode> where TGraph:IGridGraph<TNode> where TNode : INode
    {
        public TGraph Graph { get; private set; }

        public AStarPathfindingGrid(TGraph graph)
        {
            Graph = graph;
        }

        public GridPath<TNode> Search(int startx, int starty, int goalx, int goaly)
        {
            var startNode = Graph.GetNode(startx, starty);
            var goalNode = Graph.GetNode(goalx, goaly);

            var closedValues = new HashSet<INode>();
            var paths = new List<Queue<INode>>();

            closedValues.Clear();
            paths.Clear();

            var frontier = new SimplePriorityQueue<GridPath<TNode>, float>();
            frontier.Enqueue(PathTo(null, startNode), 0);

            while (frontier.Count > 0)
            {
                var currentPath = frontier.First;
                var gcost = frontier.GetPriority(currentPath);
                frontier.Dequeue();

                var node = currentPath.EndNode;

                if (closedValues.Contains(node))
                    continue;

                if (node.Equals(goalNode))
                {
                    return currentPath;
                }

                closedValues.Add(node);

                foreach (var next in Graph.Neighbours(node))
                {
                    var newPath = PathTo(currentPath, next);
                    var newCost = Graph.GCost(newPath) + Graph.Heuristic(next, goalNode);
                    frontier.Enqueue(newPath, newCost);
                }
            }

            return null;
        }

        private GridPath<TNode> PathTo(GridPath<TNode> path, TNode node)
        {
            GridPath<TNode> result;
            if (path == null)
                result = new GridPath<TNode>();
            else
                result = path.Copy();

            result.AddNodeToPath(node);
            return result;
        }
    }
}
