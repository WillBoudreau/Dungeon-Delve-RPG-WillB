using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Quest
    { 
        //Quest class
        //Properties
        //Is the quest current
        public bool IsCurrent { get; set; }
        //Methods
        //Progress of the quest
        public abstract string Progress();
        //Complete the quest
        public abstract void Complete(HUD hud,Player player);
        //Start the quest
        public abstract void Started(HUD hud);

    }
}
