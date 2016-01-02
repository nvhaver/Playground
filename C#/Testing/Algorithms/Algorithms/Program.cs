using Algorithms.DoubleLinkedListType;
using Algorithms.LinkedListType;
using Algorithms.BinaryTreeType;
using System;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            testBinaryTree();
            Console.ReadKey();
        }

        private static void testLinkedList()
        {
            LinkedList<String> list = new LinkedList<String>();
            list.Print();
            list.Add("a");
            list.Add("test");
            list.Add("a");
            list.Add("This");
            list.Add("is");
            list.Add("a");
            list.Add("test");
            list.Add("a");
            list.Print();
            list.RemoveFirst("a");
            list.Print();
            list.RemoveAll("a");
            list.Print();
            list.RemoveFirst("test");
            list.Print();
        }

        private static void testDoubleLinkedList()
        {
            DoubleLinkedList<String> list = new DoubleLinkedList<String>();
            list.Print();
            list.PrintReverse();
            list.Add("a");
            list.Add("test");
            list.Add("a");
            list.Add("This");
            list.Add("is");
            list.Add("a");
            list.Add("test");
            list.Add("a");
            list.Print();
            list.PrintReverse();
            list.RemoveFirst("a");
            list.Print();
            list.PrintReverse();
            list.RemoveAll("a");
            list.Print();
            list.PrintReverse();
            list.RemoveFirst("test");
            list.Print();
            list.PrintReverse();
        }

        private static void testBinaryTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.AddRecur(8);
            tree.AddRecur(6);
            tree.AddRecur(4);
            tree.AddRecur(2);
            tree.AddRecur(6);
            tree.AddRecur(9);
            tree.AddRecur(12);
            tree.AddRecur(1);
            tree.AddRecur(15);
            tree.AddRecur(3);
            tree.AddRecur(1);

            tree.Print();
        }
    }
}
