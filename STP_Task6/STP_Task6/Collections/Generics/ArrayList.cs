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
            this.Length = 0;
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

        public TValue this[int index]
        {
            get => ValueOf(index);
            set => array[index] = value;
        }
        public int Count => Length;

        public int Add(TValue value)
        {
            if (Capacity <= Length)
            {
                AppendCapacity(Capacity * 2);
                array[Length] = value;
                Length++;
                return 1;
            }
            else
            {
                array[Length] = value;
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
                yield return this[i];
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
        public TValue ValueOf(int index) => array[index];


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

                for (int i = index; i < Length; i++)
                {
                    temp = array[index];
                    array[index] = value;
                }
                Length++;
            }
        }

        public void Remove(TValue value)
        {
            for(int i =0; i < Length; i++)
            {
                if(value.Equals(array[i]))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Length; i++)
            {
                array[i] = array[i + 1];
                //array[Length - 1] = default(TValue);
                
            }
            Length--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}