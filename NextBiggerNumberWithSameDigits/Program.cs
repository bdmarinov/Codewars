using System;
using System.Collections.Generic;

namespace NextBiggerNumberWithSameDigits
{
    class Program
    {
        public static long NextBiggerNumber(long n)
        {
            string str = n.ToString();

            int len = str.Length;
            int index;

            for (index = len - 1; index > 0; index--)
            {
                if (str[index] > str[index - 1])
                {
                    break;
                }
            }

            if (index == 0)
            {
                return -1;
            }

            int minIndex = index;

            for (int i = len - 1; i >= index + 1; i--)
            {
                if (str[i] > str[index - 1] && str[i] < str[minIndex])
                {
                    minIndex = i;
                }
            }

            str = swap(str, index - 1, minIndex);

            char[] arr = str.ToCharArray();
            Array.Sort(arr, index, len - index);

            return Int64.Parse(arr);
        }
        public static String swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(NextBiggerNumber(12)); //Should print 21
            Console.WriteLine(NextBiggerNumber(513)); //Should print 531
            Console.WriteLine(NextBiggerNumber(2017)); //Should print 2071
            Console.WriteLine(NextBiggerNumber(414)); //Should print 441
            Console.WriteLine(NextBiggerNumber(144)); //Should print 414
        }
    }
}
