using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core.Pathfinding
{
    public class Path<T>
    {
        private Queue<T> _path = new Queue<T>();
        private T _end;
        
        public Path()
        {
            
        }
        public Path(Path<T> oldPath)
        {
            _path = new Queue<T>(oldPath._path);
            _end = oldPath._end;
        }

        public T EndNode => _end;
        public T NextNode => _path.Peek();
        public IEnumerable<T> PathNodes => _path;
        public int Count => _path.Count;

        public virtual Path<T> Copy()
        {
            var copy = new Path<T>(this);
            return copy;
        }

        public void AddNodeToPath(T node)
        {
            _end = node;
            _path.Enqueue(node);
            
        }

        public T Dequeue()
        {
            if(_path.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            var first = _path.Dequeue();
            return first;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            Path<T> p = (Path<T>)obj;
            return PathNodes.SequenceEqual(p.PathNodes);
        }
    }
}
