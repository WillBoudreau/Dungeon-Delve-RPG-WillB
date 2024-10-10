using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FirstPlayable
{
    internal class SwordShop:Shop
    {
        Map map;
        public SwordShop(Map map)
        {
            this.map = map;
            if(map == null)
            {
                Debug.WriteLine("Map is null");
            }
        }
        public override void EnterShop(Player player)
        {
            //Enter the shop
            Console.Clear();
            Debug.WriteLine("Entered Sword Shop");
            Introduction(player);
        }
        void Introduction(Player player)
        {
            //Introduction to the shop
            Console.WriteLine("Welcome to the Sword Shop!");
            Console.WriteLine("Here you can buy swords to increase your attack");
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
            Console.WriteLine("1. Wooden Sword - 5 seeds");
            Console.WriteLine("2. Iron Sword - 10 seeds");
            Console.WriteLine("3. Steel Sword - 15 seeds");
        }
        public override void Buy(Player player,Item item)
        {
            //Buy items from the shop
            Console.WriteLine("Enter the number of the item you want to buy:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    if (player.currentSeeds >= 5)
                    {
                        //Buy Wooden Sword
                        player.currentSeeds -= 5;
                        player.playerDamage += 5;
                        Console.WriteLine("You bought a Wooden Sword!");
                        Console.WriteLine("Your attack increased by 5");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                    }
                    else
                    {
                        //Not enough seeds
                        Console.Clear();
                        Console.WriteLine("You don't have enough seeds");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    if (player.currentSeeds >= 10)
                    {
                        player.currentSeeds -= 10;
                        player.playerDamage += 10;
                        Console.WriteLine("You bought an Iron Sword!");
                        Console.WriteLine("Your attack increased by 10");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough seeds");
                        Console.WriteLine("Press any key to continue"); 
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if (player.currentSeeds >= 15)
                    {
                        player.currentSeeds -= 15;
                        player.playerDamage += 15;
                        Console.WriteLine("You bought a Steel Sword!");
                        Console.WriteLine("Your attack increased by 15");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough seeds");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
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
