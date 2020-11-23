using System;
using System.Collections.Generic;

namespace AddingBigNumbers
{
    class Program
    {
        public static string Add(string a, string b)
        {
            if (a.Length == 0)
            {
                return b;
            }
            if (b.Length == 0)
            {
                return a;
            }

            int aLen = a.Length;
            Stack<char> sA = new Stack<char>();

            int bLen = b.Length;
            Stack<char> sB = new Stack<char>();

            for (int i = 0; i < aLen; i++)
            {
                sA.Push(a[i]);
            }

            for (int i = 0; i < bLen; i++)
            {
                sB.Push(b[i]);
            }

            int biggerLen = (aLen > bLen) ? aLen : bLen;

            Stack<string> final = new Stack<string>();

            int denom = 0, remainder = 0;
            for (int i = 0; i < biggerLen; i++)
            {
                int numberA = (sA.Count > 0) ? (sA.Pop() - '0') : 0;
                int numberB = (sB.Count > 0) ? (sB.Pop() - '0') : 0;

                int sum = (denom > 0) ? (numberA + numberB + denom) : (numberA + numberB);
                denom = sum / 10;
                remainder = sum % 10;

                final.Push(remainder.ToString());
            }
            if (denom > 0)
            {
                final.Push(denom.ToString());
            }

            string s = "";
            while (final.Count > 0)
            {
                s += final.Pop();
            }

            return s;
        }
        static void Main(string[] args)
        {
            //Test Case 1
            Console.WriteLine("1057853509440367665682450458794866464501746580388666517943654" == 
                Add("823094582094385190384102934810293481029348123094818923749817", 
                "234758927345982475298347523984572983472398457293847594193837"));

            //Test Case 2
            Console.WriteLine("1222288369471848635431742533238794347796709858386130887087383" ==
                Add("234859234758913759182357398457398474598237459823745928347538",
                "987429134712934876249385134781395873198472398562384958739845"));

            //Test Case 3
            Console.WriteLine("1188027920792406899351871815238255333339717894129824807166673" ==
                Add("854694587458967459867923420398420394845873945734985374844444",
                "333333333333439439483948394839834938493843948394839432322229"));

            //Test Case 4
            Console.WriteLine("1131313130303031311313030303131313121212131313129120030130132" ==
                Add("666666665656566666666565656666666656565666666665656566666666",
                "464646464646464644646464646464646464646464646463463463463466"));

            //Test Case 5
            Console.WriteLine("1823172964260263830982280609675150766951754355882242391698277783797094242179652457248777050585906182180138262963360272327" ==
                Add("987429134712934876249385134781395873198472398562384958739845234859234758913759182357398457398474598237459823745928347538",
                "835743829547328954732895474893754893753281957319857432958432548937859483265893274891378593187431583942678439217431924789"));
        }
    }
}
