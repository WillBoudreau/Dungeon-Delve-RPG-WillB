using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //Quest is completed
            if (ItemCollected >= itemsToCollect)
            {
                IsCurrent = false;
            }
            else if (hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override void Started(HUD hud)
        {
            //Quest is started
            IsCurrent = true;
            Console.WriteLine("Quest Started: Collect " + itemsToCollect + " seeds");
            if (hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override string Progress()
        {
            ItemCollected = player.SeedsCollected;
            Debug.WriteLine("ItemCollected: " + ItemCollected);
            //Progress is updated in the HUD
            //If the player has more seeds than the last time the progress was checked, update the ItemCollected
            if (player.currentSeeds > ItemCollected)
            {
                ItemCollected = player.currentSeeds;
            }
            return $"Collect {ItemCollected} / {itemsToCollect} seeds";
        }
    }
}
