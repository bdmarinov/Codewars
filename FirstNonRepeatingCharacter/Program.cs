using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstNonRepeatingCharacter
{
    class Program
    {
        public static string FirstNonRepeatingLetter(string s)
        {
            int len = s.Length;

            if (len == 0)
            {
                return "";
            }
            if (len == 1)
            {
                return s;
            }

            HashSet<char> hs = removeDuplicates(s);
            if (hs.Count() == 0)
            {
                return "";
            }

            for (int i = 0; i < len; i++)
            {
                char c = char.ToLower(s[i]);
                if (hs.Contains(c))
                {
                    return s[i].ToString();
                }
            }
            return "";
        }

        static HashSet<char> removeDuplicates(string s)
        {
            string copyS = s.ToLower();
            int len = copyS.Length;

            int max = copyS.Max();
            int[] indexes = new int[max + 1];

            for (int i = 0; i < len; i++)
            {
                int cur = copyS[i];
                indexes[cur]++;
            }

            HashSet<char> hs = new HashSet<char>();

            for (int i = 0; i < indexes.Count(); i++)
            {
                if (indexes[i] == 1)
                {
                    hs.Add((char)i);
                }
            }

            return hs;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("a" == FirstNonRepeatingLetter("a"));
            Console.WriteLine("t" == FirstNonRepeatingLetter("stress"));
            Console.WriteLine("e" == FirstNonRepeatingLetter("moonmen"));
            Console.WriteLine("," == FirstNonRepeatingLetter("Go hang a salami, I'm a lasagna hog!"));
            Console.WriteLine("ﬁ" == FirstNonRepeatingLetter("∞§ﬁ›ﬂ∞§"));
            Console.WriteLine("T" == FirstNonRepeatingLetter("sTreSS"));
        }
    }
}
