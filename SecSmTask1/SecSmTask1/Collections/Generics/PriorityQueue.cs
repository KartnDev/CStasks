using Collections.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Collections.Collections.Utils.Sorts;
using static Collections.Collections.Utils.Searches;


namespace Collections.Collections.Generics
{

    public delegate int PriorityDelegate<TValue>(TValue value1, TValue value2);

    public class PriorityQueue<TValue> : IPriorityQueue<TValue>
    {
        private DoubleLinkedList<TValue> list = new DoubleLinkedList<TValue>();

        public PriorityQueue(PriorityDelegate<TValue> priorityDelegate)
        {
            this.PriorityDelegate = priorityDelegate;
        }

        public int Count => list.Count;

        public TValue TopItem => list.Last;

        public void Add(TValue value)
        {
            list.AddFirst(value);
            if(list.Contains(value))
            {
                int index = list.BinarySearch(value, (value1, value2) => PriorityDelegate(value1, value2));
                list.InsertAt(index, value);
            }
            else
            {
                list.AddLast(value);
                list.InsertionSortWithDelegate((value1, value2) => PriorityDelegate(value1, value2));
            }
        }

        public TValue Remove()
        {
            return list.RemoveLast();
        }

        public TValue Top()
        {
            return list.Last;
        }

        PriorityDelegate<TValue> PriorityDelegate { get; }
    }
}
