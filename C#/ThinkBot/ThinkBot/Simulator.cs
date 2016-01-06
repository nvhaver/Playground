using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThinkBot.Entities.BoundLocEntities;
using ThinkBot.Entities.BoundLocEntities.Buildings;
using ThinkBot.Entities.CharacterEntities;
using ThinkBot.Logging;

namespace ThinkBot
{
    class Simulator
    {
        public List<Roadpoint> Roads { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Dude> Dudes { get; set; }
        public bool EndGame { get; set; }
        private List<Thread> threads = new List<Thread>();


        public Simulator()
        {
            Logger.WriteAnnouncementLog("THE SIMULATION HAS STARTED");
            Roads = new List<Roadpoint>();
            Buildings = new List<Building>();
            Dudes = new List<Dude>();
        }

        public void Initiate()
        {   // starts the beginning situation of the game


            // create the buildings
            Buildings.Add(new House(new Location(100, 100), "house"));
            Buildings.Add(new Warehouse(new Location(300, 300), "warehouse"));
            Buildings.Add(new ResourceHub(new Location(100, 300), "resources", 9999999));

            // add roadpoints to them
            Buildings[0].AddRoadpoint(new Location(200, 200));
            Buildings[1].AddRoadpoint(Buildings[0].Roadpoint.BeginLocation);
            Buildings[2].AddRoadpoint(Buildings[0].Roadpoint.BeginLocation);

            // put a dude in the building's spawn
            Dude dude = new Dude(1, Buildings[0].Spawn.Location);
            Buildings[0].EnterBuilding(dude);
            Dudes.Add(dude);

            EndGame = false;

            // initiate a thread with the gameloop. This separates the GUI thread with the code thread.
            threads.Add(new Thread(PerformDudePrio)); // makes all the dudes perform their prioritary task
            threads.Add(new Thread(KeepRoadsUpdated)); // makes sure that roads get generated when new buildings pop up
            threads[0].Start(); // start managing the dudes

        } // 


        public void StartGameLoop()
        {   // this is the main game loop. The thread this is running on, should be used to initiate other threads, which will then work with the entities.

            while (EndGame == false)
            {
                Thread.Sleep(1);
            }
            
            threads[0].Abort(); // stop looping dudes
        } //



        public void PerformDudePrio()
        {  // this is the dudes loop, this will make sure every dude is performing an action. This is done by their internal priority assignment.
            while (EndGame == false)
            {
                foreach (Dude dude in Dudes)
                {
                    dude.PerformPriority(Buildings);
                }
                Thread.Sleep(15);
                
            }
        }//



        public void KeepRoadsUpdated()
        { // thread is not started in the code (neither aborted)
            throw new NotImplementedException();
        }
    }
}
