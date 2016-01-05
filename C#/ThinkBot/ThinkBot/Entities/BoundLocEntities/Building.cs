using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Building : IConnectable
    {
        public Location Location { get; set; }
        public String Name { get; set; }
        public Roadpoint Roadpoint { get; set; }
        public Spawn Spawn { get; set; }

        public Building()
        {
            Name = "Nonplaced";
        }

        public Building(Location location, String name)
        {
            Location = location;
            Name = name;
            Spawn = new Spawn(location);
        }

        public virtual void AddRoadpoint(Location location)
        {
            Roadpoint = new Roadpoint(location, Location);
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
            return Name + " " + Location.ToString();
        }
    }
}
