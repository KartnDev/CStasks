using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections.Generics
{
    public sealed class LinkedList<TValue> : IList<TValue>
    {
        public int Length { get; private set; }
        private Node<TValue> pointerHead;
        private Node<TValue> pointerTail;
        private class Node<T> 
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
        public LinkedList()
        {
            Length = 0;
            pointerHead = null;
            pointerTail = null;
        }

        public void PushBack(TValue data)
        {
            if (Length == 0)
            {
                pointerHead = new Node<TValue>(data, null);
                pointerTail = pointerHead;
                Length++;
            }
            else
            {
                pointerHead = new Node<TValue>(data, pointerHead);
                Length++;
            }
        }

        public void InsertAt(TValue data, int index)
        {
            // O(n)
            if ((index > this.Length) || (index < 0))
            {
                throw new OutOfBoundException(index + "the index is out of list range");
            }
            Node<TValue> temp = pointerHead;
            for (int i = 0; i != index - 1; i++)
            {
                temp = temp.pointerNext;
            }
            temp.pointerNext = new Node<TValue>(data, temp.pointerNext);
        }

        public TValue PopBack()
        {
            // O(1 + const)
            if (Length != 0)
            {
                TValue temp = pointerHead.data;
                pointerHead = pointerHead.pointerNext;
                GC.Collect();
                // (GC will free (delete) head allocated memory) 
                // we forced to collect unuseable memory
                //TODO: GC REMOVE FORCE
                // delete pointer on head
                // set pointer head to next of head
                return temp;
            }
            else
            {
                return default(TValue);
            }
        }
        public TValue RemoveAt(int index)
        {
            if ((index > this.Length) || (index < 0))
            {
                throw new IndexOutOfRangeException(index + "th index is out of list range");
            }
            Node<TValue> Temp = pointerHead;
            for (int i = 0; i != index - 1; i++)
            {
                Temp = Temp.pointerNext;
            }
            TValue ResultData = Temp.pointerNext.data;
            Temp.pointerNext = Temp.pointerNext.pointerNext;
            return ResultData;
        }

        public TValue First()
        {
            // O(1)
            return pointerHead.data;
        }
        public TValue Last()
        {
            ///could be implemented without tail pointer? but int costs O(n) , right now it O(1)
            return pointerTail.data;
        }


        public TValue this[int index] => ElementAt(index);

        public int Count => this.Length;

        public int Add(TValue value)
        {
            PushBack(value);
            return 0;
        }

        public void Clear()
        {
            
        }

        public bool Contains(TValue value)
        {
            throw new NotImplementedException();
        }

        public ref TValue ElementAt(int index)
        {

        }

        public IEnumerator<TValue> GetEnumerator()
        {
            Node<TValue> temp = pointerHead;
            TValue tempData;
            while (temp != null)
            {
                tempData = temp.data;
                temp = temp.pointerNext;
                yield return tempData;
            }
        }

        public int IndexOf(TValue value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Remove(TValue value)
        {

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IList<TValue>.RemoveAt(int index) => RemoveAt(index);
    }
}
