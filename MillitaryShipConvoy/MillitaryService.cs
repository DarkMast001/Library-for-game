using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    internal abstract class MillitaryService
    {
        public static int countPriceWeapon(ModDictionary<Side, Weapon> weapons)
        {
            int sum = 0;
            foreach (var item in weapons)
            {
                sum += item.Value.Price;
            }
            return sum;
        }

        public static int countPriceWeapon(ModDictionary<Side, Weapon> weapons, Side side)
        {
            int sum = 0;
            foreach (var item in weapons)
            {
                if (item.Key == side)
                    sum += item.Value.Price;
            }
            return sum;
        }
    }
}
