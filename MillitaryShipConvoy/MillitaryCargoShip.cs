using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Класс-описатель для военно-грузового корябля
    /// </summary>
    public class MillitaryCargoShip : Ship
    {
        private float maxWeight;         ///< Максимально допустимый вес груза
        private float currentWeight;     ///< Текущий вес груза
        private float maxSpeedOwn;

        private const float coefficientByTon = 0.000025f;   ///< Уоэффициент уменьшения скорости корабля в зависимости от загрузки
        private ModDictionary<Side, Weapon> weapons = new ModDictionary<Side, Weapon>();

        /// <param name="shipName">Позывной корабля</param>
        /// <param name="price">Цена корабля</param>
        /// <param name="maxSpeed">Максимальная скорость (узлы). Рекомендуемое значение: 40</param>
        /// <param name="maxSurvivability">Максимальное количество единиц здоровья</param>
        /// <param name="massOfShip">Масса корабля (тонн). Рекоммендуемое значение: 30.000</param>
        /// <param name="maxWeight">Максимально допустимый вес груза (тонн). Рекоммендуемое значение: 20.000</param>
        /// <exception cref="ArgumentOutOfRangeException">Если введённая максимальная грузоподъёмность <= 0</exception>
        public MillitaryCargoShip(string shipName, int price, float maxSpeed, float maxSurvivability, float massOfShip, float maxWeight)
            : base(shipType.Transport, shipName, price, maxSpeed, maxSurvivability, massOfShip)
        {
            if (maxWeight <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxWeight));
            this.maxWeight = maxWeight;
            maxSpeedOwn = maxSpeed;
        }

        /// <summary>
        /// Получить или установить текущую загруженность корабля
        /// </summary>
        public float CurrentWeight
        {
            get => currentWeight;
            set
            {
                if (value < 0)
                    currentWeight = 0;
                else if (value > maxWeight)
                    currentWeight = maxWeight;
                else
                    currentWeight = value;

                base.MaxSpeed = CargoService.countMaxSpeed(maxSpeedOwn, currentWeight, coefficientByTon);
            }
        }

        public override float MaxSpeed
        {
            get => base.MaxSpeed;
            set
            {
                base.MaxSpeed = value;
                maxSpeedOwn = value;
            }
        }

        /// <summary>
        /// Получить или установить текущую скорость в зависимости от загруженности корабля
        /// </summary>
        public override float CurrentSpeed
        {
            get => base.CurrentSpeed;
            set
            {
                if (value > maxSpeed)
                    value = maxSpeed;
                else if (value < 0)
                    value = 0;
                base.CurrentSpeed = value;
            }
        }

        /// <summary>
        /// Получить максимально допустимый вес груза
        /// </summary>
        public float MaxWeight { get => maxWeight; }

        public void addWeapon(Weapon weapon, Side side)
        {
            weapons.Add(side, weapon);
        }

        /// <summary>
        /// Считает стоимость всех оружий, установленных на корабле
        /// </summary>
        /// <returns>Стоимость всего вооружения</returns>
        public int countPriceWeapon()
        {
            return MillitaryService.countPriceWeapon(weapons);
        }

        /// <summary>
        /// Считает стоимость оружия, установленного на определённой стороне
        /// </summary>
        /// <param name="side">Сторона, на которой надо провести подсчёт</param>
        /// <returns>Стоимость вооружения с конкретной стороны</returns>
        public int countPriceWeapon(Side side)
        {
            return MillitaryService.countPriceWeapon(weapons, side);
        }

        public ModDictionary<Side, Weapon> getWeapons()
        {
            return weapons;
        }

        /// <summary>
        /// Вывод информации о военно-грузовом корабле в консоль
        /// </summary>
        public override void info()
        {
            base.info();
            foreach (var item in weapons)
            {
                Console.WriteLine($"Side: {item.Value} || Weapon: {item.Value.Type}");
            }
            Console.WriteLine($"Max cargo weight: {maxWeight}\nCurrent cargo weight: {currentWeight}\n");
        }
    }
}
