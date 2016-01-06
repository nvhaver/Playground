using ThinkBot.Entities.BoundLocEntities;
using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThinkBot.Logging;

namespace ThinkBot.Entities.CharacterEntities
{
    public static class DudeMover
    { // should be performed in another thread, so other threads can then utilise the entity's props to update the gui or do calculations.



        public static void MoveTo(Location targetLoc, Dude dude)
        {
            int movementspeed = dude.MovementSpeed;
            double[] modifiers = CalcMovementModifiers(targetLoc, dude.Location);
            double xModifier = modifiers[0];
            double yModifier = modifiers[1];
            PerformMovement(targetLoc, dude, xModifier, yModifier, movementspeed);
        }
        

        public static void PerformMovement(Location targetLoc, Dude dude, double xMod, double yMod, int moveSpeed)
        {

            // REWRITE THIS SO A DUDE CAN MOVE USING SMART PATHFINDING

            Location currentLoc = dude.Location;

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
                if ((currentLoc.CordX == targetLoc.CordX) && (currentLoc.CordY == targetLoc.CordY))
                {
                    break;
                }

                Logger.WriteActivityLog(3, "MOVED " + currentLoc.ToString());
                Thread.Sleep(901 - moveSpeed);
                
            }


        }



        public static double[] CalcMovementModifiers(Location targetLoc, Location currentLoc)
        {
            double xModifier =0, yModifier =0;
            // This code was shit. It should've given 1 modifier that either outputs 1 or -1, 
            // the other one 0.xx... or -0.xx... relative to it.
            // Basically this and perform movement only make it possible to move in straight lines.
            // Has to be rewritten to be a true pathfinder


            // return both the modifiers.
            return new double[]{ xModifier, yModifier};
        }
    }
}
