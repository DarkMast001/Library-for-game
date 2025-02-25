using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Тип оружия
    /// </summary>
    public enum WeaponType
    {
        Heavy,
        Medium,
        Light
    }

    public enum Direction
    {
        Left,
        Right
    }

    /// <summary>
    /// Класс, описывающий оружие
    /// </summary>
    public class Weapon
    {
        private WeaponType type;
        private AmmoType typeOfAmmo;
        private List<Ammo> ammoList = new List<Ammo>();
        private bool readyToShoot;
        private float rateOfFire;
        private float reloadTime;
        private float firingRange;
        private int maxAmmunition;
        private int currentAmmunition;
        private int price;

        /// <summary>
        /// Конструктор по умолчанию
        /// 
        /// Создаёт абсолютно не заполненный никакими параметрами экземпляр класса Weapon
        /// </summary>
        public Weapon() { }

        /// <summary>
        /// Конструктор, создающий экземпляр класса Weapon по введённым параметрам
        /// </summary>
        /// <param name="type">Тип оружия</param>
        /// <param name="reloadTime">Время перезарядки</param>
        /// <param name="firingRange">Дальность стрельбы</param>
        /// <param name="maxAmmunition">Максимальный боезапас</param>
        /// <param name="currentAmmunition">Текущий боезапас</param>
        /// <param name="price">Цена</param>
        /// <exception cref="ArgumentOutOfRangeException">Если введено не корректное значение для оружия</exception>
        public Weapon(WeaponType type, float reloadTime, float firingRange, int maxAmmunition, int currentAmmunition, int price)
        {
            this.type = type;
            if (type == WeaponType.Heavy)
                typeOfAmmo = AmmoType.Heavy;
            else if (type == WeaponType.Medium)
                typeOfAmmo = AmmoType.Medium;
            else
                typeOfAmmo = AmmoType.Light;
            if (reloadTime <= 0)
                throw new ArgumentOutOfRangeException();
            this.reloadTime = reloadTime;
            rateOfFire = 60f / this.reloadTime;
            if (firingRange <= 0)
                throw new ArgumentOutOfRangeException();
            this.firingRange = firingRange;
            if (maxAmmunition <= 0)
                throw new ArgumentOutOfRangeException();
            this.maxAmmunition = maxAmmunition;
            if (currentAmmunition <= 0 || currentAmmunition > maxAmmunition)
                throw new ArgumentOutOfRangeException();
            CurrentAmmunition = currentAmmunition;
            if (price < 0)
                throw new ArgumentOutOfRangeException();
            this.price = price;
            readyToShoot = true;
        }

        /*public Weapon(WeaponType type)
        {
            this.type = type;
            readyToShoot = true;
            if (type == WeaponType.Heavy)
            {
                typeOfAmmo = AmmoType.Heavy;
                reloadTime = 19f;
                rateOfFire = 60f / reloadTime;
                firingRange = 10000f;
                maxAmmunition = 20;
                currentAmmunition = 0;
                price = 3000;
            }
            else if (type == WeaponType.Medium)
            {
                typeOfAmmo = AmmoType.Medium;
                reloadTime = 14f;
                rateOfFire = 60f / reloadTime;
                firingRange = 7000f; // 7km
                maxAmmunition = 35;
                currentAmmunition = 0;
                price = 2000;
            }
            else
            {
                typeOfAmmo = AmmoType.Light;
                reloadTime = 8f;
                rateOfFire = 80f / reloadTime;
                firingRange = 5000f; // 5km
                maxAmmunition = 50;
                currentAmmunition = 0;
                price = 1000;
            }
        }

        public Weapon(WeaponType type, int ammoSize) : this(type)
        {
            if (ammoSize > maxAmmunition)
            {
                throw new ArgumentOutOfRangeException("Too much ammunition");
            }
            currentAmmunition = ammoSize;
            for (int i = 0; i < ammoSize; i++)
            {
                Ammo ammo;
                if (type == WeaponType.Heavy)
                    ammo = new Ammo(AmmoType.Heavy);
                else if (type == WeaponType.Medium)
                    ammo = new Ammo(AmmoType.Medium);
                else
                    ammo = new Ammo(AmmoType.Light);
                ammoList.Add(ammo);
            }
        }*/

        /// <summary>
        /// Статический метод, который возвращает стандартное оружие, соответствующее его типу
        /// </summary>
        /// <param name="type">Тип оружия</param>
        /// <returns>Экземпляр класса Weapon с заданными значениями</returns>
        public static Weapon setDefaultWeapon(WeaponType type)
        {
            Weapon w = new Weapon();
            if (type == WeaponType.Heavy)
            {
                w.type = WeaponType.Heavy;
                w.typeOfAmmo = AmmoType.Heavy;
                w.reloadTime = 19f;
                w.rateOfFire = 60f / w.reloadTime;
                w.firingRange = 1400f;
                w.maxAmmunition = 20;
                w.currentAmmunition = 0;
                w.price = 3000;
            }
            else if (type == WeaponType.Medium)
            {
                w.type = WeaponType.Medium;
                w.typeOfAmmo = AmmoType.Medium;
                w.reloadTime = 14f;
                w.rateOfFire = 60f / w.ReloadTime;
                w.firingRange = 1200f; // 7km
                w.maxAmmunition = 35;
                w.currentAmmunition = 0;
                w.price = 2000;
            }
            else
            {
                w.type = WeaponType.Light;
                w.typeOfAmmo = AmmoType.Light;
                w.reloadTime = 8f;          //////////////// CHANGE FOR TESTING (NORMAL VALUE = 8F)
                w.rateOfFire = 60f / w.reloadTime;
                w.firingRange = 1000f; // 5km
                w.maxAmmunition = 50;
                w.currentAmmunition = 0;
                w.price = 1000;
            }
            w.readyToShoot = true;
            return w;
        }

        /// <summary>
        /// Получить тип оружия
        /// </summary>
        public WeaponType Type { get => type; }

        /// <summary>
        /// Получить тип снаряда, используемое этим оружием
        /// </summary>
        public AmmoType TypeOfAmmo { get => typeOfAmmo; }

        /// <summary>
        /// Получить готовность к выстрелу
        /// </summary>
        public bool ReadyToShoot { get => readyToShoot; }

        /// <summary>
        /// Получить скорострельность
        /// </summary>
        public float RateOfFire { get => rateOfFire; }

        /// <summary>
        /// Получить время перезарядки
        /// </summary>
        public float ReloadTime { get => reloadTime; }

        /// <summary>
        /// Получить дальность стрельбы
        /// </summary>
        public float FiringRange { get => firingRange; }

        /// <summary>
        /// Получить максимальный боезапас
        /// </summary>
        public int MaxAmmunition { get => maxAmmunition; }

        /// <summary>
        /// Получить цену оружия
        /// </summary>
        public int Price { get => price; }

        /// <summary>
        /// Получить или установить текущий боезапас
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Если попытаться установить боезапас < 0</exception>
        public int CurrentAmmunition
        {
            get => currentAmmunition;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                if (value > currentAmmunition)
                    increaseAmmo(value - currentAmmunition);
                else if (value < currentAmmunition)
                    reduceAmmo(currentAmmunition - value);
                else
                    currentAmmunition = value;
                /*if (value <= maxAmmunition)
                {
                    if (value < 0)
                        currentAmmunition = 0;
                    else
                        currentAmmunition = value;
                }
                else
                    currentAmmunition = value;*/
            }
        }

        /// <summary>
        /// Получить урон
        /// </summary>
        /// <returns>Значение уроня для заряженного типа снаряда</returns>
        public float getDamage()
        {
            return Ammo.getDamage(typeOfAmmo);
        }

        private void increaseAmmo(int quantity)
        {
            if (currentAmmunition + quantity <= maxAmmunition)
                currentAmmunition += quantity;
            else if (currentAmmunition == maxAmmunition)
                return;
            else
                currentAmmunition = maxAmmunition;
            for (int i = ammoList.Count; i < currentAmmunition; i++)
            {
                Ammo ammo;
                if (type == WeaponType.Heavy)
                    ammo = new Ammo(AmmoType.Heavy);
                else if (type == WeaponType.Medium)
                    ammo = new Ammo(AmmoType.Medium);
                else
                    ammo = new Ammo(AmmoType.Light);
                ammoList.Add(ammo);
            }
        }

        private void reduceAmmo(int quantity)
        {
            if (currentAmmunition - quantity >= 0)
            {
                currentAmmunition -= quantity;
                int size = ammoList.Count;
                for(int i = size - 1; i >= currentAmmunition; i--)
                {
                    ammoList.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Произвести выстрел
        /// </summary>
        /// <exception cref="Exception">Если оружи ещё не готово к выстрелу или нет снарядов</exception>
        public void fire()
        {
            if (currentAmmunition > 0 && readyToShoot)
            {
                currentAmmunition -= 1;
                ammoList.RemoveAt(ammoList.Count - 1);
                readyToShoot = false;
            }
            else
                throw new Exception("No ammo or weapon is being reloaded");
            if (!readyToShoot)
            {
                Thread reloadThread = new Thread(reload);
                reloadThread.Start();
            }
        }

        private void reload()
        {
            DateTime time = DateTime.Now;
            while (true)
            {
                if ((DateTime.Now - time).Seconds == reloadTime)
                {
                    readyToShoot = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Вывод информации об оружии в консоль
        /// </summary>
        public void info()
        {
            Console.WriteLine($"Type: {type}\n\nRate of fire: {rateOfFire}\nFiring range: {firingRange}\n" +
                                $"Maximum ammunition: {maxAmmunition}\nCurrent ammunition: {currentAmmunition}\n" +
                                $"Price: {price}\nReady to shoot: {readyToShoot}");
        }
    }
}
