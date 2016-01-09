using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Mapping
{
    class Map
    {
        public Map AdjecentN { get; set; }
        public Map AdjecentE { get; set; }
        public Map AdjecentS { get; set; }
        public Map AdjecentW { get; set; }

        public int CordX { get; set; }
        public int CordY { get; set; }

        public LocationBlock[][] block;

        // Use this ctor for the first map, or when no adjecent ones are known (for example, when creating multiple civs or towns)
        public Map(int cordX, int cordY)
        {
            CordX = cordX;
            CordY = cordY;

            AdjecentN = null;
            AdjecentE = null;
            AdjecentS = null;
            AdjecentW = null;

            block = new LocationBlock[1000][];

            for (int i = 0; i < 1000; i++)
            {
                block[i] = new LocationBlock[1000];
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    block[i][j] = new LocationBlock(true, i, j);
                }
            }

        }

        // ctor to use when one of the adjecent maps is known
        public Map(Map n, Map e, Map s, Map w)
        {
            FigureOutCoordinates(n,e,s,w);
        }

        // makes it obsolete to give coordinates for maps that are automatically generated next to another map
        private void FigureOutCoordinates(Map n, Map e, Map s, Map w)
        {
            try
            {
                if (n != null)
                {
                    CordX = n.CordX;
                    CordY = n.CordY - 1;
                    AdjecentN = n;
                }
            } catch (NullReferenceException) { }

            try
            {
                if (e != null)
                {
                    CordX = e.CordX-1;
                    CordY = e.CordY; ;
                    AdjecentE = e;
                }
            } catch (NullReferenceException) { }

            try
            {
                if (s != null)
                {
                    CordX = s.CordX;
                    CordY = s.CordY +1;
                    AdjecentS = s;
                }
            }
            catch (NullReferenceException) { }

            try
            {
                if (w != null)
                {
                    CordX = w.CordX+1;
                    CordY = w.CordY;
                    AdjecentW = w;
                }
            }
            catch (NullReferenceException) { }

        }
    }
}
