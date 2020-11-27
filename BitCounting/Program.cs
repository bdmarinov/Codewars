using System;
using NUnit.Framework;

namespace BitCounting
{
    class Program
    {
        public static int CountBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    count++;
                }
                n /= 2;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Assert.AreEqual(0, CountBits(0));
            Assert.AreEqual(1, CountBits(4));
            Assert.AreEqual(3, CountBits(7));
            Assert.AreEqual(2, CountBits(9));
            Assert.AreEqual(2, CountBits(10));
        }
    }
}
