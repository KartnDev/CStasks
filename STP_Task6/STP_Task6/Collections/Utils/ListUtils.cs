using STP_Task6.Collections.Generics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STP_Task6.Collections.Utils.Qsort;


#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
namespace STP_Task6.Collections.Utils
{
    public static class ListUtils<TValue>
    {

        public delegate bool CheckDelegate<TValue>(TValue item);
        public delegate void ActionDelegate<TValue>(TValue item);
        public delegate int CompareDelegate<TValue>(TValue item0, TValue item1);
        public delegate IList<TValue> ListConstructorDelegate<TValue>();
        public delegate TOutput ConvertDelegate<TInput, TOutput>(TInput item1);


        public static readonly ListConstructorDelegate<TValue> ArrayListConstructor;
        public static readonly ListConstructorDelegate<TValue> LinkedListConstructor;

        static ListUtils()
        {
            ArrayListConstructor = new ListConstructorDelegate<TValue>(() => new ArrayList<TValue>());
            LinkedListConstructor = new ListConstructorDelegate<TValue>(() => new LinkedList<TValue>());
        }

        public static bool Exists(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {

            return delegate_func.DynamicInvoke((dynamic)list);

        }

        public static TValue Find<TValue>(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {
            foreach(var item in list)
            {
                if(delegate_func(item))
                {
                    return item;
                }
            }
            return default(TValue);
        }

        public static TValue FindLast<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            foreach(var item in list.Reverse())
            {
                
                if (delegete_func(item))
                {
                    return item;
                }
            }
            return default(TValue);
        }

        public static int FindIndex<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            int iterator = 0;
            foreach (var item in list)
            {
                if (delegete_func(item))
                {
                    return iterator;
                }
                iterator++;
            }
            return -1;
        }

        public static int FindLastIndex<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            int iterator = 0;
            foreach (var item in list.Reverse())
            {
                if (delegete_func(item))
                {
                    return iterator;
                }
                iterator++;
            }
            return -1;
        }
        public static IList<TValue> FindAll<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func, ListConstructorDelegate<TValue> listConstructorDelegate)
        {
            IList<TValue> resultList = listConstructorDelegate();

            foreach (var item in list.Reverse())
            {
                if (delegete_func(item))
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }

        public static IList<TOutput> ConvertAll<TInput, TOutput>
            (IList<TInput> list, ConvertDelegate<TInput, TOutput> convertDelegate, ListConstructorDelegate<TOutput> listConstructorDelegate)
        {
            IList<TOutput> resultList = listConstructorDelegate();

            foreach (var item in list.Reverse())
            {
                resultList.Add(convertDelegate(item));
            }
            return resultList;
        }

        public static void ForEach(IList<TValue> list, ActionDelegate<TValue> actionDelegate)
        {
            foreach (var item in list)
            {
                actionDelegate(item);
            }
        }

        public static void Sort(IList<TValue> list, CompareDelegate<TValue> compareDelegate)
        {
            list.QuickSortWithDelegate(compareDelegate);
        }

        public static bool CheckForAll<TValue>(IList<TValue> list, CheckDelegate<TValue> checkDelegate)
        {

            foreach (var item in list.Reverse())
            {
                if(!checkDelegate(item))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
