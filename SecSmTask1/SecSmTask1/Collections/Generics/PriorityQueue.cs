using Collections.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Collections.Collections.Utils.Sorts;

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
            list = new DoubleLinkedList<TValue>(list.InsertionSortWithDelegate(new CompareDelegate<TValue>((value1, value2) => PriorityDelegate(value1, value2))));
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
