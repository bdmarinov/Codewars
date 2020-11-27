using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GapInPrimes
{
    class Program
    {
        public static long[] Gap(int g, long m, long n)
        {
            var s = getPrimesInDist(m, n);
            foreach (var item in s)
            {
                if (s.Contains(item + g))
                {
                    var sel = s.Where(x => (x < item + g && x > item));
                    if (sel.Count() == 0)
                    {
                        return new long[] { item, item + g };
                    }
                }
            }
            return null;
        }
        public static SortedSet<long> getPrimesInDist(long m, long n)
        {
            SortedSet<long> s = new SortedSet<long>();

            for (long i = m; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    s.Add(i);
                }
            }

            return s;
        }
        public static bool IsPrime(long number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            long root = (long)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Assert.AreEqual(new long[] { 101, 103 }, Gap(2, 100, 110));
            Assert.AreEqual(new long[] { 103, 107 }, Gap(4, 100, 110));
            Assert.AreEqual(null, Gap(6, 100, 110));
            Assert.AreEqual(new long[] { 359, 367 }, Gap(8, 300, 400));
            Assert.AreEqual(new long[] { 337, 347 }, Gap(10, 300, 400));
        }
    }
}
