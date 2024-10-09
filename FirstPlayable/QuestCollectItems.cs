using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class QuestCollectItems : Quest
    {
        public int itemsToCollect;
        public int ItemCollected;
        Player player;
        public QuestCollectItems(int itemsToCollect, Player player)
        {
            this.itemsToCollect = itemsToCollect;
            this.player = player;
        }
        public override void Complete(HUD hud, Player player)
        {
            if (player.currentSeeds >= itemsToCollect)
            {
                IsCurrent = false;
                Console.WriteLine("Quest Complete: You have collected all " + itemsToCollect + " seeds");
            }
            if (hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override void Started(HUD hud)
        {
            IsCurrent = true;
            Console.WriteLine("Quest Started: Collect " + itemsToCollect + " seeds");
            if (hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override string Progress()
        {
            ItemCollected = player.currentSeeds;
            return $"Collect {ItemCollected} / {itemsToCollect} seeds";
        }
    }
}
