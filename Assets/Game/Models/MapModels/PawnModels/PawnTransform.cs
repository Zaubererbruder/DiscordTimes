using Assets.Game.Core.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.PawnModels
{
    public class PawnTransform : PawnComponent
    {
        private GridGraph _graph;

        public PawnTransform(GridGraph graph)
        {
            _graph = graph;
        }

        public PawnTransform(GridGraph graph, int x, int y) : this(graph)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public GridGraph Graph => _graph;
        public GridNode CurrentNode => Graph[X, Y];
    }
}
