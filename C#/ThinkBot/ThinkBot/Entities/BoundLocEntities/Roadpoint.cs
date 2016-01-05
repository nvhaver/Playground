using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Roadpoint : IConnectable
    {
        public Location BeginLocation { get; }
        public Location EndLocation { get; }

        public Roadpoint(Location beginLoc, Location endLoc)
        {   // makes a roadpoint between 2 locations. endLoc should always be the connection to a building, not beginLoc.
            BeginLocation = beginLoc;
            EndLocation = endLoc;
        }
        


    }
}
