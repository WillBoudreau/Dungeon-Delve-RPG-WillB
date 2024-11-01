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
        Map map;
        Settings settings;
        public PotionShop(Map map,Settings settings)
        {
            this.map = map;
            this.settings = settings;
            if(map == null)
            {
                Debug.WriteLine("Map is null");
            }
        }
        public override void EnterShop(Player player)
        {   
            //Enter the shop
                Console.Clear();
                Debug.WriteLine("Entered Potion Shop");
                Introduction(player);
        }
        public void Introduction(Player player)
        {
            //Introduction to the shop
            Console.WriteLine("Welcome to the Potion Shop!");
            Console.WriteLine("Here you can buy potions to heal yourself");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Exit");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the number of the option you want to choose:");
            Console.WriteLine(" ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    DisplayItems();
                    Buy(player, null);
                    break;
                case 2:
                    LeaveShop(player);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        void DisplayItems()
        {
            //Display items available in the shop
            Console.WriteLine($"1. Small Potion -{settings.MinHealthCost}");
            Console.WriteLine($"2. Medium Potion - {settings.MidHealthCost}");
            Console.WriteLine($"3. Large Potion - {settings.MaxHealthCost}");
        }
        public override void Buy(Player player,Item item)
        {
            Console.WriteLine("Please enter the number of the potion you would like to buy:");
            Console.WriteLine(" ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    if (player.currentSeeds >= settings.MinHealthCost)
                    {
                        //Buy Small Potion
                        player.currentSeeds -= 1;
                        player.healthSystem.currentHealth += 1;
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth + " health");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        //Not enough gold
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    if (player.currentSeeds >= settings.MidHealthCost)
                    {
                        //Buy Medium Potion
                        player.currentSeeds -= 5;
                        player.healthSystem.currentHealth += 5;
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth + " health");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if (player.currentSeeds >= settings.MaxHealthCost)
                    {
                        player.currentSeeds -= 10;
                        player.healthSystem.currentHealth += 10;
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth+ " health");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option");
                    Console.WriteLine("Press any key to continue");
                    Introduction(player);
                    break;
            }
            Console.Clear();
            //Return to the shop
            Introduction(player);
        }
        public override void LeaveShop(Player player)
        { 
            //Leave the shop
            Console.Clear();
            Console.WriteLine("You have left the shop");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            map.mapDrawn = false;
        }
    }
}
