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
        public char GoblinIcon { get; set; }
        // world Settings
        public string[] RPGMaps { get; set; } = new string[4];
        // Runner settings
        public int RunnerInitialHealth { get; set; }
        public int RunnerInitialDamage { get; set; }
        public char RunnerIcon { get; set; }
        //public string MapFileName { get; set; }
        //public string Map2FileName { get; set; }
        //public string Map3FileName { get; set; }
        //public string Map4FileName { get; set; }
        public string MusicFileName { get; set; }
        public string FileLocation { get; set; }
        // Boss settings
        public int BossInitialHealth { get; set; }
        public int BossInitialDamage { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
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

