using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public interface IGraph<T> where T:INode
    {
        public IEnumerable<T> Nodes { get; }
        public IEnumerable<T> Neighbours(T node);
        //public float Heuristic(INode start, INode goal); //предположительная стоимость пути от start до goal
        //public float GCost(INode start, INode goal); //стоимость пути от start до goal
        public float Cost(T a, T b);
    }
}
