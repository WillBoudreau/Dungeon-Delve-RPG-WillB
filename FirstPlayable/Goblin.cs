﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class Goblin : Enemy
    {

        public Goblin(int maxHealth, int damage, int startX, int startY, string name, char[,] mapLayout) : base(maxHealth, damage, startX, startY, name, mapLayout)
        {
            
            healthSystem = new HealthSystem(maxHealth);
            enemyDamage = damage;
            positionX = startX;
            positionY = startY;
            currentTile = mapLayout[startY, startX];
            enemyAlive = true;
            Name = name;
            icon = 'G';
        }

        public override void Draw()
        {
            if (enemyAlive == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(icon);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write('#');
                Console.ResetColor();
            }
        }



        public override void Movement(int playerX, int playerY, int mapWidth, int mapHeight, char[,] mapLayout, Player player)
        {
            int enemyMovementX = positionX;
            int enemyMovementY = positionY;
            int newEnemyPositionX = positionX;
            int newEnemyPositionY = positionY;

            // random roll to move
            Random randomRoll = new Random();

            // checks if enemy is alive so it doesn't bug out when it is actually killed
            if (enemyAlive == true)
            {
                int rollResult = randomRoll.Next(1, 5);
                while ((enemyMovementX == playerX && enemyMovementY == playerY) ||
                       (enemyMovementX == newEnemyPositionX && enemyMovementY == newEnemyPositionY) ||
                       mapLayout[enemyMovementY, enemyMovementX] == '#' || mapLayout[enemyMovementY,enemyMovementX] == 'S' 
                       || mapLayout[enemyMovementY, enemyMovementX] == 'P' || 
                       mapLayout[enemyMovementY, enemyMovementX] == 'U' || mapLayout[enemyMovementY,enemyMovementX] == '^' || mapLayout[enemyMovementY,enemyMovementX] == 'G')
                {

                    // retries the role
                    rollResult = randomRoll.Next(1, 5);

                    if (rollResult == 1)
                    {
                        enemyMovementY = positionY + 1;
                        if (enemyMovementY >= mapHeight)
                        {
                            enemyMovementY = mapHeight - 1;
                        }
                    }
                    else if (rollResult == 2)
                    {
                        enemyMovementY = positionY - 1;
                        if (enemyMovementY <= 0)
                        {
                            enemyMovementY = 0;
                        }
                    }
                    else if (rollResult == 3)
                    {
                        enemyMovementX = positionX - 1;
                        if (enemyMovementX <= 0)
                        {
                            enemyMovementX = 0;
                        }
                    }
                    else // rollResult == 4
                    {
                        enemyMovementX = positionX + 1;
                        if (enemyMovementX >= mapWidth)
                        {
                            enemyMovementX = mapWidth - 1;
                        }
                    }
                }



                if (mapLayout[newEnemyPositionY, newEnemyPositionX] != '#')
                {

                    Console.SetCursorPosition(positionX, positionY);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(currentTile);


                    positionX = newEnemyPositionX;
                    positionY = newEnemyPositionY;


                    currentTile = mapLayout[newEnemyPositionY, newEnemyPositionX];
                }


                if (enemyMovementX == playerX && enemyMovementY == playerY)
                {
                    player.healthSystem.Damage(enemyDamage);
                    player.UpdateLiveLog($"Enemy dealt {enemyDamage} damage to you!");
                    if (player.healthSystem.IsDead())
                    {
                        player.gameOver = true;
                    }
                }

                
                if (mapLayout[newEnemyPositionY, newEnemyPositionX] == '#')
                {
                    
                    return;
                }

                // Clear the old position of the enemy on the map layout
                mapLayout[positionY, positionX] = '-';

                // Redraw the old position
                Console.SetCursorPosition(positionX, positionY);
                Console.Write('-');

                // Update the enemy's position
                positionY = enemyMovementY;
                positionX = enemyMovementX;

                // Update the enemy's position on the map layout
                //mapLayout[positionY, positionX] = icon;

                // Redraw the new position
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(icon);
            }
        }
    }
}