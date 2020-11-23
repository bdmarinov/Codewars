using System;
using System.Collections.Generic;

namespace DoubleCola
{
    class Program
    {
        public static string WhoIsNext(string[] names, long n)
        {
            if (n <= names.Length)
            {
                return names[n - 1];
            }

            int row = 1;
            long line = 1, size = names.Length, maxIndex = 0;

            List<long> l = new List<long>();

            while (line * size <= n)
            {
                maxIndex = maxIndex + line * size;
                l.Add(maxIndex);
                line *= 2;
                if (line * size <= n)
                {
                    row++;
                }
            }

            if (maxIndex < n)
            {
                row++;
                maxIndex = maxIndex + line * size;
                l.Add(maxIndex);
            }

            long lower = l[row - 2], higher = l[row - 1];

            long diff = n - lower;
            long interval = higher - lower;
            long maxEach = interval / size;
            long defaultIndex = 0;

            for (long i = 1; i <= interval; i++)
            {
                if (i == diff)
                {
                    break;
                }
                if (i % maxEach == 0 && i != interval)
                {
                    defaultIndex++;
                }
            }

            return names[defaultIndex];
        }
        static void Main(string[] args)
        {
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            
            //Test Case 1
            Console.WriteLine("Sheldon" == WhoIsNext(names, 1));

            //Test Case 2
            Console.WriteLine("Leonard" == WhoIsNext(names, 28643950));

            //Test Case 3
            Console.WriteLine("Penny" == WhoIsNext(names, 1000000000));

            //Test Case 4
            Console.WriteLine("Howard" == WhoIsNext(names, 159222638));

            //Test Case 5
            Console.WriteLine("Penny" == WhoIsNext(names, 121580142));
        }
    }
}
