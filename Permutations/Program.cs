using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Permutations
{
    class Program
    {
        public static List<string> SinglePermutations(string s)
        {
            SortedSet<string> ss = new SortedSet<string>();

            int len = s.Length;
            permute(s, 0, len - 1, ref ss);
            if (ss.Count > 0)
            {
                List<string> l = ss.ToList();
                return l;
            }
            return null;
        }

        public static void permute(String str, int l, int r, ref SortedSet<string> s)
        {
            if (l == r)
            {
                if (!s.Contains(str))
                {
                    s.Add(str);
                }
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r, ref s);
                    str = swap(str, l, i);
                }
            }
        }
        public static String swap(String a,
                                        int i, int j)
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
            /*
             * Test cases
            //Test 1
            Assert.AreEqual(new List<string> { "a" }, SinglePermutations("a").OrderBy(x => x).ToList());
            
            //Test 2
            Assert.AreEqual(new List<string> { "ab", "ba" }, SinglePermutations("ab").OrderBy(x => x).ToList());
            
            //Test 3
            Assert.AreEqual(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, SinglePermutations("aabb").OrderBy(x => x).ToList());
            */
         }
    }
}
