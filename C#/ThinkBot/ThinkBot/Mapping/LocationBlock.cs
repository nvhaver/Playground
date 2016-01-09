using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Mapping
{
    public class LocationBlock
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsPassable { get; set; }

        public LocationBlock(bool isPassable, int posX, int posY)
        {
            IsPassable = isPassable;
            PosX = posX;
            PosY = posY;
        }


    }
}
