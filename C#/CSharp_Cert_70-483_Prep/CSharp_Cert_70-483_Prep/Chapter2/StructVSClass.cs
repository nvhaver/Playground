﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    class StructVSClass
    {
        // This example shows that structs are passed by value whereas class
        // instances are passed by reference.
    }

    class TheClass
    {
        public int x;
    }

    struct TheStruct
    {
        public int x;
    }

    class TestClass
    {
        public static void structtaker(TheStruct s)
        {
            s.x = 5;
        }
        public static void classtaker(TheClass c)
        {
            c.x = 5;
        }
        public static void RunTest()
        {
            TheStruct a = new TheStruct();
            TheClass b = new TheClass();
            a.x = 1;
            b.x = 1;
            structtaker(a);
            classtaker(b);
            Console.WriteLine("a.x = {0}", a.x); // a.x = 1
            Console.WriteLine("b.x = {0}", b.x); // b.x = 5
        }
    }
}
