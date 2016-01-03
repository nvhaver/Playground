using System;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    /// <summary>
    /// This class focusses on the unsafe keyword. This keyword allows pointer
    /// arithmetic and removes array bounds checks, which may improve 
    /// performance. It does however incur a security and stability risk.
    /// This way buffer overflows are possible and pointers to native code can
    /// be used. In short, be careful with this one!
    /// More information on this keyword can be found on:
    /// https://msdn.microsoft.com/en-us/library/chfa2zb8.aspx
    /// </summary>
    public class Unsafe
    {
        /// <summary>
        /// Note that the /unsafe compiler flag needs to be specified to use
        /// the unsafe keyword. This is done in the Project settings > build.
        /// Here we simply increment the value passed by its pointer.
        /// </summary>
        public unsafe static void IncrementPointer(int* pointer)
        {
            (*pointer)++;
        }

        /// <summary>
        /// Perform the above method with some value and print the results.
        /// </summary>
        public static void ContainsUnsafe()
        {
            int i = 5;
            unsafe
            {
                // Unsafe context in which pointers can be used.
                IncrementPointer(&i);
            }
            Console.WriteLine(i);
        }
    }
}
