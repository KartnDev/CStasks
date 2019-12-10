using STP_Task6.Collections.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace STP_Task6.Collections.Generics
{
    public sealed class LinkedList<TValue> : UnmutableList<TValue>, IList<TValue>
    {

        public LinkedList()
        {
            Length = 0;
            pointerHead = null;
        }

        public void PushBack(TValue data)
        {
            if (Length == 0)
            {
                pointerHead = new Node<TValue>(data, null);
                Length++;
            }
            else
            {
                var temp = pointerHead;
                while (temp.pointerNext != null) // size > 0
                {
                    temp = temp.pointerNext;
                }
                temp.pointerNext = new Node<TValue>(data, null);
                Length++;
            }
        }

        public void PushFront(TValue data)
        {
            pointerHead = new Node<TValue>(data, pointerHead);
            Length++;
        }


        public override void InsertAt(int index, TValue data)
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

        public IEnumerable<TValue> QuickSortWithDelegate
             (STP_Task6.Collections.Utils.ListUtils<TValue>.CompareDelegate<TValue> compareDelegate)
        {
            if (!this.Any())
            {
                return Enumerable.Empty<TValue>();
            }
            var pivot = this.First();
            var smaller = this.Skip(1).Where(item => compareDelegate(item, pivot) <= 0).QuickSortWithDelegate(compareDelegate);
            var larger = this.Skip(1).Where(item => compareDelegate(item, pivot) > 0).QuickSortWithDelegate(compareDelegate);

            return smaller.Concat(new[] { pivot }).Concat(larger);
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


        public void PopFront()
        {
            Node<TValue> temp = pointerHead;
            pointerHead = pointerHead.pointerNext;
            temp.data = default(TValue);
            temp.Finalize();
            Length--;
        }



        public TValue RemoveAtWithData(int index)
        {
            if ((index > this.Length) || (index < 0))
            {
                throw new IndexOutOfRangeException(index + "th index is out of list range");
            }
            if (index == 0)
            {
                var result = pointerHead.data;
                pointerHead = pointerHead.pointerNext;
                return result;
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
            return ElementAt(Length - 1);
        }


        public override TValue this[int index]
        {
            get => ElementAt(index);
            set
            {
                var temp = pointerHead;
                for (int i = 0; i != index; i++)
                {
                    temp = temp.pointerNext;
                }
                temp.data = value;
                
            }
        }
        public override int Count => this.Length;

        public override int Add(TValue value)
        {
            PushBack(value);
            return 0;
        }

        public override void Clear()
        {
            while (Length != 0) // size > 0
            {
                PopFront();
            }
        }

        public override bool Contains(TValue value)
        {

            return IndexOf(value) != -1;
        }

        public override TValue ElementAt(int index)
        {
            int counter = 0;
            Node<TValue> current = this.pointerHead;

            if (index > Length || index < 0)
            {
                throw new OutOfBoundException(index + "th index is out of list range");
            }

            while (current != null)
            {
                if (counter == index)
                {
                    return current.data;
                }
                current = current.pointerNext;

                counter++;
            }
            return default(TValue);
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            for(int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        public override int IndexOf(TValue value)
        {
            Node<TValue> temp = pointerHead;
            for (int i = 0; i < Length; i++)
            {
                if (temp.data.Equals(value))
                {
                    return i;
                }
                else
                {
                    temp = temp.pointerNext;
                }
            }
            return -1;
        }

        public override void Remove(TValue value)
        {
            PopFront();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override void RemoveAt(int index) => RemoveAtWithData(index);

    }
}
