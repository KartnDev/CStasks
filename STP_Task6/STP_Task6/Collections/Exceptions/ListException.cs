using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6.Collections
{
    public class ListException : Exception
    {
        public ListException(string message) : base(message + Environment.NewLine +"List throws Exception... Check StackTrace for more information about exception..")
        {
        }
    }
}
