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
        public LocationBlock PositionBlock { get; set; }
        public HashSet<CharacterEntity> CharactersInside { get; set; }


        public Spawn(LocationBlock positionBlock)
        {
            PositionBlock = positionBlock;
        }

        public void EnterSpawn(CharacterEntity character)
        { // Makes a character "enter" the spawn. Makes it invisible untill it leaves.
          // Given character is stored in the hashset.
          // use this through the object this spawn is attached to
            character.DeSpawnCharacter();
            CharactersInside.Add(character);
        }

        public void LeaveSpawn(CharacterEntity character)
        { // Makes a character "leave" the spawn. Makes it visible when it leaves.
          // Given character is removed from the hashset.
          // use this through the object this spawn is attached to
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
