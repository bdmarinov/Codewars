using System;
using System.Collections.Generic;

namespace NumberZooPatrol
{
    class Program
    {
        public static int FindNumber(int[] array)
        {
            HashSet<int> hs = new HashSet<int>();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                hs.Add(array[i]);
            }
            n = n + 1;
            for (int i = 1; i <= n; i++)
            {
                if (!hs.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(FindNumber(new int[] { 1, 3, 4, 5, 6, 7, 8 })); //Should return 2
            Console.WriteLine(FindNumber(new int[] { 7, 8, 1, 2, 4, 5, 6 })); //Should return 3
            Console.WriteLine(FindNumber(new int[] { 1, 2, 3, 5 })); //Should return 4
            Console.WriteLine(FindNumber(new int[] { 2, 3, 4 })); //Should return 1
            Console.WriteLine(FindNumber(new int[] { 13, 11, 10, 3, 2, 1, 4, 5, 6, 9, 7, 8 })); //Should return 12
        }
    }
}
