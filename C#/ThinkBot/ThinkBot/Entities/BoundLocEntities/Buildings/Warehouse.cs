using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Entities.BoundLocEntities.Buildings
{
    class Warehouse : Building
    {
        public int Resources { get; set; }

        public Warehouse(Location location, String name):base(location,name)
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
