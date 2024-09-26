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

        public void Init()
        {
            SpawnShop('S');
        }

        public void SpawnShop(char tile)
        {
            if (IsValidTile(tile))
            {
                Shop shop = CreateShop(tile);
                Shops.Add(shop);
            }
        }

        private bool IsValidTile(char tile)
        {
            return true;
        }

        private Shop CreateShop(char tile)
        {
            return new PotionShop();
        }
    }
}
