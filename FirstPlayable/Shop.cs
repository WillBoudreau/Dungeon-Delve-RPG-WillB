using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Shop
    {
        public abstract void EnterShop(Player player);
        public abstract void Buy(Player player,Item item);
        public abstract void LeaveShop(Player player);
    }
}
