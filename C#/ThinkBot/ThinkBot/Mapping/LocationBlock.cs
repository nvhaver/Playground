using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Mapping
{
    public class LocationBlock
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
        public bool IsPassable { get; set; }

        public LocationBlock(bool isPassable, short posX, short posY)
        {
            IsPassable = isPassable;
            PosX = posX;
            PosY = posY;
        }


    }
}
