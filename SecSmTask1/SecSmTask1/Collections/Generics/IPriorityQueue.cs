using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Collections.Generics
{
    public interface IPriorityQueue<TValue>
    {
        int Count { get; }
        TValue TopItem { get; }

        TValue Remove();
        TValue Top();
        void Add(TValue value);
        
    }
}
