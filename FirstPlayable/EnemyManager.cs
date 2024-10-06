using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class EnemyManager
    {
        // variables | encapsulation
        //Class calls
        public Player player;
        public Settings settings;
        public List<Enemy> enemies { get; set; }

        public EnemyManager()
        {
            settings = new Settings();
            enemies = new List<Enemy>();
        }
        public void GenerateEnemies(Map map,List<Enemy>enemies,int numRunners, int numGoblins, int numBoss)
        {
            for (int i = 0; i < numRunners; i++)
            {
                Runner runner = new Runner(settings.RunnerInitialHealth, settings.RunnerInitialDamage, map.initialPlayerPositionX, map.initialPlayerPositionY, "Runner", map.layout);
                enemies.Add(runner);
            }
            for (int i = 0; i < numGoblins; i++)
            {
                Goblin goblin = new Goblin(settings.GoblinInitialHealth, settings.GoblinInitialDamage, map.initialPlayerPositionX, map.initialPlayerPositionY, "Goblin", map.layout);
                enemies.Add(goblin);
            }
            for (int i = 0; i < numBoss; i++)
            {
                Boss boss = new Boss(settings.BossInitialHealth, settings.BossInitialDamage, map.initialPlayerPositionX, map.initialPlayerPositionY, "Boss", map.layout);
                enemies.Add(boss);
            }
        }
        public void Init(Map map)
        {
            GenerateEnemies(map,enemies,1,1,1);
        }
        public void Update(Player player,Map map)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Movement(player.positionX,player.positionY,map.mapWidth,map.mapHeight,map.layout,player);
            }
        }
        
        public  void Draw()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
        }
        public void Clear()
        {
            enemies.Clear();
        }   
    }
}

        

        
