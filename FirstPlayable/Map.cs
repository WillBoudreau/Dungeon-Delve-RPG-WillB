using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;

namespace FirstPlayable
{
    internal class Map
    {
        // variables | encapsulation
        
        private string path;
        private string[] floor;
        public char[,] layout;
        public bool mapDrawn = false;
        public int mapWidth { get; set; }
        public int mapHeight { get; set; }
        public int initialPlayerPositionX { get; set; }
        public int initialPlayerPositionY { get; set; }
        public int initialEnemyPositionX { get; set; }
        public int initialEnemyPositionY { get; set; }
        public string currentLevel { get; set; }
        public int ChangeMap { get; set; }
 
        private EnemyManager enemyManager;
        private Player player;
        private Settings settings;
        public Map( EnemyManager enemyManager,Player player,Settings settings)
        {
           this.player = player;
            this.settings = settings;
            this.enemyManager = enemyManager;
            path = settings.RPGMaps[ChangeMap];
            floor = File.ReadAllLines(path);
            CreateMap();
        }

        public void Init()
        {
            CreateMap();
        }
        // creates map
        private void CreateMap()
        {
            mapWidth = floor[0].Length;
            mapHeight = floor.Length;
            layout = new char[mapHeight, mapWidth];

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    layout[i, j] = floor[i][j];

                    if (layout[i, j] == '-')
                    {
                        initialPlayerPositionX = j;
                        initialPlayerPositionY = i;
                    }
                    if (layout[i, j] == '=')
                    {
                        initialPlayerPositionX = j;
                        initialPlayerPositionY = i;
                        layout[i, j] = '-';
                    }
                    else if (layout[i, j] == settings.GoblinSpawnPos)
                    {
                        layout[i, j] = '-';

                        initialEnemyPositionX = j;
                        initialEnemyPositionY = i;
                        var enemy = new Goblin(settings.GoblinInitialHealth,settings.GoblinInitialDamage, j, i, "Goblin", layout,settings.GoblinIcon); 
                        enemyManager.enemies.Add(enemy);
                    }
                    else if (layout[i, j] == settings.RunnerSpawnPos)
                    {
                        layout[i, j] = '-';
                        var runner = new Runner(settings.RunnerInitialHealth, settings.RunnerInitialDamage, j, i, "Runner", layout, settings.RunnerIcon); 
                        enemyManager.enemies.Add(runner);
                    }
                    else if (layout[i, j] == '@')
                    {
                        layout[i, j] = '-';
                        var boss = new Boss(settings.BossInitialHealth, settings.BossInitialDamage, j, i, "Boss", layout);
                        enemyManager.enemies.Add(boss);
                    }
                }
            }
        }

        // draws out map on screen
        public void UpdateMap(Player player)
        {
            if (!mapDrawn)
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkGray;

                for (int k = 0; k < mapHeight; k++)
                {
                    for (int l = 0; l < mapWidth; l++)
                    {
                        char tile = layout[k, l];
                        switch (tile)
                        {
                            case '=':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case '-':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case '&':
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case '^':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case '!':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'G':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case '#':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case '%':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case '+':
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case '?':
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'S':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'P':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'U':
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                        }

                        if (tile == '=' && !player.levelComplete)
                        {
                            player.positionX = l;
                            player.positionY = k - 1;
                            player.levelComplete = true;
                            layout[k, l] = '-';
                        }

                        Console.Write(tile);
                    }
                    Console.WriteLine();

                    mapDrawn = true;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(0, 0);
        }
        public void ChangeLevel(Player player)
        {
            Console.Clear();
            ChangeMap++;
            if (ChangeMap < settings.RPGMaps.Length)
            {
                path = settings.RPGMaps[ChangeMap];
                floor = File.ReadAllLines(path);
                enemyManager.enemies.Clear();
                Init();
            }
            else
            {
                player.youWin = true;
                player.gameOver = true;
                return;
            }
            UpdateMap(player);
            initialPlayerPositionX = player.positionX;
            initialPlayerPositionY = player.positionY;

            player.positionX = initialPlayerPositionX;
            player.positionY = initialPlayerPositionY;

            mapDrawn = false;
            Console.Clear();
            Console.ResetColor();
        }
    }
}
