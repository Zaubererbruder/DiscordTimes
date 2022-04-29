using Assets.Game.AstarPathfinding;
using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.ModelExtenders
{
    public class MapCellNode : MapCell, INode
    {
        public MapCellNode(int x, int y) :base(x,y)
        {

        }

        public float Cost { get; set; }
    }
}
