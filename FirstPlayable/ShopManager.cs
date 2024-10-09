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
        Map map;
        public ShopManager(Map map)
        {
            this.map = map;
            Shops = new List<Shop>();
            Shops.Add(new PotionShop(map));
            Shops.Add(new SwordShop(map));
            Shops.Add(new BoostShop(map));
        }

        public void Init(Map map)
        {
            for (int i = 0; i< map.layout.GetLength(0); i++)
            {
                for (int j = 0; j < map.layout.GetLength(1); j++)
                {
                    if (map.layout[i, j] == 'P')
                    {
                        SpawnShop('P', map,j,i);
                    }
                    else if (map.layout[i, j] == 'S')
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
            Debug.WriteLine(Shops[1]);
            Debug.WriteLine(Shops[0]);
            Debug.WriteLine(Shops[2]);
            if(ShopType == "P")
            {
                Shops[0].EnterShop(player);
            }
            else if(ShopType == "S")
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
            if (IsValidTile(tile))
            {
                Shop shop = CreateShop(tile, map);
                if(shop != null)
                {
                    shop.SetPos(x,y);
                    Shops.Add(shop);
                }
            }
        }

        private bool IsValidTile(char tile)
        {
            return tile == 'S'|| tile == 'P' || tile =='U';
        }

        private Shop CreateShop(char tile, Map map)
        {
            switch(tile)
            {
                case 'S':
                    return new SwordShop(map);
                case 'P':
                    return new PotionShop(map);
                case 'U':
                    return new BoostShop(map);
                default:
                    return null;
            }    
        }
    }
}
