using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    public class Seed : Item
    {
        public int SeedMultiplier { get; set; } = 1;
        internal override void Use(Player player)
        {
            player.currentSeeds += 1 * SeedMultiplier;
            player.UpdateLiveLog("Picked up a seed");
        }
        internal override void Buy(Player player)
        {
            player.currentSeeds += 1;
            player.UpdateLiveLog("Bought a seed");
        }
    }
}
