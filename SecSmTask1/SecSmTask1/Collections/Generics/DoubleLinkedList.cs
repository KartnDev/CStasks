using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Collections.Collections.Utils.Sorts;

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

        public DoubleLinkedList(IEnumerable<TValue> list)
        {
            this.Clear();
            foreach (var item in list)
            {
                this.AddLast(item);
            }
        }


        public TValue this[int index] { get => ElementAt(index); set => SetElementAt(value, index); }

        public int Count => lenght;
        //TODO add throw here
        public TValue First { get { return headPtr.data; } set => headPtr.data = value; }
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
            if (lenght > 0)
            {
                foreach (var item in this)
                {
                    if (item.Equals(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public TValue ElementAt(int index)
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            if (index < 0 || index >= lenght)
            {
                throw new IndexOutOfRangeException($"Taken index '{index}' is out of range");
            }

            var temp = headPtr;
            for (int i = 0; i != index; i++)
            {
                temp = temp.nextPrt;
            }

            return temp.data;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
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
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
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
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Taken index '{index}' is out of range");
            }
            if (index > lenght)
            {
                var temp = headPtr;


                for (int i = lenght; i < index; i++)
                {
                    Object o = null;
                    AddLast((TValue)o);
                }
                AddLast(value);
            }
            else if (index == lenght)
            {
                AddLast(value);
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                var temp = headPtr;

                for (int i = 0; i != index; i++)
                {
                    temp = temp.nextPrt;
                }

                temp = new Node(value, temp.prevPtr, temp);
                temp.prevPtr.nextPrt = temp;
                temp.nextPrt.prevPtr = temp;
                lenght++;
            }

        }
        public TValue RemoveLast()
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            if (lenght == 1)
            {
                lenght--;
                var result = tailPtr.data;
                headPtr = tailPtr = null;
                return result;
            }
            else
            {
                var temp = tailPtr;
                tailPtr = tailPtr.prevPtr;
                tailPtr.nextPrt = null;
                temp.nextPrt = temp.nextPrt = null;
                lenght--;
                return temp.data;
            }
        }
        public TValue RemoveFirst()
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            var temp = headPtr;
            headPtr = headPtr.nextPrt;
            headPtr.prevPtr = null;


            temp.nextPrt = temp.prevPtr = null;
            lenght--;
            return temp.data;
        }
        public TValue Remove(TValue value)
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            var resultIndex = IndexOf(value);

            if (resultIndex == -1)
            {
                return default(TValue);
            }
            else
            {
                var temp = ElementAt(resultIndex);
                RemoveAt(resultIndex);
                return temp;
            }
        }


        public TValue RemoveAt(int index)
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            if (index < 0 || index > lenght)
            {
                throw new IndexOutOfRangeException($"Taken index '{index}' is out of range");
            }
            if (index == lenght - 1)
            {
                return RemoveLast();
            }
            else if (index == 0)
            {
                return RemoveFirst();
            }
            else
            {
                var temp = headPtr;
                for (int i = 0; i != index; i++)
                {
                    temp = temp.nextPrt;
                }

                temp.nextPrt.prevPtr = temp.prevPtr;
                temp.prevPtr.nextPrt = temp.nextPrt;

                temp.nextPrt = temp.prevPtr = null;
                lenght--;
                GC.Collect();
                return temp.data;
            }
        }

        public void SetElementAt(TValue value, int index)
        {
            if (lenght == 0)
            {
                throw new InvalidOperationException("Cannot invoke this method while list have zero elements");
            }
            if (index < 0 || index >= lenght)
            {
                throw new IndexOutOfRangeException($"Taken index '{index}' is out of range");
            }
            if (index == lenght - 1)
            {
                tailPtr.data = value;
            }
            else if (index == 0)
            {
                headPtr.data = value;
            }
            else
            {
                var temp = headPtr;
                for (int i = 0; i != index; i++)
                {
                    temp = temp.nextPrt;
                }
                temp.data = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(2 * lenght);
            foreach (var item in this)
            {
                stringBuilder.Append($"{item}  ");
            }
            stringBuilder.Append(Environment.NewLine);
            return stringBuilder.ToString();
        }

        public void InsertionSortWithDelegate(CompareDelegate<TValue> compareDelegate)
        {
            int i, j;

            for (i = 1; i < this.Count; i++)
            {
                TValue value = this[i];
                j = i - 1;
                while ((j >= 0) && (compareDelegate(this[j], value) > 0))
                {
                    this[j + 1] = this[j];
                    j = j - 1;
                }
                this[j + 1] = value;
            }
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
