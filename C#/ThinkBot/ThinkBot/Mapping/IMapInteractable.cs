using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBot.Mapping
{
    public interface IMapInteractable
    {
        // this makes certain classes Interactable on the map. For example, when a IMapInteractable dude steps on an IMapInteractable spawn,
        // That makes the dude able to enter a spawn

        void PerformInteraction(IMapInteractable interactable);
    }
}
