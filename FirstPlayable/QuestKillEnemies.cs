using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class QuestKillEnemies : Quest
    {
        int enemiesToKill;
        int enemiesKilled;
        public QuestKillEnemies(int enemiesToKill)
        {
            this.enemiesToKill = enemiesToKill;
            this.enemiesKilled = 0;
        }

        public override void Complete(HUD hud)
        {
            IsCurrent = false;
            Console.WriteLine("Quest Complete: You have killed all " + enemiesToKill + " enemies");
            if(hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override void Started(HUD hud)
        {
            IsCurrent = true;
            Console.WriteLine("Quest Started: Kill " + enemiesToKill + " enemies");
            if( hud != null )
            {
                hud.UpdateHUD();
            }
        }
    }
}
