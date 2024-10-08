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
        public PotionShop(Map map)
        {
            this.map = map;
            if(map == null)
            {
                Debug.WriteLine("Map is null");
            }
        }
        public override void EnterShop(Player player)
        {
            Console.Clear();
            Debug.WriteLine("Entered Potion Shop");
            Introduction(player);
        }
        public void Introduction(Player player)
        {
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
            Console.WriteLine("1. Small Potion - 1 gold");
            Console.WriteLine("2. Medium Potion - 5 gold");
            Console.WriteLine("3. Large Potion - 10 gold");
        }
        public override void Buy(Player player,Item item)
        {
            Console.WriteLine("Please enter the number of the potion you would like to buy:");
            Console.WriteLine(" ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    if (player.currentSeeds >= 1)
                    {
                        player.currentSeeds -= 1;
                        player.healthSystem.currentHealth += 1;
                        Console.WriteLine("You have bought a potion for 10 gold");
                        Console.WriteLine("You now have " + player.currentSeeds + " gold");
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth + " health");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    if (player.currentSeeds >= 5)
                    {
                        player.currentSeeds -= 5;
                        player.healthSystem.currentHealth += 5;
                        Console.WriteLine("You have bought a potion for 20 gold");
                        Console.WriteLine("You now have " + player.currentSeeds + " gold");
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth + " health");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if (player.currentSeeds >= 10)
                    {
                        player.currentSeeds -= 10;
                        player.healthSystem.currentHealth += 10;
                        Console.WriteLine("You have bought a potion for 30 gold");
                        Console.WriteLine("You now have " + player.currentSeeds + " gold");
                        Console.WriteLine("You now have " + player.healthSystem.currentHealth+ " health");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold to buy this potion");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
            }
        }
        public override void LeaveShop(Player player)
        { 
            Console.Clear();
            Console.WriteLine("You have left the shop");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            map.mapDrawn = false;
            //map.UpdateMap(player);
        }
    }
}
