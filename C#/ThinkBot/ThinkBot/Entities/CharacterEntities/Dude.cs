﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Entities.BoundLocEntities;
using ThinkBot.Entities.BoundLocEntities.Buildings;
using System.Threading;
using ThinkBot.Logging;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.CharacterEntities
{
    public class Dude : CharacterEntity, IMapInteractable
    {
        public LocationBlock CurrentBlock { get; set; }  // Keeps track which block the dude is on
        public int ID { get; set; }             // Entity ID
        public String Name { get; set; }        // Entity Name
        public int Resources { get; set; }      // amount of resources this dude has
        public int Rest { get; set; }           // amount of rest this dude has
        public bool Visible { get; set; }
        public int MovementSpeed { get; set; }


        public Dude(int id, LocationBlock currentBlock)
        {   // dudes always start in a spawn point as invisible. Name is autogenerated.
            // a Dude needs an ID and a spawnpoint Location
            Name = generateName();
            CurrentBlock = currentBlock;
            Visible = false;
            MovementSpeed = 200;
        }

        private string generateName()
        {   // Generates a new name for the character, should implement code to generate a new name. Maybe in the future the dude can pick his own name, or the parents name him.
            String name = "frank";
            Logger.LogNameChange(ID, name);
            return name;
        }

        public void DeSpawnDude()
        {   // sets the character invisible
            Visible = false;
            Logger.WriteVisibleLog(ID, Visible);
        }

        public void SpawnDude()
        {   // sets the character visible
            Visible = true;
            Logger.WriteVisibleLog(ID, Visible);
        }

        public void EditSpeed(int amount)
        {   // increases or decreases the movement speed of a Dude. This affects the speed at which MoveTo is looped
            if (MovementSpeed - amount < 1)
            { // there should be at least 1 movement
                MovementSpeed = 1;
            }
            else if (MovementSpeed + amount > 900)
            { // there should be a max of 900 movespeed
                MovementSpeed = 900;
            }
            else
            {
                MovementSpeed -= amount;
            }

            Logger.WriteMovespeedChangeLog(ID, MovementSpeed);

        }

        internal void PerformPriority(List<Building> inGameBuildings)
        {
            Logger.WriteActivityLog(ID, " is figuring out where to go next...");

            if (Rest < 5)
            {
                Logger.WritePriorityLog(ID, "restplace"); // there should be a better design to fix all the duplacaté :)
                GoRest(FindClosestRestplace(inGameBuildings));
            }
            else if (Resources > 8)
            {
                Logger.WritePriorityLog(ID, "Warehouse");
                DeliverResources(FindClosestWarehouse(inGameBuildings));
            }
            else
            {
                Logger.WritePriorityLog(ID, "resource");
                GatherResources(FindClosestResource(inGameBuildings));
            }
        }



        private void GatherResources(ResourceHub resource)
        {
            Logger.WriteActivityLog(ID, " is gathering resource from "+resource.ToString());
            MoveTo(resource);
            resource.EnterBuilding(this);
            Resources++;
            resource.SubtractResource(1);
            Rest--;
            Thread.Sleep(MovementSpeed * 15);
            resource.LeaveBuilding(this);
        }


        private void DeliverResources(Warehouse warehouse)
        {
            Logger.WriteActivityLog(ID, " is delivering to " + warehouse.ToString());
            MoveTo(warehouse);
            warehouse.EnterBuilding(this);
            Resources--;
            warehouse.AddResource(1);
            Rest--;
            Thread.Sleep(MovementSpeed * 15);
            warehouse.LeaveBuilding(this);
        }


        private void GoRest(House house)
        {
            Logger.WriteActivityLog(ID, " is moving to " + house.ToString());
            MoveTo(house);
            house.EnterBuilding(this);
            Rest += 5;
            Thread.Sleep(MovementSpeed * 15);
            house.LeaveBuilding(this);
        }


        private House FindClosestRestplace(List<Building> inGameBuildings)
        {   // finds out which house is the closest to the character, and returns it.

            House closestHouse = null;
            List<House> houses = new List<House>();

            foreach(Building building in inGameBuildings)
            {
                if((building.GetType()).Equals(typeof(House)))
                {
                    houses.Add((House)building);
                }
            }

            foreach (House house in houses)
            {
                if (closestHouse == null)
                {
                    closestHouse = house;
                }
                else
                {
                    if (closestHouse.Location.IsFurtherThan(CurrentBlock, house.Location))
                    {
                        closestHouse = house;
                    }
                }
            }

            Logger.WriteActivityLog(ID, " found closest restplace " + closestHouse.ToString());
            return closestHouse;
        }

        private ResourceHub FindClosestResource(List<Building> inGameBuildings)
        {
            // finds out which resourcehub is the closest to the character, and returns it.

            ResourceHub closestResource = null;
            List<ResourceHub> resourcehubs = new List<ResourceHub>();

            foreach (Building building in inGameBuildings)
            {
                if ((building.GetType()).Equals(typeof(ResourceHub)))
                {
                    resourcehubs.Add((ResourceHub)building);
                }
            }

            foreach (ResourceHub reHub in resourcehubs)
            {
                if (closestResource == null)
                {
                    closestResource = reHub;
                }
                else
                {
                    if (closestResource.Location.IsFurtherThan(CurrentBlock, reHub.Location))
                    {
                        closestResource = reHub;
                    }
                }
            }
            Logger.WriteActivityLog(ID, " found closest resource " + closestResource.ToString());
            return closestResource;
        }

        private Warehouse FindClosestWarehouse(List<Building> inGameBuildings)
        {
            // finds out which warehouse is the closest to the character, and returns it.

            Warehouse closestWarehouse = null;
            List<Warehouse> warehouses = new List<Warehouse>();

            foreach (Building building in inGameBuildings)
            {
                if ((building.GetType()).Equals(typeof(Warehouse)))
                {
                    warehouses.Add((Warehouse)building);
                }
            }

            foreach (Warehouse waho in warehouses)
            {
                if (closestWarehouse == null)
                {
                    closestWarehouse = waho;
                }
                else
                {
                    if (closestWarehouse.Location.IsFurtherThan(CurrentBlock, waho.Location))
                    {
                        closestWarehouse = waho;
                    }
                }
            }
            Logger.WriteActivityLog(ID, " found closest warehouse " + closestWarehouse.ToString());
            return closestWarehouse;
        }

        public void MoveTo(Building building)
        {
            DudeMover.MoveTo(building.Location, this);
            Logger.WriteActivityLog(ID, " has entered building " + building.ToString());
        }

        public override string ToString()
        {
            return Name + " R : " + Resources + " Rest : " + Rest + " " + CurrentBlock.ToString();
        }

        public void PerformInteraction()
        {
            throw new NotImplementedException();
        }
    }
}
