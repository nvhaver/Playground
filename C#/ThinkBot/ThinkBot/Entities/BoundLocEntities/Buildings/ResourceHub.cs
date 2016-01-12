using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.BoundLocEntities.Buildings
{
    class ResourceHub : Building
    {
        public int Resources { get; set; }
        public bool IsEmpty { get; set; }

        public ResourceHub(Location location, LocationBlock spawnBlockLocation, String name, int amountOfResources):base(location, spawnBlockLocation, name)
        {
            Resources = amountOfResources;
            IsEmpty = false;
        }

        internal void SubtractResource(int v)
        {
            if(Resources - v < 0)
            {
                IsEmpty = true;
                Resources = 0;
            }
            else
            {
                Resources -= v;
            }
        }

        public override string ToString()
        {
            return (base.ToString()+" "+Resources);
        }
    }
}
