using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    internal abstract class CargoService
    {
        public static float countMaxSpeed(float maxSpeed, float currentWeight, float coefficientByTon)
        {
            float k = currentWeight * coefficientByTon;
            return (1 - k) * maxSpeed;
        }
    }
}
