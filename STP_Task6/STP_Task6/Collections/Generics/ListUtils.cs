using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
namespace STP_Task6.Collections.Generics
{
    public static class ListUtils<TValue>
    {

        public delegate void CheckDelegate<TValue>(TValue item);
        public delegate void ActionDelegate<TValue>(TValue item);
        public delegate void CompareDelegate<TValue>(TValue item);
        public delegate void ListConstructorDelegate<TValue>(TValue item);
        public delegate void ConvertDelegate<TInput, TOutput>(TInput item1, TOutput item2);

        public static bool Exists(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {
            throw new NotImplementedException();
        }

        public static TValue Find<TValue>(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {
            throw new NotImplementedException();
        }

        public static TValue FindLast<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            throw new NotImplementedException();
        }

        public static int FindIndex<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            throw new NotImplementedException();
        }

        public static int FindLastIndex<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            throw new NotImplementedException();
        }
        public static IList<TValue> FindAll<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func, ListConstructorDelegate<TValue> listConstructorDelegate)
        {
            throw new NotImplementedException();
        }

        public static IList<TOutput> ConvertAll<TInput, TOutput>
            (IList<TInput> list, ConvertDelegate<TInput, TOutput> convertDelegate, ListConstructorDelegate<TOutput> listConstructorDelegate)
        {
            throw new NotImplementedException();
        }

        public static void ForEach(IList<TValue> list, ActionDelegate<TValue> actionDelegate)
        {
            throw new NotImplementedException();
        }

        public static void Sort(IList<TValue> list, CompareDelegate<TValue> compareDelegate)
        {
            throw new NotImplementedException();
        }

        public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            throw new NotImplementedException();
        }


        public static readonly ListConstructorDelegate<TValue> ArrayListConstructor;
        public static readonly ListConstructorDelegate<TValue> LinkedListConstructor;
    }
}
