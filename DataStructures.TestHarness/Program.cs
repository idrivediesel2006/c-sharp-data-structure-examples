using System;
using DataStructures.Binary;

namespace DataStructures.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Binary Tree");
            BinaryTree bt = new BinaryTree();
            bt.Add(10);
            bt.Add(5);
            bt.Add(15);
            bt.Add(7);
            bt.Add(17);
            bt.Add(3);
            bt.Add(13);
        }
    }
}
