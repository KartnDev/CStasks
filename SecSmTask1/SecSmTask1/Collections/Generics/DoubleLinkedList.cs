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

        public TValue First { get => headPtr.data; set => headPtr.data = value; }
        public TValue Last { get => tailPtr.data; set => tailPtr.data = value; }

        public int AddFirst(TValue value)
        {
            if (lenght == 0)
            {
                headPtr = tailPtr = new Node(value);
            }
            else
            {
                headPtr = new Node(value, null, headPtr);
                headPtr.nextPrt.prevPtr = headPtr;
            }
            lenght++;
            return 1;
        }

        public int AddLast(TValue value)
        {
            if (lenght == 0)
            {
                headPtr = tailPtr = new Node(value);
            }
            else
            {
                tailPtr = new Node(value, tailPtr, null);
                tailPtr.prevPtr.nextPrt = tailPtr;
            }
            lenght++;
            return 1;
        }

        public void Clear()
        {
            this.headPtr = this.tailPtr = null;
            this.lenght = 0;
            GC.Collect();
        }

        public bool Contains(TValue value)
        {
            foreach (var item in this)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public TValue ElementAt(int index)
        {
                
            if(index < 0 || index >= lenght)
            {
                throw new IndexOutOfRangeException($"Taken index '{index}' is out of range");
            }

            var temp = headPtr;
            for (int i = 0; i <= index; i++)
            {
                temp = temp.nextPrt;
            }

            return temp.data;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            var temp = headPtr;
            while (temp.nextPrt != null)
            {
                yield return temp.data;
                temp = temp.nextPrt;
            }
            yield return temp.data;
        }

        public int IndexOf(TValue value)
        {
            int i = 0;
            foreach (var item in this)
            {
                if (value.Equals(item))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void InsertAt(int index, TValue value)
        {
            throw new NotImplementedException();
        }
        public TValue RemoveLast()
        {
            throw new NotImplementedException();
        }
        public TValue RemoveFirst()
        {
            throw new NotImplementedException();
        }
        public TValue Remove(TValue value)
        {
            throw new NotImplementedException();
        }


        public TValue RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void SetElementAt(TValue data, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
