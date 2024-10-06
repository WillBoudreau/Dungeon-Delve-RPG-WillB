using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal abstract class Enemy
    {

        public HealthSystem healthSystem;
        public int enemyHealth { get; set; }
        public int enemyDamage { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public bool enemyAlive { get; set; }

        public char currentTile;

        public char icon { get; set; }
        public string Name { get; set; }
        public Enemy(int maxHealth, int damage, int startX, int startY, string name, char[,]mapLayout)
        {
            healthSystem = new HealthSystem(maxHealth);
            enemyHealth = maxHealth;
            enemyDamage = damage;
            positionX = startX;
            positionY = startY;
            enemyAlive = true;
            Name = name;
        }
        public abstract void Movement(int playerX, int playerY, int mapWidth, int mapHeight, char[,] mapLayout, Player player);
        public abstract void Draw();
    }
}
