using ThinkBot.Entities.BoundLocEntities;
using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThinkBot.Entities.CharacterEntities
{
    public static class EntityMover
    { // should be performed in another thread, so other threads can then utilise the entity's props to update the gui or do calculations.



        public static void MoveTo(Location targetLoc, Location currentLoc, int movementspeed)
        {
            double[] modifiers = CalcMovementModifiers(targetLoc, currentLoc);
            double xModifier = modifiers[0];
            double yModifier = modifiers[1];
            PerformMovement(targetLoc, currentLoc, xModifier, yModifier, movementspeed);
        }
        

        public static void PerformMovement(Location targetLoc, Location currentLoc, double xMod, double yMod, int moveSpeed)
        {
            while (true)
            {
                if ((currentLoc.CordX + xMod > targetLoc.CordX) || (currentLoc.CordX + xMod < targetLoc.CordX))
                { // if targetX is further than 1 away from the current coord
                    currentLoc.CordX += xMod;
                }
                else
                { // dude has arrived, target loc becomes dude loc (this is when he's close than 1 count)
                    currentLoc.CordX = targetLoc.CordX;
                }

                if ((currentLoc.CordY + yMod > targetLoc.CordY) || (currentLoc.CordY + yMod < targetLoc.CordY))
                { // if targetX is further than 1 away from the current coord
                    currentLoc.CordY += yMod;
                }
                else
                { // dude has arrived, target loc becomes dude loc (this is when he's close than 1 count)
                    currentLoc.CordY = targetLoc.CordY;
                }
                if((currentLoc.CordX == targetLoc.CordX) && (currentLoc.CordY == targetLoc.CordY))
                {
                    break;
                }

                System.Threading.Thread.Sleep(1000 - moveSpeed);
            }


        }



        public static double[] CalcMovementModifiers(Location targetLoc, Location currentLoc)
        {   // basically this class will calculate the movement modifiers, 
            // so the MoveTo class doesn't have to calculate it all the time and can be used without to much resource impact.
            // returns the modifiers in following order : {x , y}

            double xModifier = 0;
            double yModifier = 0;

            double tarX = targetLoc.CordX;
            double tarY = targetLoc.CordY;
            double curX = currentLoc.CordX;
            double curY = currentLoc.CordY;

            double xDif = tarX - curX;
            double yDif = tarY - curY;

            // check which axis is the biggest, set the difference of the other axis relative to 1 movement in the dominant axis.

            if (Math.Pow(xDif, 2) > Math.Pow(yDif, 2))
            { // if the X distance is bigger, then proportionally adjust the y distance per 1 x.
                xModifier = 1;
                yModifier = Math.Sqrt((Math.Pow(yDif, 2))) / Math.Sqrt((Math.Pow(xDif, 2)));
            }
            else if (Math.Pow(xDif, 2) > Math.Pow(yDif, 2))
            {
                yModifier = 1;
                xModifier = Math.Sqrt((Math.Pow(xDif, 2))) / Math.Sqrt((Math.Pow(yDif, 2)));
            }
            else if (xDif == yDif)
            {
                xModifier = 0;
                yModifier = 0;
            }

            // if a modifier is supposed to be negative, then do it now.

            if (xDif < 0)
            {
                xModifier = -xModifier;
            }
            if (yDif < 0)
            {
                yModifier = -yModifier;
            }

            // return both the modifiers.

            return new double[]{ xModifier, yModifier};
        }
    }
}
