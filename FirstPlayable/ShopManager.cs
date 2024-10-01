using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class ShopManager
    {
        private List<Shop> Shops;
        

        public ShopManager()
        {
            Shops = new List<Shop>();
            Shops.Add(new PotionShop());
        }

        public void Init(Map map)
        {
            SpawnShop('S',map);
        }
        public void EnterShop(Player player)
        {
            foreach (Shop shop in Shops)
            {
                shop.EnterShop(player);
            }
        }
        public void SpawnShop(char tile,Map map)
        {
            if (IsValidTile(tile))
            {
                Shop shop = CreateShop(tile,map);
                Shops.Add(shop);
            }
        }

        private bool IsValidTile(char tile)
        {
            return true;
        }

        private Shop CreateShop(char tile, Map map)
        {
            Shop shop = null;
            for(int i = 0; i <  map.layout.GetLength(0); i++)
            {
                for(int j = 0; j < map.layout.GetLength(1); j++)
                {
                    if (map.layout[i,j] == tile)
                    {
                        shop = new PotionShop();
                        return shop;
                    }
                }
            }
            return shop;
        }
    }
}
