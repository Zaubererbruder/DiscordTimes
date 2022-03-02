using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public class GridPath : Path<GridNode>
    {
        public GridPath() : base()
        {

        }

        public GridPath(Path<GridNode> oldPath) : base (oldPath)
        {

        }

        public override Path<GridNode> Copy()
        {
            var copy = new GridPath(this);
            return copy;
        }
    }
}
