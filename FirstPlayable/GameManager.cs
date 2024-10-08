using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace FirstPlayable
{
    
    internal class GameManager
    {

        private Stopwatch levelTimer = new Stopwatch();
        public Map map;
        private Player player;
        private QuestManager questManager;
        private ShopManager shopManager;
        private Settings settings = new Settings();
        private EnemyManager enemyMan;
        private HUD hud;
        public SoundPlayer soundPlayer;
        public string CurrentLevel { get; set; }


        //public string currentLevel { get; set; }


        bool IsShopping = false;
        public GameManager()
        {
            enemyMan = new EnemyManager();
            map = new Map(enemyMan,player);
            shopManager = new ShopManager(map);
            player = new Player(settings.PlayerInitialHealth, settings.PlayerInitialDamage, settings.PlayerInitialLevel, map.initialPlayerPositionX, map.initialPlayerPositionY, map.layout, questManager, shopManager);
            questManager = new QuestManager(player, hud);
            hud = new HUD(player, map, questManager);
            //soundPlayer = new SoundPlayer(GetPath(settings.MusicFileName));
            //soundPlayer.PlayLooping();
        }
        public void Init()
        {
            questManager.Init();
            shopManager.Init(map);
        }
        
        /// <summary>
        /// Builds filepath for file from input filename and settings map / music directory
        /// </summary>
        /// <param name="fileName">filename of desired file</param>
        /// <returns>The filepath for the file</returns>
        public string GetPath(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, settings.FileLocation, fileName);
            return path;
        }

        public void Update()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            map.UpdateMap(player);
            hud.UpdateLegend();
            hud.UpdateHUD();
            questManager.Update();
        }


        public void Draw()
        {
            GameDisplay();
            foreach (var enemy in enemyMan.enemies)
            {
                enemy.Movement(player.positionX, player.positionY, map.mapWidth, map.mapHeight, map.layout, player);
            }
        }

        // Start up
        public void Start()
        {
        
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Dungeon Delve");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("\nYour goal is to collect 30 seeds '&' around a dungeon map while avoiding or defeating the enemies.");
            Console.WriteLine("\nThe world is known as The Underworld");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("You can attack by running into the enemy");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("There are health packs '+' and Damage boosters '?' available to pickup during your adventure");
                
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Goblins don't like conflict and aren't very aggressive!");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Runners chase you and hit you when they move into you!");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("The Boss hits you back whenever you hit him");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Enemies can drop valuables, so try not to skip them!");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Music used from: Maplestory (2005), PC, Nexon, Tokyo Japan");
                
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("It's dangerous to go alone... good luck!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();

            

       

        // game loop uses Init/Update/Draw methods
        
        Init();
        while (!player.gameOver)    
        {
            Console.CursorVisible = false;
            StartLevel();
            
            Update();

            Draw();
            
            
        }
            
        Console.Clear();

        // player wins
        if (player.youWin)
        {
           Win();
        }
        // players dead
        else
        {
            Lose();
        }
    }


        void Win()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You win!");
            Console.WriteLine($"\nYou collected: {player.currentSeeds} / 30 Seeds!");
            Console.WriteLine("Try to get more if you haven't got them all");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            EndLevel();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.ReadKey(true);
        }
        void Lose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int centerX = (Console.WindowWidth - "You died...".Length) / 2;
            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.WriteLine("You died...");

            Console.ReadKey(true);
        }
        




        private void StartLevel()
        {
            levelTimer.Start(); // Timer will start at beginning of level
            
        }

        private void EndLevel()
        {
            levelTimer.Stop(); // Timer stops at the end
            TimeSpan elapsedTime = levelTimer.Elapsed;

        
            string elapsedTimeString = String.Format("{0:00}:{1:00}:{2:00}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
            Console.WriteLine($"Level completed in: {elapsedTimeString}");
        }


        private void GameDisplay()
        {
            player.PlayerInput(map, enemyMan.enemies);
           
        }
            
            

            
    }

}