using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.BoundLocEntities
{
    // Has to be rewritten to be a collection of blocks.
    public class Location
    {
        public List<LocationBlock> blocks = new List<LocationBlock>();


        public Location(List<LocationBlock> locationBlocks)
        {
            blocks = locationBlocks;
        }

        public override string ToString()
        {
            String returnString = "";

            foreach (LocationBlock block in blocks)
            {
                returnString += block.ToString() + "\n";
            }

            return returnString;
        }

    }
}
