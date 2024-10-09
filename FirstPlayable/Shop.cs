using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Shop
    {
        // variables
        //X and Y position of the shop
        public int x;
        public int y;
        //Call the seed class
        Seed seed = new Seed();
        public abstract void EnterShop(Player player);
        public abstract void Buy(Player player,Item item);
        public abstract void LeaveShop(Player player);
        //Set the position of the shop
        public void SetPos(int x, int y)
        {
           this.x = x;
           this.y = y;
        }
    }
}
