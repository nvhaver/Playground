using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    class Enums
    {
        public enum Gender { Male, Female };
        public enum Days : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };


        // Flags attribute indicates bitwise operations to compose options.
        // Actually it only provides a clean .ToString().
        // If the values (which do not need to be hex) are omitted, the flags
        // are useless as they are incremented from 0.
        [Flags]
        public enum DayFlags {
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        public static void DaysOperation()
        {
            foreach (Days day in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine($"{Pad((byte)day)} : {day}");
                if ((byte)day == 1)
                {
                    Console.WriteLine("Saturday!!!");
                }
            }
        }

        public static void DayFlagsOperation()
        {
            DayFlags weekend = DayFlags.Saturday | DayFlags.Sunday;
            Console.WriteLine($"Weekend days: {weekend}");
            foreach (DayFlags day in Enum.GetValues(typeof(DayFlags)))
            {
                Console.WriteLine($"{Pad((byte)day)} : {day}");
                if ((day & weekend) == day)
                {
                    Console.WriteLine("Weekend!!!");
                }
                if (weekend.HasFlag(day))
                {
                    Console.WriteLine("Indeed weekend!");
                }
            }
        }

        private static String Pad(byte toPad)
        {
            return Convert.ToString(toPad, 2).PadLeft(8, '0');
        }
    }
}
