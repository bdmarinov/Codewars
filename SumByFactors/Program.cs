using System;
using System.Collections.Generic;
using System.Linq;

namespace SumByFactors
{
    class Program
    {
        public static SortedSet<int> primeFactors(int n)
        {
            if (n < 0)
            {
                n = -n;
            }

            SortedSet<int> s = new SortedSet<int>();
            bool half = false;

            while (n % 2 == 0)
            {
                half = true;
                n /= 2;
            }

            if (half == true)
            {
                s.Add(2);
            }

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    if (!s.Contains(i))
                    {
                        s.Add(i);
                    }
                    n /= i;
                }
            }
            if (n > 2)
            {
                s.Add(n);
            }
            return s;
        }

        public static string sumOfDivided(int[] lst)
        {
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < lst.Length; i++)
            {
                SortedSet<int> s = primeFactors(lst[i]);
                foreach (var item in s)
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item].Add(lst[i]);
                    }
                    else
                    {
                        List<int> l = new List<int>();
                        l.Add(lst[i]);
                        dict.Add(item, l);
                    }
                }
            }

            string str = "";

            foreach (var item in dict)
            {
                str += "(";
                str += item.Key.ToString();
                str += " ";

                str += item.Value.Sum().ToString();
                str += ")";
            }

            return str;
        }
        static void Main(string[] args)
        {
            //Test Case 1
            Console.WriteLine("(2 12)(3 27)(5 15)" == sumOfDivided(new int[] { 12, 15 }));

            //Test Case 2
            Console.WriteLine("(2 -61548)(3 -4209)(5 -28265)(23 -4209)(31 -31744)(53 -72769)(61 -4209)(1373 -72769)(5653 -28265)(7451 -29804)" 
                == sumOfDivided(new int[] { -29804, -4209, -28265, -72769, -31744 }));

            //Test Case 3
            Console.WriteLine("(2 1032)(3 453)(5 310)(7 126)(11 110)(17 204)(29 116)(41 123)(59 118)(79 158)(107 107)"
                == sumOfDivided(new int[] { 107, 158, 204, 100, 118, 123, 126, 110, 116, 100 }));

            //Test Case 4
            Console.WriteLine("(2 1100000)(5 1100000)"
                == sumOfDivided(new int[] { 100000, 1000000 }));
        }
    }
}
