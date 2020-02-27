using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Collections.Utils
{
    public static class Sorts
    {

        public delegate int CompareDelegate<TValue>(TValue item0, TValue item1);
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            if (!list.Any())
            {
                return Enumerable.Empty<T>();
            }
            var pivot = list.First();
            var smaller = list.Skip(1).Where(item => item.CompareTo(pivot) <= 0).QuickSort();
            var larger = list.Skip(1).Where(item => item.CompareTo(pivot) > 0).QuickSort();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

        public static IEnumerable<TValue> QuickSortWithDelegate<TValue>
            (this IEnumerable<TValue> list, CompareDelegate<TValue> compareDelegate)
        {
            if (!list.Any())
            {
                return Enumerable.Empty<TValue>();
            }
            var pivot = list.First();
            var smaller = list.Skip(1).Where(item => compareDelegate(item, pivot) <= 0).QuickSortWithDelegate(compareDelegate);
            var larger = list.Skip(1).Where(item => compareDelegate(item, pivot) > 0).QuickSortWithDelegate(compareDelegate);

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }



        public static IEnumerable<TValue> LinqQuickSort<TValue>(this IEnumerable<TValue> list) where TValue : IComparable<TValue>
        {
            return !list.Any() ? Enumerable.Empty<TValue>() : list.Skip(1).Where(
                item => item.CompareTo(list.First()) <= 0).LinqQuickSort().Concat(new[] { list.First() })
                    .Concat(list.Skip(1).Where(item => item.CompareTo(list.First()) > 0).LinqQuickSort());
        }

        public static IEnumerable<TValue> BubbleSort<TValue>(this IEnumerable<TValue> item) where TValue : IComparable<TValue>
        {
            int i, j;
            TValue temp;
            var array = item.ToArray();
            for (i = array.Count() - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        public static IEnumerable<TValue> BubbleSortWithDelegate<TValue>(this IEnumerable<TValue> item, CompareDelegate<TValue> compareDelegate)
        {
            int i, j;
            TValue temp;
            var array = item.ToArray();
            for (i = array.Count() - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (compareDelegate(array[j], array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
        public static IEnumerable<TValue> SelectionSort<TValue>(this IEnumerable<TValue> item) where TValue : IComparable<TValue>
        {
            var list = item.ToList();
            for (int i = 0; i < list.Count() - 1; ++i)
            {
                TValue minElement = list[i];
                int minLocation = i;

                for (int j = i + 1; j < list.Count(); ++j)
                {
                    if (list[j].CompareTo(minElement) < 0)
                    {
                        minElement = list[j];
                        minLocation = j;
                    }
                }

                if (minLocation != i)
                {
                    TValue temp = list[minLocation];
                    list[minLocation] = list[i];
                    list[i] = temp;
                }
            }
            return list;
        }
        public static IEnumerable<TValue> SelectionSortWithDelegate<TValue>(this IEnumerable<TValue> item, CompareDelegate<TValue> compareDelegate)
        {
            var list = item.ToList();
            for (int i = 0; i < list.Count() - 1; ++i)
            {
                TValue minElement = list[i];
                int minLocation = i;

                for (int j = i + 1; j < list.Count(); ++j)
                {
                    if (compareDelegate(list[j], minElement) < 0)
                    {
                        minElement = list[j];
                        minLocation = j;
                    }
                }

                if (minLocation != i)
                {
                    TValue temp = list[minLocation];
                    list[minLocation] = list[i];
                    list[i] = temp;
                }
            }
            return list;
        }

        public static IEnumerable<TValue> InsertionSort<TValue>(this IEnumerable<TValue> item) where TValue : IComparable<TValue>
        {
            int i, j;

            var list = item.ToList();

            for (i = 1; i < list.Count(); i++)
            {
                TValue value = list[i];
                j = i - 1;
                while ((j >= 0) && (list[j].CompareTo(value) > 0))
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = value;
            }
            return list;
        }
        public static IEnumerable<TValue> InsertionSortWithDelegate<TValue>(this IEnumerable<TValue> item, CompareDelegate<TValue> compareDelegate)
        {
            int i, j;

            var list = item.ToList();

            for (i = 1; i < list.Count(); i++)
            {
                TValue value = list[i];
                j = i - 1;
                while ((j >= 0) && (compareDelegate(list[j], value) > 0))
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = value;
            }
            return list;
        }
        public static IEnumerable<TValue> ShellSort<TValue>(this IEnumerable<TValue> item) where TValue : IComparable<TValue>
        {
            var list = item.ToList();

            int h = 1;

            while (h < (list.Count >> 1))
            {
                h = (h << 1) + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < list.Count; i++)
                {
                    int k = i - h;
                    for (int j = i; j >= h && list[j].CompareTo(list[k]) < 0; k -= h)
                    {
                        TValue temp = list[j];
                        list[j] = list[k];
                        list[k] = temp;
                        j = k;
                    }
                }
                h >>= 1;
            }
            return list;
        }


        public static IEnumerable<TValue> ShellSortWithDelegate<TValue>(this IEnumerable<TValue> item, CompareDelegate<TValue> compareDelegate)
        {
            var list = item.ToList();

            int h = 1;

            while (h < (list.Count >> 1))
            {
                h = (h << 1) + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < list.Count; i++)
                {
                    int k = i - h;
                    for (int j = i; j >= h && compareDelegate(list[j], list[k]) < 0; k -= h)
                    {
                        TValue temp = list[j];
                        list[j] = list[k];
                        list[k] = temp;
                        j = k;
                    }
                }
                h >>= 1;
            }
            return list;
        }
    }
}

