using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Shop
    {
        Settings settings = new Settings();
        //Methods
        //Enter the shop
        public abstract void EnterShop(Player player);
        //Buy an item from the shop
        public abstract void Buy(Player player,Item item);
        //Leave the shop
        public abstract void LeaveShop(Player player);
    }
}
