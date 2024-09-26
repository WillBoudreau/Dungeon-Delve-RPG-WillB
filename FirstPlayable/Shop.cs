using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Shop
    {
        public abstract void Buy(Player player,Item item);
        public abstract void Sell(Player player, Item item);
        public abstract void UpdateShop(Player player, Item item);
    }
}
