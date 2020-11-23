using System;
using System.Collections.Generic;
using System.Linq;

namespace CatchingCarMileageNumbers
{
    class Program
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            for(int i = number; i <= number + 2; i++)
            {
                if (length(i) < 3)
                    continue;

                if (isFollowedByZeros(i) || isSameDigits(i) || isIncrementing(i) || isDecrementing(i)
                    || isPalindrome(i) || isInList(i, awesomePhrases) || isIncrementingWithZero(i))
                {
                    if (i == number)
                        return 2;
                    return 1;
                }
            }
            return 0;
        }
        public static int length(int number)
        {
            return number.ToString().Length;
        }
        public static bool isFollowedByZeros(int number)
        {
            string s = number.ToString();
            if(s[0] != '0' && s.Length > 1)
            {
                int zeroCounts = s.Count(c => c == '0');
                if (zeroCounts == s.Length - 1)
                    return true;
                
                return false;
            }
            return false;
        }
        public static bool isSameDigits(int number)
        {
            string s = number.ToString();
            
            if (s.Length == 1)
                return true;

            char letter = s[0];
            int letterCount = s.Count(c => c == letter);

            if (letterCount == s.Length)
                return true;

            return false;
        }
        public static bool isPalindrome(int number)
        {
            string s = number.ToString();

            for (int i = 0, j = s.Length - 1 ; i < s.Length / 2; i++, j--)
            {
                if (s[i] != s[j])
                    return false;
            }
            return true;
        }
        public static bool isInList(int number, List<int> l)
        {
            if (l.Contains(number))
                return true;
            return false;
        }
        public static bool isIncrementing(int number)
        {
            string s = number.ToString();

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] >= s[i + 1] || ((s[i + 1] - s[i]) > 1))
                    return false;
            }
            return true;
        }
        public static bool isDecrementing(int number)
        {
            string s = number.ToString();

            for(int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] <= s[i + 1] || ((s[i] - s[i + 1]) > 1))
                    return false;
            }
            return true;
        }
        public static bool isIncrementingWithZero(int number)
        {
            string s = number.ToString();

            if(s.EndsWith('0') && s[s.Length - 2] == '9')
            {
                string substr = s.Substring(0, s.Length - 1);
                return isIncrementing(Int32.Parse(substr));
            }
            return false;
        }
        static void Main(string[] args)
        {
            // "boring" numbers
            Console.WriteLine(IsInteresting(3, new List<int>() { 1337, 256 }));    // 0
            Console.WriteLine(IsInteresting(3236, new List<int>() { 1337, 256 })); // 0
            Console.WriteLine();
            // progress as we near an "interesting" number
            Console.WriteLine(IsInteresting(11207, new List<int>() { }));   // 0
            Console.WriteLine(IsInteresting(11208, new List<int>() { }));   // 0
            Console.WriteLine(IsInteresting(11209, new List<int>() { }));   // 1
            Console.WriteLine(IsInteresting(11210, new List<int>() { }));   // 1
            Console.WriteLine(IsInteresting(11211, new List<int>() { }));   // 2
            Console.WriteLine();
            // nearing a provided "awesome phrase"
            Console.WriteLine(IsInteresting(1335, new List<int>() { 1337, 256 }));   // 1
            Console.WriteLine(IsInteresting(1336, new List<int>() { 1337, 256 }));   // 1
            Console.WriteLine(IsInteresting(1337, new List<int>() { 1337, 256 }));   // 2
            //Advanced case
            Console.WriteLine(IsInteresting(98, new List<int>() { 1337, 256 }));   // 1
        }
    }
}
