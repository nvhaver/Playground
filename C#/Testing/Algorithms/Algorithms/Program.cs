using Algorithms.LinkedListType;
using System;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            testLinkedList();
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
    }
}
