using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace FirstPlayable
{
    internal class Settings
    {
        public Settings()
        {
            Debug.WriteLine("Grunt Health: " + GoblinInitialHealth);
        }
        
        // Player settings
        public int PlayerInitialHealth { get; set; }
        public int PlayerInitialDamage { get; set; }
        public int PlayerInitialLevel { get; set; }

        // world Settings
        public string[] RPGMaps { get; set; } = { "RPGMap.txt", "RPGMap2.txt", "RPGMap3.txt", "RPGMap4.txt" };
        public string MapFileName { get; set; } = "RPGMap.txt";
        public string Map2FileName { get; set; } = "RPGMap2.txt";
        public string Map3FileName { get; set; } = "RPGMap3.txt";
        public string Map4FileName { get; set; } = "RPGMap4.txt";
        public string MusicFileName { get; set; } = "DungeonMap.wav";

        public string FileLocation { get; set; } = @"Maps-Music";
        


        // Goblin settings

        public int GoblinInitialHealth { get; set; }
        public int GoblinInitialDamage { get; set; }



        // Boss settings
        public int BossInitialHealth { get; set; } = 28;
        public int BossInitialDamage { get; set; } = 2;


        // Runner settings
        public int RunnerInitialHealth { get; set; } = 1;
        public int RunnerInitialDamage { get; set; } = 2;
        public static Settings LoadSettings(string path)
        {
            Debug.WriteLine(path);
            Debug.WriteLine("File found");
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Settings>(json);
        }
    }
}

