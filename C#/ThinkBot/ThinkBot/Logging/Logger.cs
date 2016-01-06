using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Logging
{
    static class Logger
    {

        private static void WriteToLogfile(string log)
        {
            // Write a log into the logging file, when this happens, the database should also be updated to reflect this change.
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) +"   "+ log);
        }

        internal static void LogNameChange(int id, string newName)
        {
            WriteToLogfile("Dude " + id + " received a namechange to : " + newName);
        }

        internal static void WriteAnnouncementLog(string arg)
        {
            WriteToLogfile(arg);
        }

        internal static void WriteVisibleLog(int id, bool visible)
        {
            WriteToLogfile("Dude "+id+" visible= "+visible);
        }

        internal static void WriteMovespeedChangeLog(int id, int movementSpeed)
        {
            WriteToLogfile("Dude " + id + "'s movementspeed is set to " + movementSpeed);
        }

        internal static void WritePriorityLog(int id, string place)
        {
            WriteToLogfile("Dude " + id + " is going to " + place);
        }

        internal static void WriteActivityLog(int id, String activity)
        {
            WriteToLogfile("Dude " + id + activity);
        }
    }
}
