using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBot.Mapping;

namespace ThinkBot.Entities.CharacterEntities
{
    public class CharacterEntity : IMapInteractable
    {
        // used to define a character for example a dude or a dog. General movement should be implemented through this
        // Should move a lot of elements from dude into here, so it can be applied to other sorts of entities ;)

        public void PerformInteraction(IMapInteractable interactable)
        {
            return;
        }
    }
}
