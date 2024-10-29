using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FirstPlayable
{
    internal class ItemManager
    {
        private Player player;
        private Settings settings;
        public Dictionary<string, Item> Items { get; set; }

        public ItemManager(Player player,Settings Settings)
        {
            this.player = player;
            this.settings = Settings;
            Debug.WriteLine("Health name: " + settings.HealthName);
            Items = new Dictionary<string, Item>
        {
            { settings.HealthName, new HealthPotion() },
            { settings.DamageName.ToString(), new DamageBoost() },
            { settings.SeedName.ToString(), new Seed() }
        };
        }
        public void UseItem(string itemName)
        {
            if (Items.ContainsKey(itemName))
            {
                Items[itemName].Use(player);
            }
        }
    }
}
