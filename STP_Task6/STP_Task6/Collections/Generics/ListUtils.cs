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

        public static bool Exists(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {
            throw new NotImplementedException();
        }

        static TValue Find<TValue>(IList<TValue> list, CheckDelegate<TValue> delegate_func)
        {
            throw new NotImplementedException();
        }

        static TValue FindLast<TValue>(IList<TValue> list, CheckDelegate<TValue> delegete_func)
        {
            throw new NotImplementedException();
        }

        static int FindIndex<T>(IList<T>, CheckDelegate<T>)
        {
            throw new NotImplementedException();
        }

        static int FindLastIndex<T>(IList<T>, CheckDelegate<T>)
        {
            throw new NotImplementedException();
        }
        static IList<T> FindAll<T>(

        IList<T>, CheckDelegate<T>, ListConstructorDelegate<T>)
        {
            throw new NotImplementedException();
        }

        static IList<TO> ConvertAll<TI, TO>(

        IList<TI>, ConvertDelegate<TI, TO>, ListConstructorDelegate<TO>)
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
