using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Location
    {
        public double CordX { get; set; }
        public double CordY { get; set; }


        public Location(double x, double y)
        { // make new location with given coordinates
            CordX = x;
            CordY = y;
        }

        public void UpdateLocation(double x, double y)
        { // sets the new coordinates of the Location (increment this 1 pixel at a time in a loop for movement)
            CordX = x;
            CordY = y;
        }

        public bool IsFurtherThan(Location relativeTo, Location location)
        { // returns true if this location is further away than the given location is to relativeTo.
          // distance should be calculated in the following way. Granted relativeTo.cordX = x1 (same for y), and for location.cordX it's x2, than the formula is
          // sqrt( (x2-x1)² + (y2-y1)² )

            double thisX, thisY, relX, relY, locX, locY;

            thisX = CordX;
            thisY = CordY;
            relX = relativeTo.CordX;
            relY = relativeTo.CordY;
            locX = location.CordX;
            locY = location.CordY;

            // this means : current location is further than given location, return false, else true
            if((Math.Sqrt( (Math.Pow(thisX - relX,2) + Math.Pow(thisY - relY,2)))) > (Math.Sqrt((Math.Pow(locX - relX,2) + Math.Pow(locY - relY,2)))))
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public bool IsCloserThan(Location relativeTo, Location location)
        { // returns true if this location is closer than the given location is to relativeTo.
          // distance should be calculated in the following way. Granted relativeTo.cordX = x1 (same for y), and for location.cordX it's x2, than the formula is
          // sqrt( (x2-x1)² + (y2-y1)² )

            double thisX, thisY, relX, relY, locX, locY; // duplicate code much, i know.

            thisX = CordX;
            thisY = CordY;
            relX = relativeTo.CordX;
            relY = relativeTo.CordY;
            locX = location.CordX;
            locY = location.CordY;

            // this means : current location is closer or equal than given location, return false, else true
            if ((Math.Sqrt((Math.Pow(thisX - relX, 2) + Math.Pow(thisY - relY, 2)))) <= (Math.Sqrt((Math.Pow(locX - relX, 2) + Math.Pow(locY - relY, 2)))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return "x : " + CordX + " y : " + CordY;
        }

    }
}
