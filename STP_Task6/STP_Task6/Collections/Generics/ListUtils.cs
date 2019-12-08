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

        static int FindLastIndex<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            throw new NotImplementedException();
        }
        static IList<TValue> FindAll<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func, ListConstructorDelegate<TValue> listConstructorDelegate)
        {
            throw new NotImplementedException();
        }

        static IList<TOutput> ConvertAll<TInput, TOutput>(IList<TInput> list, ConvertDelegate<TInput, TOutput> convertDelegate, ListConstructorDelegate<TOutput> listConstructorDelegate)
        {
            throw new NotImplementedException();
        }

        static void ForEach(IList<TValue>, ActionDelegate<TValue>)
        {
            throw new NotImplementedException();
        }

        static void Sort(IList<TValue>, CompareDelegate<TValue>)
        {
            throw new NotImplementedException();
        }

        static bool CheckForAll<T>(IList<T>, CheckDelegate<T>)
        {
            throw new NotImplementedException();
        }


        static readonly ListConstructorDelegate<TValue> ArrayListConstructor { get; }
        static readonly ListConstructorDelegate<TValue> LinkedListConstructor { get; }


    }
}
