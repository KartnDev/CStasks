using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task5_Winform.MyCollections.Generic
{
    public struct KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<TKey, TValue>>[] items;

        public HashTable(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValue<TKey, TValue>>[size];
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public TValue Find(TKey key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<TKey, TValue>> linkedList = GetLinkedList(position);
            foreach (KeyValue<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<TKey, TValue>> linkedList = GetLinkedList(position);
            KeyValue<TKey, TValue> item = new KeyValue<TKey, TValue>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public void Remove(TKey key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<TKey, TValue>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<TKey, TValue> foundItem = default(KeyValue<TKey, TValue>);
            foreach (KeyValue<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        protected LinkedList<KeyValue<TKey, TValue>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<TKey, TValue>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<TKey, TValue>>();
                items[position] = linkedList;
            }

            return linkedList;
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
       {
            foreach(var list in items)
            {
                if (list != null)
                {
                    yield return list.First();  
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}