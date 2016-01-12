using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Building
    {
        public Location Location { get; set; }
        public String Name { get; set; }
        public Spawn Spawn { get; set; }

        public Building()
        {
            Name = "Nonplaced";
        }

        public Building(Location location, LocationBlock spawnBlockLocation, String name)
        {
            Location = location;
            Name = name;
            Spawn = new Spawn(spawnBlockLocation);
        }

        public virtual void EnterBuilding(Dude dude)
        { // put a dude in a spawn and assign the spawn in the dude
            Spawn.EnterSpawn(dude);
            dude.Spawn = Spawn;
        }

        public virtual void LeaveBuilding(Dude dude)
        {
            Spawn.LeaveSpawn(dude);
        }

        new public virtual String ToString()
        {
            return Name;
        }
    }
}
