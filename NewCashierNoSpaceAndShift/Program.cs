using System;
using System.Text.RegularExpressions;

namespace NewCashierNoSpaceAndShift
{
    class Program
    {
        public static string GetOrder(string input)
        {
            string[] menu = {"Burger", "Fries", "Chicken", "Pizza", "Sandwich", "Onionrings",
                       "Milkshake", "Coke"};

            string s = "";

            for (int i = 0; i < menu.Length; i++)
            {
                for (int j = 0; j < Regex.Matches(input, menu[i].ToLower()).Count; j++)
                {
                    s += menu[i];
                    s += " ";
                }
            }

            if (s.EndsWith(" "))
            {
                return s.Remove(s.Length - 1);
            }

            return s;
        }

        static void Main(string[] args)
        {
            string a, b;
            a = "Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke";
            b = GetOrder("milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza");
            Console.WriteLine(a.Equals(b));

            a = "Burger Fries Fries Chicken Pizza Sandwich Milkshake Coke";
            b = GetOrder("pizzachickenfriesburgercokemilkshakefriessandwich");

            Console.WriteLine(a.Equals(b));
        }
    }
}
