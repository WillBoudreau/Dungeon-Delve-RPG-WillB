using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    public class Seed : Item
    {
        internal override void Use(Player player)
        {
            player.currentSeeds += 1;
            player.UpdateLiveLog("Picked up a seed");
        }
        internal override void Buy(Player player)
        {
            player.currentSeeds += 1;
            player.UpdateLiveLog("Bought a seed");
        }
    }
}
