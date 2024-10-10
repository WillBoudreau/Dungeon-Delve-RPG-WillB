using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class QuestKillEnemies : Quest
    {
        public int enemiesToKill;
        Player player;
        public QuestKillEnemies(int enemiesToKill,Player player)
        {
            this.enemiesToKill = enemiesToKill;
            this.player = player;
        }
        public override void Complete(HUD hud,Player player)
        {
            //Quest is completed
            if (player.KillCount >= enemiesToKill)
            {
                IsCurrent = false;
            }
            if(hud != null)
            {
                hud.UpdateHUD();
            }
        }
        public override void Started(HUD hud)
        {
            //Quest is started
            IsCurrent = true;
            Console.WriteLine("Quest Started: Kill " + enemiesToKill + " enemies");
            if( hud != null )
            {
                hud.UpdateHUD();
            }
        }
        public override string Progress()
        {
            //Progress is updated in the HUD
            return $"Kill {player.KillCount} / {enemiesToKill} enemies";
        }
    }
}
