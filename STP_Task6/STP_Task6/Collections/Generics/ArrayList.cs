using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections.Generics
{
    class ArrayList<TValue> : IList<TValue>
    {
        public TValue this[int index] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public int Add(TValue value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TValue value)
        {
            throw new NotImplementedException();
        }

        public ref TValue ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(TValue value)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(int index, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Remove(TValue value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
