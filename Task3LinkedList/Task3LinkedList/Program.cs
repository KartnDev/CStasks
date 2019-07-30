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
        private bool IsLeftLessThanRight(Node<T> Left, Node<T> Right)
        {
           /*
            *   Value	                    Meaning
            *   ---------------------------------------------
            *   Less than zero	            x is less than y.
            *   Zero	                    x equals y.
            *   Greater than zero	        x is greater than y.
            */
            int result = Comparer<T>.Default.Compare(Left.Data, Right.Data);
            return (result < 0);
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

        public void InsertAt(T Data, int Index)
        {
            // O(n)
            if((Index > this.SIZE) || (Index < 0))
            {
                throw new IndexOutOfRangeException(Index + "th index is out of list range");
            }
            Node<T> Temp = PointerHead;
            for(int i = 0; i != Index - 1; i++)
            {
                Temp = Temp.PointerNext;
            }
            Temp.PointerNext = new Node<T>(Data, Temp.PointerNext);
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
                GC.Collect();
                // (GC will free (delete) head allocated memory) 
                // we forced to collect unuseable memory
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
        public bool CheckSorted()
        {
            Node<T> Temp = PointerHead;
            while (Temp.PointerNext != null)
            {
                if (!IsLeftLessThanRight(Temp, Temp.PointerNext))
                {
                    return false;
                }
                Temp = Temp.PointerNext;
            }
            return true;
        }
        public T RemoveAt(int Index)
        {
            if ((Index > this.SIZE) || (Index < 0))
            {
                throw new IndexOutOfRangeException(Index + "th index is out of list range");
            }
            Node<T> Temp = PointerHead;
            for (int i = 0; i != Index - 1; i++)
            {
                Temp = Temp.PointerNext;
            }
            T ResultData = Temp.PointerNext.Data;
            Temp.PointerNext = Temp.PointerNext.PointerNext;
            return ResultData;
        }

        public LinkedList<T> ExtendList(T Data)
        {
            LinkedList<T> NewList = this;

            if(this.CheckSorted())
            {
                
                Node<T> Temp = NewList.PointerHead;
                int i = 0;
                for (; Temp != null; i++)
                {
                    if(IsLeftLessThanRight(Temp, new Node<T>(Data)))
                    {
                        Temp = Temp.PointerNext;
                    }
                    else
                    {
                        break;
                    }
                }
                this.InsertAt(Data, i);
                return NewList;
            }
            else
            {
                throw new Exception("Unsorted list exception");
                // we can write own UnsortedListException which extends Exception
                // or SyntaxError/Exception
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
        #warning NO IMPLEMENTATION HERE
        IEnumerator IEnumerable.GetEnumerator() 
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> StringList = new LinkedList<string>();

            StringList.PushBack("Push");
            StringList.PushBack("Back");
            StringList.PushBack("String");
            StringList.PushBack("List");

            foreach(string item in StringList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=============================================\n");

            LinkedList<int> list = new LinkedList<int>();
            for(int i = 100; i > 0; i-=4)
            {
                list.PushBack(i);
            }
            list.PushBack(0);
            list.InsertAt(1000, 26);
            Console.WriteLine( "Removed at 26: "+ list.RemoveAt(26));
            LinkedList<int> a= list.ExtendList(51);
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Is list \"a\" sorted :" + list.CheckSorted() + "\n");

            Console.WriteLine("Try to push out range list: ");
            try
            {
                a.InsertAt(100, 100);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
