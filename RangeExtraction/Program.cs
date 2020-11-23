using System;

namespace RangeExtraction
{
    class Program
    {
        public static string getExtracted(int cur, int last, int count)
        {
            string s = "";

            if (count >= 3)
            {
                s += cur;
                s += '-';
                s += last;
            }
            if (count == 2)
            {
                s += cur;
                s += ',';
                s += last;
            }
            if (count == 1)
            {
                s += cur;
            }
            return s;
        }

        public static string Extract(int[] args)
        {
            if (args.Length == 0)
            {
                return "";
            }
            if (args.Length == 1)
            {
                return args[0].ToString();
            }

            int first = args[0], last = args[0];
            int count = 1;
            int cur = args[0];

            string s = "";

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] - 1 == first)
                {
                    count++;
                    first = args[i];
                }
                else
                {
                    last = args[i - 1];

                    s += getExtracted(cur, last, count);
                    s += ',';

                    first = args[i];
                    cur = first;
                    count = 1;
                }
                if (i == args.Length - 1)
                {
                    last = args[i];

                    s += getExtracted(cur, last, count);
                }

            }
            return s;
        }
        static void Main(string[] args)
        {
            //Test Case 1
            Console.WriteLine("1,2" == Extract(new[] { 1, 2 }));

            //Test Case 2
            Console.WriteLine("1-3" == Extract(new[] { 1, 2, 3 }));

            //Test Case 3
            Console.WriteLine("-6,-3-1,3-5,7-11,14,15,17-20" == 
                Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 }));

            //Test Case 4
            Console.WriteLine("-3--1,2,10,15,16,18-20" == 
                Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 }));
        }
    }
}
