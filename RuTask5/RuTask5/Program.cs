using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuTask5
{
    class Program
    {
        private static int currentPower_a = 4;

        private static int requiredPower_b = 10;

        private static readonly int SIGNAL_X = 1;

        private static readonly int SIGNAL_Y = 2;

        private static readonly int BAD_POWER_C = 3;
        public static void incFromCurrentToRequired(int current, int required)
        {
            int increasable = current;

            int counter = 0;

            while(true)
            {
                if (((increasable + 2) % BAD_POWER_C == 0) || ((increasable + 2) > required))
                {
                    increasable += SIGNAL_X;
                    Console.WriteLine("Power increased by +1");
                }
                else
                {
                    increasable += SIGNAL_Y;
                    Console.WriteLine("Power increased by +2");
                }

                counter++;
                Console.WriteLine("Current Power: {0}", increasable);
                if(increasable == required)
                {
                    Console.WriteLine("============================");
                    Console.WriteLine("Need Commands: {0}", counter);
                    break;
                }
            }
        }


        static void Main(string[] args)
        {

            incFromCurrentToRequired(currentPower_a, requiredPower_b);
            Console.Read();
        }
    }
}
