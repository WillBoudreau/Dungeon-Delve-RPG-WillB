using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class PotionShop : Shop
    {
        public PotionShop()
        {

        }
        public override void EnterShop(Player player)
        {
            Console.Clear();
            Debug.WriteLine("Entered Potion Shop");
            Introduction();
        }
        public void Introduction()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Potion Shop!");
            Console.WriteLine("Here you can buy potions to heal yourself");
            Console.WriteLine("You can also sell potions you don't need");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Exit");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the number of the option you want to choose:");
            Console.WriteLine(" ");
            //Console.ReadKey();
            //switch (Input)
            //{
            //    case "1":
            //        Buy(player, new HealthPotion());
            //        break;
            //    case "2":
            //        Sell(player, new HealthPotion());
            //        break;
            //    case "3":
            //        break;
            //}
        }
        public override void Buy(Player player,Item item)
        {
            item.Buy(player);
        }

        public override void Sell(Player player,Item item)
        {
            
        }

        public override void UpdateShop(Player player,Item itemn)
        {
            
        }
    }
}
