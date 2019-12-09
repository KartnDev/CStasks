using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections.Generics
{
    public abstract class UnmutableList<TValue> : IList<TValue>
    {
        public int Length { get; protected set; }
        public abstract int Count { get; }

        public abstract TValue this[int index] { get; }

        protected Node<TValue> pointerHead;
        protected class Node<T>
        {
            public T data;
            public Node<T> pointerNext;

            public void Finalize()
            {
                data = default(T);
                GC.Collect();
            }

            public Node(T data, Node<T> pointerNext = null)
            {
                this.data = data;
                this.pointerNext = pointerNext;
            }

        }

        public abstract TValue ElementAt(int index);
        public abstract int Add(TValue value);
        public abstract void InsertAt(int index, TValue value);
        public abstract void Remove(TValue value);
        public abstract void RemoveAt(int index);
        public abstract bool Contains(TValue value);
        public abstract int IndexOf(TValue value);
        public abstract void Clear();
        public abstract IEnumerator<TValue> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
