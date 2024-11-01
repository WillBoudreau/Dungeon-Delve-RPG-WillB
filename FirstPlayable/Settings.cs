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
            //Debug Check\
            Debug.WriteLine("Loading settings");
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
        // Player settings
        public int PlayerInitialHealth { get; set; }
        public int PlayerInitialDamage { get; set; }
        public int PlayerInitialLevel { get; set; }
        // Goblin settings
        public int GoblinInitialHealth { get; set; }
        public int GoblinInitialDamage { get; set; }
        public char GoblinIcon { get; set; }
        public string GoblinName { get; set; }
        // world Settings
        public string[] RPGMaps { get; set; } = new string[4];
        public string NameOfGame { get; set; }
        public char HealthPotionIcon { get; set; }
        public char DamagePotionIcon { get; set; }
        public char SpikeTrapIcon { get; set; }
        //Item settings
        public string HealthName { get; set; }
        public string DamageName { get; set; }
        public string SeedName { get; set; }
        //Potion Shop settings
        public int MinHealthCost { get; set; }
        public int MidHealthCost { get; set; }
        public int MaxHealthCost { get; set; }
        //Sword Shop settings
        public int MinDamageCost { get; set; }
        public int MidDamageCost { get; set; }
        public int MaxDamageCost { get; set; }
        //Bonus Shop settings
        public int MinBonusCost { get; set; }
        public int MidBonusCost { get; set; }
        public int MaxBonusCost { get; set; }
        // Runner settings
        public int RunnerInitialHealth { get; set; }
        public int RunnerInitialDamage { get; set; }
        public char RunnerIcon { get; set; }
        public string RunnerName { get; set; }
        // Music settings
        public string MusicFileName { get; set; }
        public string FileLocation { get; set; }
        // Boss settings
        public int BossInitialHealth { get; set; }
        public int BossInitialDamage { get; set; }
        public string BossName { get; set; }
        //map settings
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public char PotionShopIcon { get; set; }
        public char SwordShopIcon { get; set; }
        
        //Spawn Settings
        public char GoblinSpawnPos { get; set; }
        public char RunnerSpawnPos { get; set; }
        public char BossSpawnPos { get; set; }
        public char PlayerSpawnPos { get; set; }
        //Quest Settings
        public int NumOfKills { get; set; }
        public int NumOfItems { get; set; }


        public enum conColor 
        {
            Black, 
            DarkBlue, 
            DarkGreen, 
            DarkCyan, 
            DarkRed, 
            DarkMagenta, 
            DarkYellow, 
            Gray, 
            DarkGray, 
            Blue, 
            Green, 
            Cyan, 
            Red, 
            Magenta, 
            Yellow, 
            White
        };
        public void SetColor(string color)
        {
           foreach(string colorName in Enum.GetNames(typeof(conColor)))
            {
                if(colorName == color)
                {
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
                }
            }
        }

    }
}

