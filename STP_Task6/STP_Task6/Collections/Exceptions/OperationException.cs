using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections.Exceptions
{
    public class OperationException : ListException
    {
        public OperationException(string message) : base(message)
        {
        }
    }
}
