using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public struct GridLink : INodeLink
    {
        private GridNode _sourceNode;
        private GridNode _targetNode;
        private float _cost;

        public GridLink(GridNode source, GridNode target, float cost)
        {
            _sourceNode = source;
            _targetNode = target;
            _cost = cost;
        }

        public float Cost => _cost;

        public INode SourceNode => _sourceNode;

        public INode TargetNode => _targetNode;
    }
}
