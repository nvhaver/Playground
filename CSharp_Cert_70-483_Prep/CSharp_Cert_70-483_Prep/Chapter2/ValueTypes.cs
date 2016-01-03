using System;
using System.Runtime.InteropServices;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    public class ValueTypes
    {
        // ValueTypes implicitly inherit from System.ValueType, which in turn
        // inherits from System.Object (GetHashCode, Equals, and ToString are
        // modified by ValueType).
        // One cannot inherit directly from ValueType but must use "struct"

        // Question: Can structs be used for the implementation of a linked
        // list as the one in the Algorithms project?
        // Answer: As the suggested implementation depends on changing the
        // nodes in the list, the nodes are not immuatble and thus not suited.

        // See also: 
        // https://msdn.microsoft.com/en-us/library/aa288471%28v=vs.71%29.aspx

    }


    /// <summary>
    /// Example of a struct. When to use a struct:
    ///  - The object is small
    ///  - The object is logically immutable
    ///  - There are a lot of objects
    ///  Yet, you still need to check whether using the struct does increase
    ///  performance (either speed or memory), which you need to measure.
    /// </summary>
    public struct Point
    {
        public int x, y;
        
        // Not possible to declare an own empty constructor.


        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct SimpleStruct
    {
        private int xval; // Private field 
        public int X // Property
        {
            get
            {
                return xval;
            }
            set
            {
                if (value < 100)
                    xval = value;
            }
        }
        public void DisplayX() // Method
        {
            Console.WriteLine("The stored value is: {0}", xval);
        }
    }

    // Also not possible to use inheritance with from other structs or 
    // classes (this saves some memory).
    // It is possible to implement an interface using a struct.
    interface IImage
    {
        void Paint();
    }

    struct Picture : IImage
    {
        public void Paint()
        {
            // painting code goes here
        }
        private int x, y, z;  // other struct members
    }

    // C/C++ unions can be simulated through specifying the offset manually. 
    [StructLayout(LayoutKind.Explicit)]
    struct TestUnion
    {
        [FieldOffset(0)]
        public int i;
        [FieldOffset(0)]
        public double d;
        [FieldOffset(0)]
        public char c;
        [FieldOffset(0)]
        public byte b1;
    }

    // Here the offset is not completely overlapping.
    [StructLayout(LayoutKind.Explicit)]
    struct TestExplicit
    {
        [FieldOffset(0)]
        public long lg;
        [FieldOffset(0)]
        public int i1;
        [FieldOffset(4)]
        public int i2;
        [FieldOffset(8)]
        public double d;
        [FieldOffset(12)]
        public char c;
        [FieldOffset(14)]
        public byte b1;
    }
}
