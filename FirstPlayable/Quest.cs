using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Quest
    {
        public bool IsCurrent { get; set; }
        public int EnemiesToKill;
        public int EnemiesKilled;
        public abstract void Complete(HUD hud);
        public abstract void Started(HUD hud);
        public void StartQuest(HUD hud)
        {
            IsCurrent = true;
            Started(hud);
        }
    }
}
