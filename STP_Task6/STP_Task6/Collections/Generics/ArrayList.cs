using STP_Task6.Collections.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace STP_Task6.Collections.Generics
{
    public class ArrayList<TValue> : IList<TValue>
    {

        private TValue[] array;
        public int Length { get; private set; }
        public int Capacity { get; private set; }
        public ArrayList(int capacity = 32)
        {
            this.array = new TValue[capacity];
            this.Capacity = capacity;
            this.Length = 1;
        }

        public void AppendCapacity(int capacity)
        {
            if (capacity < 2 || capacity > 1024)
            {
                throw new OperationException("Too small or too big capacity value");
            }
            var tempArray = this.array;

            this.array = new TValue[Capacity + capacity];
            for (int i = 0; i < Length; i++)
            {
                array[i] = tempArray[i];
            }
        }

        public TValue this[int index] => throw new NotImplementedException();

        public int Count => Length;

        public int Add(TValue value)
        {
            if (Capacity <= Length - 1)
            {
                AppendCapacity(Capacity * 2);
                array[Length - 1] = value;
                Length++;
                return 1;
            }
            else
            {
                array[Length - 1] = value;
                Length++;
                return 0;
            }
        }

        public void Clear()
        {
            array = null;
            Capacity = 0;
            Length = 0;
        }

        public bool Contains(TValue value)
        {

            for (int i = 0; i < Length; i++)
            {
                if (array[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public TValue ElementAt(int index)
        {
            OutOfBoundException.CheckForBound(index, Length);
            return array[index];
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return array[i];
            }
        }

        public int IndexOf(TValue value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void InsertAt(int index, TValue value)
        {
            OutOfBoundException.CheckForBound(index, Length);
            if (index == 0)
            {
                Add(value);
            }
            else
            {
                if (Length - 1 == Capacity)
                {
                    AppendCapacity(2 * Capacity);
                }

                TValue temp;

                for (int i = index; i < Length + 1; i++)
                {
                    temp = array[index];
                    array[index] = value;
                }
                Length++;
            }
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
            return GetEnumerator();
        }
    }
}