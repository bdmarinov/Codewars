using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        public static bool ValidParentheses(string input)
        {
            if (input.Length >= 1)
            {
                Stack<char> s = new Stack<char>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(')
                    {
                        s.Push('(');
                    }
                    if (input[i] == ')')
                    {
                        if (s.Count == 0)
                        {
                            return false;
                        }
                        s.Pop();
                    }
                }
                if (s.Count == 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ValidParentheses("()")); //Should print true
            Console.WriteLine(ValidParentheses(")(()))")); //Should print false
            Console.WriteLine(ValidParentheses("(")); //Should print false
            Console.WriteLine(ValidParentheses("(())((()())())")); //Should print true
            Console.WriteLine(ValidParentheses("((()()))")); //Should print true
        }
    }
}
