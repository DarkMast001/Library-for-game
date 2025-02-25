using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Тип снарядов
    /// </summary>
    public enum AmmoType
    {
        Heavy,
        Medium,
        Light
    }

    /// <summary>
    /// Класс снаряда
    /// </summary>
    public class Ammo
    {
        private static float damageHeavy = 300f;
        private static float damageMedium = 200f;
        private static float damageLight = 100f;

        private AmmoType type;
        private float damage;

        private Ammo() { }

        /// <summary>
        /// Конструктор, который создаёт снаряд по его типу
        /// </summary>
        /// <param name="type">Тип снаряда</param>
        public Ammo(AmmoType type) 
        {
            this.type = type;
            if (type == AmmoType.Heavy)
                damage = damageHeavy;
            else if (type == AmmoType.Medium)
                damage = damageMedium;
            else
                damage = damageLight;
        }

        /// <summary>
        /// Получить тип снаряда
        /// </summary>
        public AmmoType Type {  get => type;  }

        /// <summary>
        /// Получить урон снаряда
        /// </summary>
        public float Damage { get => damage; }

        /// <summary>
        /// Получить урон снаряда в зависимости от его типа
        /// </summary>
        /// <param name="type">Тип снаряда</param>
        /// <returns>Урон</returns>
        public static float getDamage(AmmoType type)
        {
            if (type == AmmoType.Heavy)
                return damageHeavy;
            if (type == AmmoType.Medium)
                return damageMedium;
            else
                return damageLight;
        }
    }
}
