using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Collections.Collections.Utils.Sorts;

namespace Collections.Collections.Utils
{
    public static class Searches
    {
        public static int BinarySearch<TValue>(this IEnumerable<TValue> enumerable, TValue searchFor, CompareDelegate<TValue> comparer)
        {
            int high, low, mid;
            high = enumerable.Count() - 1;
            low = 0;
            if (enumerable.ElementAt(0).Equals(searchFor))
            {
                return 0;
            }
            else if (enumerable.ElementAt(high).Equals(searchFor))
            {
                return high;
            }
            else
            {
                while (low <= high)
                {
                    mid = (high + low) / 2;
                    if (comparer(enumerable.ElementAt(mid), searchFor) == 0)
                    {
                        return mid;
                    }
                    else if (comparer(enumerable.ElementAt(mid), searchFor) > 0)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                return -1;
            }
        }
    }
}
