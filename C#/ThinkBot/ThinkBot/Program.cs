using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator();
            simulator.Initiate(); // For the moment there will always be a new situation, as the database won't keep track of it yet. 
                                  // In the future the simulation should be an eternal sandbox. Where it only goes offline to receive updates, and then restore everything through the DB.
             

        }
        
    }
}
