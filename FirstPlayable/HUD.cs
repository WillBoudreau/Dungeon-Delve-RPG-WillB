using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class HUD
    {
        private Player player;
        private Map map;
        private QuestManager questManager;
        public HUD(Player player, Map map,QuestManager questManager)
        {
            this.player = player;
            this.map = map;
            this.questManager = questManager;
        }
        public void Update()
        {
           UpdateHUD();
           UpdateLegend();
        }
        public void UpdateHUD()
        {
            string currentEnemyInfo = player.currentEnemy != null ? $"{player.currentEnemy.Name} | HP Remaining: ({player.currentEnemy.healthSystem.GetCurrentHealth()}/{player.currentEnemy.healthSystem.GetMaximumHealth()})" : "None";
            Console.SetCursorPosition(0, map.mapHeight + 1);
            Console.WriteLine($"Player Health: {player.healthSystem.GetCurrentHealth()}/{player.healthSystem.GetMaximumHealth()} | Collected Seeds: {player.currentSeeds}| Kill Count: {player.KillCount} | Attacking: {currentEnemyInfo}");
            RedrawLiveLog();
            UpdateQuestLog();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void UpdateLegend()
        {
            Console.SetCursorPosition(0, map.mapHeight + 2);
            Console.WriteLine($"\nPlayer Damage Level: {player.playerDamage}");
        }

        public void DisplayLiveLog(List<string> liveLog)
        {
            Console.SetCursorPosition(0, map.mapHeight + 7);

            Console.WriteLine("Live Log:");

            int logLimit = Math.Min(3, liveLog.Count); // Limits log to 3 most recent messages
            int startIndex = liveLog.Count - logLimit;

            for (int i = liveLog.Count - 1; i >= startIndex; i--)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine(liveLog[i]);
            }


            Console.ResetColor();
        }

        public void RedrawLiveLog()
        {
            int startLine = map.mapHeight + 7;
            List<string> liveLog = player.GetLiveLog();
            int startIndex = Math.Max(0, liveLog.Count - 3);

            for (int i = 2; i >= 0; i--)
            {
                Console.SetCursorPosition(0, startLine + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            for (int i = 2; i >= 0; i--)
            {
                int index = startIndex + (2 - i);
                if (index >= 0 && index < liveLog.Count)
                {
                    string message = liveLog[index];
                    Console.SetCursorPosition(0, startLine + i);
                    Console.WriteLine(message);
                }
            }
        }
        public void DrawQuestLog()
        {
            Console.SetCursorPosition(0, map.mapHeight + 12);
            Console.WriteLine("Quests: ");
        }
        public void UpdateQuestLog()
        {
            List<string> questProgressMessages = new List<string>();
            DrawQuestLog();
            var quests = questManager.GetActiveQuests();
            foreach (var quest in quests)
            {
                questProgressMessages.Add(quest.Progress());
            }
            Console.WriteLine(string.Join("\n", questProgressMessages));
        }
    }
}
