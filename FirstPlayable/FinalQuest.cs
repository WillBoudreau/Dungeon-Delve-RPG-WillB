using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class FinalQuest : Quest
    {
        public FinalQuest()
        {

        }
        public override void Complete(HUD hud, Player player)
        {
            if (hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override void Started(HUD hud)
        {
            Console.WriteLine("Quest Started: Get to the End");
            if (hud != null)
            {
                hud.UpdateHUD();
            }
        }  
        public override string Progress()
        {
            return "Get to the End";
        }
    }
}
