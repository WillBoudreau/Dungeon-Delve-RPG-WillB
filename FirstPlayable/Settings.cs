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
        public static Settings LoadSettings(string path)
        {
            //Debug Check
            if(!File.Exists(path))
            {
                Debug.WriteLine("File not found");
                return new Settings();
            }
            else
            {
                Debug.WriteLine("File found");
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Settings>(json);
            }
        }
        public int PlayerInitialHealth { get; set; }
        public int PlayerInitialDamage { get; set; }
        public int PlayerInitialLevel { get; set; }
        public int GoblinInitialHealth { get; set; }
        public int GoblinInitialDamage { get; set; }
        // world Settings
        public string[] RPGMaps { get; set; } = new string[] { "RPGMap.txt", "RPGMap2.txt", "RPGMap3.txt", "RPGMap4.txt" };
        // Runner settings
        public int RunnerInitialHealth { get; set; }
        public int RunnerInitialDamage { get; set; }
        //public string MapFileName { get; set; }
        //public string Map2FileName { get; set; }
        //public string Map3FileName { get; set; }
        //public string Map4FileName { get; set; }
        public string MusicFileName { get; set; } = "DungeonMap.wav";

        public string FileLocation { get; set; } = @"Maps-Music";
        




        // Boss settings
        public int BossInitialHealth { get; set; } = 28;
        public int BossInitialDamage { get; set; } = 2;


    }
}

