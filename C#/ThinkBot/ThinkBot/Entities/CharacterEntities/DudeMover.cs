using ThinkBot.Entities.BoundLocEntities;
using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThinkBot.Logging;

namespace ThinkBot.Entities.CharacterEntities
{
    public static class DudeMover
    {
		public static void MoveTo(Location targetLoc, Dude dude)
        {
				/* this class was used to move in a dumb way, and it didn't work.
				   This class should be made so it can be implemented by other classes ;)
				   This should give them the ability to move through landscapes with realistic pathfinding and line of sight walking
				
				   Rethink the entire system how entities are placed, generate impenetrable areas
				   Implement Theta* for the pathfinding. 
				*/
        }
      
    }
}
