using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections
{
    class OutOfBoundException : ListException
    {
        public OutOfBoundException(string message) : base(message)
        {
        }

        public static void CheckForBound(int index, int length)
        {
            if ((index > length) || (index < 0))
            {
                throw new OutOfBoundException(index + "the index is out of list range");
            }
        }
    }
}
