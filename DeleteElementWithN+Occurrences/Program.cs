using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DeleteElementWithN_Occurrences
{
    class Program
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            int maxElement = arr.Max();

            int[] counter = new int[maxElement + 1];
            List<int> l = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                counter[number]++;
                if (counter[number] <= x)
                {
                    l.Add(number);
                }
            }

            return l.ToArray();
        }
        static void Main(string[] args)
        {
            /*
            //Test Case 1
            Assert.AreEqual(new int[] { 1, 1, 3, 3, 7, 2, 2, 2 },
                DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3));
            */
        }
    }
}
