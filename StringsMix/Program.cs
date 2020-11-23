using System;
using System.Collections.Generic;
using System.Linq;

namespace StringsMix
{
    class Program
    {
        public static string Mix(string s1, string s2)
        {
            int[] s1Each = new int[27];
            int[] s2Each = new int[27];

            for (int i = 0; i < s1.Length; i++)
            {
                int cur = s1[i] - 96;
                if (cur >= 1 && cur <= 26)
                {
                    s1Each[cur]++;
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                int cur = s2[i] - 96;
                if (cur >= 1 && cur <= 26)
                {
                    s2Each[cur]++;
                }
            }

            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 1; i < 27; i++)
            {
                char c = (char)(i + 96);
                int a = s1Each[i], b = s2Each[i];

                if (a > b)
                {
                    dict.Add(c, a);
                }
                else if (b > a)
                {
                    dict.Add(c, b);
                }
                else if (a == b && a > 0)
                {
                    dict.Add(c, a);
                }
            }

            Dictionary<string, int> final = new Dictionary<string, int>();

            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                int occur = item.Value;
                int letter = item.Key - 96;

                string first = "";
                int second;

                if (occur > 1)
                {
                    if (s1Each[letter] == occur && s2Each[letter] == occur)
                    {
                        second = 3;
                    }
                    else if (s1Each[letter] == occur)
                    {
                        second = 1;
                    }
                    else
                    {
                        second = 2;
                    }

                    for (int i = 0; i < occur; i++)
                    {
                        first += item.Key;
                    }
                    final.Add(first, second);
                }
            }

            string s = "";

            foreach (var item in final.OrderByDescending(y => y.Key.Length).ThenBy(x => x.Value))
            {
                if (item.Value < 3)
                {
                    s = s + item.Value + ":";
                }
                else
                {
                    s = s + "=:";
                }
                s += item.Key;
                s += "/";
            }

            int len = s.Length;
            if (len == 0)
            {
                return "";
            }
            return s.Remove(len - 1);
        }
        static void Main(string[] args)
        {
            //Test Case 1
            Console.WriteLine("2:eeeee/2:yy/=:hh/=:rr" == Mix("Are they here", "yes, they are here"));

            //Test Case 2
            Console.WriteLine("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg" ==
                    Mix("looping is fun but dangerous", "less dangerous than coding"));

            //Test Case 3
            Console.WriteLine("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt" ==
                    Mix(" In many languages", " there's a pair of functions"));

            //Test Case 4
            Console.WriteLine("1:ee/1:ll/1:oo" == Mix("Lords of the Fallen", "gamekult"));

            //Test Case 5
            Console.WriteLine("" == Mix("codewars", "codewars"));

            //Test Case 6
            Console.WriteLine("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr" == 
                Mix("A generation must confront the looming ", "codewarrs"));
        }
    }
}
