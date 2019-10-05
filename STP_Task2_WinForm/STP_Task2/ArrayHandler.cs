using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task2
{
    class ArrayHandler
    {
        public int[] Array { get; private set; } 

        public ArrayHandler(int[] arrayArg)
        {
            this.Array = arrayArg;
        }

        public bool CheckSequence()
        {
            if(Array.Last() == 0)
            {
                return false;
            }

            for(int i = 0; i < Array.Length - 1; i++)
            {
                if((Array[i] > 0 && Array[i+1] > 0 ) || (Array[i] < 0 && Array[i + 1] < 0) || Array[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
