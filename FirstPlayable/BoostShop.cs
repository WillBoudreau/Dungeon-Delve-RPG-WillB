﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class BoostShop:Shop
    {
        Map map;
        Settings settings;
        Seed seed = new Seed();
        public BoostShop(Map map, Settings settings)
        {
            this.map = map;
            this.settings = settings;
        }
        public override void EnterShop(Player player)
        {
            //Enter the shop
            Console.Clear();
            Introduction(player);
        }
        void Introduction(Player player)
        {
            //Introduction to the shop
            Console.WriteLine("Welcome to the Boost Shop!");
            Console.WriteLine("Here you can buy boosts to increase your stats");
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
            Console.WriteLine($"1. Health Boost - {settings.MinBonusCost}");
            Console.WriteLine($"2. Attack Boost - {settings.MidBonusCost}");
            Console.WriteLine($"3. Gold Boost - {settings.MaxBonusCost}");
        }
        public override void Buy(Player player, Item item)
        {
            //Buy items from the shop
            Console.WriteLine("Enter the number of the item you want to buy:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    if (player.currentSeeds >= settings.MinBonusCost)
                    {
                        //Buy Health Boost
                        player.currentSeeds -= 5;
                        player.healthSystem.maximumHealth += 10;
                        Console.WriteLine("You have bought a Health Boost");
                        Console.WriteLine("Your max health has increased by 10");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        //Not enough seeds
                        Console.WriteLine("You do not have enough seeds to buy this item");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    if (player.currentSeeds >= settings.MidBonusCost)
                    {
                        player.currentSeeds -= 10;
                        player.playerDamage += 5;
                        Console.WriteLine("You have bought an Attack Boost");
                        Console.WriteLine("Your attack has increased by 5");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough seeds to buy this item");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if (player.currentSeeds >= settings.MaxBonusCost)
                    {
                        player.currentSeeds -= 15;
                        seed.SeedMultiplier += 2;
                        Console.WriteLine("You have bought a Gold Boost");
                        Console.WriteLine("Your gold has increased by 5");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough seeds to buy this item");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
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
