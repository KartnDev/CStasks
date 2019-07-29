using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3LinkedList
{


    public class LinkedList<T> : IEnumerable<T>
    {
        private int SIZE;
        private Node<T> PointerHead;
        private Node<T> PointerTail;
        private class Node<T> // имеет место быть структуре 
        {
            public T Data;
            public Node<T> PointerNext;// c/c++ p_next snake 
            public Node(T Data, Node<T> PointerNext = null)
            {
                this.Data = Data;
                this.PointerNext = PointerNext;
            }
        }
        public LinkedList()
        {
            SIZE = 0;
            PointerHead = null;
            PointerTail = null;
        }
          
        public void PushBack(T Data)
        {
            // O(1) 
            if(SIZE == 0)
            {
                PointerHead = new Node<T>(Data, null);
                PointerTail = PointerHead;
                SIZE++;
            }
            else
            {
                PointerHead = new Node<T>(Data, PointerHead);
                SIZE++;
            }
        }

        public int GetSize()
        {
            return this.SIZE;
        }
        public T PopBack()
        {
            // O(1 + const)
            if (SIZE != 0)
            {
                T Temp = PointerHead.Data;
                PointerHead = PointerHead.PointerNext;
                // (GC will delete head)
                //TODO: GC REMOVE FORCE
                // delete pointer on head
                // set pointer head to next of head
                return Temp;
            }
            else
            {
                return default(T);
            }
        }

        public T GetHeadData()
        {
            // O(1)
            return PointerHead.Data;    
        }
        public T GetTailData()
        {
            ///could be implemented without tail pointer? but int costs O(n) , right now it O(1)
            return PointerTail.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> Temp = PointerHead;
            T TempData;
            while(Temp != null)
            {
                TempData = Temp.Data;
                Temp = Temp.PointerNext;
                yield return TempData;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(10);
            list.PushBack(12);
            list.PushBack(232323);
            foreach(int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
