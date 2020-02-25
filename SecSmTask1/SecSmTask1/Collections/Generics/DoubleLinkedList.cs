using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Collections.Generics
{
    public class DoubleLinkedList<TValue> : IList<TValue>
    {

        private Node headPtr = null;
        private Node tailPtr = null;

        private int lenght = 0;

        public DoubleLinkedList()
        {

        }

        public DoubleLinkedList(DoubleLinkedList<TValue> list)
        {

        }


        public TValue this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => lenght;

        public TValue First { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TValue Last { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int AddFirst(TValue value)
        {
            if(lenght == 0)
            {
                headPtr = tailPtr = new Node(value);
            }
            else
            {
                headPtr = new Node(value, null, headPtr); 
            }
            lenght++;
            return 1;
        }

        public int AddLast(TValue value)
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

        public TValue ElementAt(int index)
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

        public void SetElementAt(TValue data, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class Node
        {
            public Node(TValue data, Node prev = null, Node next = null)
            {
                this.data = data;
                this.nextPrt = next;
                this.prevPtr = prev;
            }

            public Node prevPtr;
            public Node nextPrt;
            public TValue data;
        }


    }
}
