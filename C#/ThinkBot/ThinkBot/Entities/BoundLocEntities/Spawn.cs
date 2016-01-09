using ThinkBot.Entities.CharacterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.BoundLocEntities
{
    public class Spawn : IMapInteractable
    {
        public Location Location { get; set; }
        public HashSet<CharacterEntity> CharactersInside { get; set; }


        public Spawn(Location location)
        {
            // has to be rewritten to be compatible with blocks
        }

        public Spawn(double x, double y)
        { 
            // has to be rewritten to be compatible with blocks
        }

        public void EnterSpawn(CharacterEntity character)
        { // Makes a dude "enter" the spawn. Makes him invisible untill he leaves.
          // Given dude is stored in the hashset.
          // use this through the building this spawn is attached to
            character.DeSpawnCharacter();
            CharactersInside.Add(character);
        }

        public void LeaveSpawn(CharacterEntity character)
        { // Makes a dude "leave" the spawn. Makes him visible when he leaves.
          // Given dude is removed from the hashset.
          // use this through the building this spawn is attached to
            character.SpawnCharacter();
            CharactersInside.Remove(character);
            character.Spawn = null;
        }

        public void PerformInteraction(IMapInteractable interactable)
        {
            EnterSpawn((CharacterEntity) interactable);
        }
    }
}
