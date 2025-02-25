using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Стороны корабля, к которым можно крепить орудия
    /// </summary>
    public enum Side
    {
        Left,
        Right,
        Bow,
        Sterm
    }

    /// <summary>
    /// Класс-описатель для военного корабля
    /// </summary>
    public class MillitaryShip : Ship
    {
        private ModDictionary<Side, Weapon> weapons = new ModDictionary<Side, Weapon>();

        /// <summary>
        /// Конструктор класса MillitaryShip
        /// </summary>
        /// <param name="shipName">Позывной корабля</param>
        /// <param name="price">Цена корабля</param>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="maxSurvivability">Максимальное количество единиц здоровья</param>
        /// <param name="mass">Масса корабля (тонн)</param>
        public MillitaryShip(string shipName, int price, float maxSpeed, float maxSurvivability, float mass) 
            : base(shipType.Millitary, shipName, price, maxSpeed, maxSurvivability, mass)
        {
            
        }

        public override float CurrentSpeed 
        { 
            get => base.CurrentSpeed; 
            set => base.CurrentSpeed = value;
        }

        /// <summary>
        /// Добавляет оружие на корабль
        /// </summary>
        /// <param name="weapon">Экземпляр класса Weapon</param>
        /// <param name="side">Сторона корабля</param>
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

        public void setWeapons(ModDictionary<Side, Weapon> weapons)
        {
            this.weapons = weapons;
        }

        /// <summary>
        /// Вывод информации о военном корабле в консоль
        /// </summary>
        public override void info()
        {
            base.info();
            foreach (var item in weapons)
            {
                Console.WriteLine($"Side: {item.Value} || Weapon: {item.Value.Type}");
            }
        }
    }
}
