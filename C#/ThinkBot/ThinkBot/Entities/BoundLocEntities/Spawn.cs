using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Spawn : IConnectable
    {
        public Location Location { get; set; }
        public HashSet<Dude> DudesInside { get; set; }


        public Spawn(Location location)
        { // makes a new spawn at a given location
            Location = location;
            DudesInside = new HashSet<Dude>();
        }

        public Spawn(double x, double y)
        { // makes a new spawn at given coordinates
            Location = new Location(x, y);
            DudesInside = new HashSet<Dude>();
        }

        public void EnterSpawn(Dude dude)
        { // Makes a dude "enter" the spawn. Makes him invisible untill he leaves.
          // Given dude is stored in the hashset.
          // use this through the building this spawn is attached to
            dude.DeSpawnDude();
            DudesInside.Add(dude);
        }

        public void LeaveSpawn(Dude dude)
        { // Makes a dude "leave" the spawn. Makes him visible when he leaves.
          // Given dude is removed from the hashset.
          // use this through the building this spawn is attached to
            dude.SpawnDude();
            DudesInside.Remove(dude);
            dude.Spawn = null;
        }
    }
}
