using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuTask7
{
    class Program
    {

        public static object getLowestValueInHashmapAndReturnKey(Dictionary<int, int> hashtable)
        {
            int highest = 0;
            int LowestKey = 0;
            int iterator = 0;
            foreach (var item in hashtable)
            {
                if (iterator > 0)
                {
                    highest = item.Value;
                    LowestKey = item.Key;
                    break;
                }
            }
            iterator = 0;
            foreach (var item in hashtable)
            {
                
                if(highest < item.Value && iterator > 0)
                {
                    highest = item.Value;
                    LowestKey = item.Key;
                }
                iterator++;
            }


           return LowestKey;
        }


        public static void Foo(List<int> args)
        {
            int N = args[0];

            Dictionary<int, int> verse = new Dictionary<int, int>();

            foreach(int item in args)
            {
                if (!verse.ContainsKey(item))
                {
                    verse.Add(item, 1);
                }
                else
                {
                    verse[item] += 1;
                }
            }
            Console.WriteLine("Нужно выгнать: {0}", getLowestValueInHashmapAndReturnKey(verse));

        }

        static void Main(string[] args)
        {

            Foo(new List<int> { 3, 2, -1, 2 });
            Console.ReadLine();

        }
    }
}
