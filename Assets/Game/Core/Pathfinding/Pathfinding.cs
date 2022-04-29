using Assets.Game.AstarPathfinding;
using Assets.Game.Core.ModelExtenders;
using Assets.Game.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public class Pathfinding : AStarPathfindingGrid<MapDataGraph, MapCellNode>
    {
        public Pathfinding(MapDataGraph graph) : base(graph)
        {

        }
    }
}
