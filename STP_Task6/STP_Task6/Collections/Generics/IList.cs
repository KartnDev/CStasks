using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections
{
    public interface IList<TValue> : IEnumerable<TValue>
    {
        int Count { get; }

        TValue this[int index]
        {
            get;
        }

        ref TValue ElementAt(int index);
        int Add(TValue value);
        void InsertAt(int index, TValue value);
        void Remove(TValue value);
        void RemoveAt(int index);

        bool Contains(TValue value);

        int IndexOf(TValue value);
        void Clear();

    }
}
