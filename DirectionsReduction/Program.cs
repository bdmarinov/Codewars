using System;
using System.Collections.Generic;

namespace DirectionsReduction
{
    class Program
    {
        public static string[] dirReduc(String[] arr)
        {
            Stack<string> s = new Stack<string>();

            if (arr.Length > 0)
            {
                s.Push(arr[0]);
            }

            for (int i = 1; i < arr.Length; i++)
            {
                if (s.Count > 0)
                {
                    string top = s.Peek();
                    string cur = arr[i];

                    int value = getDifference(top, cur);
                    if (value == 0)
                    {
                        s.Pop();
                    }
                    else
                    {
                        s.Push(cur);
                    }
                }
                else
                {
                    s.Push(arr[i]);
                }
            }

            string[] str = s.ToArray();
            Array.Reverse(str, 0, str.Length);

            return str;
        }

        public static int getDifference(string str1, string str2)
        {
            return (getValue(str1) + getValue(str2));
        }

        public static int getValue(string str)
        {
            switch (str)
            {
                case "NORTH": return -1;
                case "SOUTH": return 1;
                case "WEST": return -2;
                case "EAST": return 2;
            }
            return 0;
        }

        public static bool areEqual(string[] a, string[] b)
        {
            if(a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            //Test case 1
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };
            Console.WriteLine(areEqual(b, dirReduc(a)));

            //Test case 2
            a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            Console.WriteLine(areEqual(b, dirReduc(a)));
        }
    }
}
