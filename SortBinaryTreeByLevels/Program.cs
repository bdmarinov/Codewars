using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SortBinaryTreeByLevels
{
    class Program
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public int Value;

            public Node(Node l, Node r, int v)
            {
                Left = l;
                Right = r;
                Value = v;
            }
        }
        public static List<int> TreeByLevels(Node node)
        {
            if (node == null)
            {
                return new List<int>();
            }
            Queue<Node> q = new Queue<Node>();
            List<int> l = new List<int>();

            q.Enqueue(node);

            //Console.WriteLine(q.Count);

            while (q.Count > 0)
            {
                Node cur = q.Dequeue();

                l.Add(cur.Value);
                if (cur.Left != null)
                {
                    q.Enqueue(cur.Left);
                }
                if (cur.Right != null)
                {
                    q.Enqueue(cur.Right);
                }
            }
            return l;
        }
        static void Main(string[] args)
        {
            Assert.AreEqual(new List<int>(), TreeByLevels(null));
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }, TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)));
        }
    }
}
