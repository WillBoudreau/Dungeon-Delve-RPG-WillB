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
            IsCurrent = true;
            Console.WriteLine("Quest Started: Kill " + enemiesToKill + " enemies");
            if( hud != null )
            {
                hud.UpdateHUD();
            }
        }
        public override string Progress()
        {
            return $"Kill {player.KillCount} / {enemiesToKill} enemies";
        }
    }
}
