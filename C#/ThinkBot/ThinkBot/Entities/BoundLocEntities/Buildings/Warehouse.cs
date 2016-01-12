using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.BoundLocEntities.Buildings
{
    class Warehouse : Building
    {
        public int Resources { get; set; }

        public Warehouse(Location location, LocationBlock spawnBlockLocation, String name):base(location, spawnBlockLocation, name)
        {
            Resources = 0;
        }

        internal void AddResource(int v)
        {
            Resources++;
        }

        public override string ToString()
        {
            return (base.ToString() + " " + Resources);
        }
    }
}
