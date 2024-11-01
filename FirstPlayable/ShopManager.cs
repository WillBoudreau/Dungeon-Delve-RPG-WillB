using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class ShopManager
    {
        private List<Shop> Shops;
        private Settings settings;
        Map map;
        public ShopManager(Map map,Settings settings)
        {
            this.map = map;
            this.settings = settings;
            Shops = new List<Shop>();
            Shops.Add(new PotionShop(map,settings));
            Shops.Add(new SwordShop(map,settings));
            Shops.Add(new BoostShop(map,settings));
        }

        public void Init(Map map)
        {
            //Initializes the shops
            for (int i = 0; i< map.layout.GetLength(0); i++)
            {
                for (int j = 0; j < map.layout.GetLength(1); j++)
                {
                    if (map.layout[i, j] == settings.PotionShopIcon)
                    {
                        SpawnShop('P', map,j,i);
                    }
                    else if (map.layout[i, j] == settings.SwordShopIcon)
                    {
                        SpawnShop('S', map, j, i);
                    }
                    else if (map.layout[i,j] == 'U')
                    {
                        SpawnShop('U', map, j, i);
                    }
                }
            }
        }
        public void EnterShop(Player player,string ShopType)
        {
            //Enter the shop
            if(ShopType == settings.PotionShopIcon.ToString())
            {
                Shops[0].EnterShop(player);
            }
            else if(ShopType == settings.SwordShopIcon.ToString())
            {
                Shops[1].EnterShop(player);
            }
            else if(ShopType == "U")
            {
                Shops[2].EnterShop(player);
            }
        }
        public void SpawnShop(char tile,Map map,int x,int y)
        {
            //Spawns a shop
            if (IsValidTile(tile))
            {
                Shop shop = CreateShop(tile, map);
                if(shop != null)
                {
                    Shops.Add(shop);
                }
            }
        }

        private bool IsValidTile(char tile)
        {
            //Checks if the tile is a valid shop tile
            return tile == settings.SwordShopIcon|| tile == 'P' || tile =='U';
        }

        private Shop CreateShop(char tile, Map map)
        {
            //Creates a shop
            switch(tile)
            {
                case 'S':
                    return new SwordShop(map,settings);
                case 'P':
                    return new PotionShop(map, settings);
                case 'U':
                    return new BoostShop(map, settings);
                default:
                    return null;
            }    
        }
    }
}
