using System;
using System.Collections.Generic;
using System.Linq;

namespace TwiceLinear
{
    class Program
    {
        public static int DblLinear(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            SortedSet<int> ss = new SortedSet<int>();
            List<int> l = new List<int>();

            l.Add(1);
            ss.Add(1);

            int x = 0, y = 0;

            for (int i = 0; i < n; i++)
            {
                int first = 2 * l[x] + 1;
                int second = 3 * l[y] + 1;

                if (first <= second)
                {
                    if (!ss.Contains(first))
                    {
                        ss.Add(first);
                        l.Add(first);
                        x++;
                        if (first == second)
                        {
                            y++;
                        }
                    }
                }
                else
                {
                    if (!ss.Contains(second))
                    {
                        ss.Add(second);
                        l.Add(second);
                        y++;
                    }

                }
            }

            return l[n];
        }
        static void Main(string[] args)
        {
            //Test Case 1
            Console.WriteLine(DblLinear(10) == 22);

            //Test Case 2
            Console.WriteLine(DblLinear(20) == 57);

            //Test Case 3
            Console.WriteLine(DblLinear(30) == 91);

            //Test Case 4
            Console.WriteLine(DblLinear(50) == 175);
        }
    }
}
