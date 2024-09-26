using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class ShopManager 
    {
        public ShopManager()
        {
            List<Shop> Shops = new List<Shop>();
            Shops.Add(new PotionShop());
        }
        public void Init()
        {

        }
        public void SpawnShop()
        {
            
        }
    }
}
