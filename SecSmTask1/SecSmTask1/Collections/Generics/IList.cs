using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Collections.Generics
{
    public interface IList<TValue> : IEnumerable<TValue>
    {
        int Count { get; }
        TValue First { get; set; }
        TValue Last { get; set; }
        TValue this[int index]
        {
            get;
            set;
        }

        TValue ElementAt(int index);
        void SetElementAt(TValue data, int index);

        int AddFirst(TValue value);
        int AddLast(TValue value);

        void InsertAt(int index, TValue value);

        TValue RemoveFirst();
        TValue RemoveLast();

        TValue Remove(TValue value);
        TValue RemoveAt(int index);

        bool Contains(TValue value);

        int IndexOf(TValue value);
        void Clear();
    }
}
