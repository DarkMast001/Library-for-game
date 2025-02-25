using System.Text;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Перечисление типов корабля
    /// </summary>
    public enum shipType
    {
        Transport,
        Millitary,
        MillitaryTransport
    }

    /// <summary>
    /// Класс описания капитана
    /// </summary>
    public class Captain
    {
        private string[] ranks = {  "Sailor", "Senior Sailor", "Chief Petty Officer", "Midshipman",
                                    "Lieutenant", "Rear Admiral", "Admiral" };

        private string name;
        private string surname;
        private string fatherName;
        private string rank;

        /// <summary>
        /// Конструктор по умолчанию
        /// 
        /// Случайным образом генерирует имя, фамилию, отчество и ранг капитана.Ранг капитана берётся случайным образом из массива рангов
        /// </summary>
        public Captain()
        {
            Random rand = new Random();
            name = wordGenerator(rand);
            surname = wordGenerator(rand);
            fatherName = wordGenerator(rand);
            rank = ranks[rand.Next(ranks.Length)];
        }

        /// <summary>
        /// Копирующий конструктор
        /// 
        /// Создаёт копию экземпляра класса <c>Captain</c>.Если в качестве параметра передать <c>null</c>, то имя, фамилия, отчество и ранг будут заданы как "NONE"
        /// </summary>
        /// <param name="captain">Экземпляр класса <c>Captain</c>, который необходимо скопировать.Может принимать <c>null</c>></param>
        public Captain(Captain? captain)
        {
            if (captain == null)
            {
                name = "NONE";
                surname = "NONE";
                fatherName = "NONE";
                rank = "NONE";
            }
            else
            {
                name = captain.name;
                surname = captain.surname;
                fatherName = captain.fatherName;
                rank = captain.rank;
            }
        }

        /// <summary>
        /// Конструктор с входными параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="fatherName">Отчество</param>
        public Captain(string name, string surname, string fatherName)
        {
            Random rand = new Random();
            this.name = name;
            this.surname = surname;
            this.fatherName = fatherName;
            rank = ranks[rand.Next(ranks.Length)];
        }

        /// <summary>
        /// Получить или задать имя капитана
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Получить или задать фамилию капитана
        /// </summary>
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        /// <summary>
        /// Получить или задать отчество капитана
        /// </summary>
        public string FatherName
        {
            get => fatherName;
            set => fatherName = value;
        }

        /// <summary>
        /// Получить или задать ранг капитана
        /// </summary>
        /// <exception cref="ArgumentException">Если попытаться присвоить ранг, которого нет в массиве рангов</exception>
        public string Rank
        {
            set
            {
                for(int i = 0; i < ranks.Length; i++)
                {
                    if (value == ranks[i])
                        rank = value;
                }
                if (rank != value)
                    throw new ArgumentException();
            }
            get => rank;
        }

        /// <summary>
        /// Получить массив рангов
        /// </summary>
        public string[] Ranks
        {
            get => ranks;
        }

        /// <summary>
        /// Выводит информацию о капитане (имя, фамилия, отчество, ранг)
        /// </summary>
        public void printCaptain()
        {
            Console.WriteLine($"Name: {name}\nSurname: {surname}\nFather name: {fatherName}\nRank: {rank}");
        }

        private string wordGenerator(Random random)
        {
            int breakpoint = random.Next(1, 11);
            char randomLetter;
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < breakpoint; i++)
            {
                if (i == 0)
                    randomLetter = (char)('A' + random.Next(0, 27));
                else
                    randomLetter = (char)('a' + random.Next(0, 27));
                word.Append(randomLetter);
            }

            return word.ToString();
        }
    }

    /// <summary>
    /// Класс-описатель корабля с общими для всех типов свойствами
    /// 
    /// Класс описывает общую логику и свойства для 3 разных типов кораблей - наследников этого класса
    /// </summary>
    public abstract class Ship
    {
        private protected shipType typeOfShip;          ///< Тип корабля
        private protected string shipName;              ///< Позывной корабля
        private protected Captain captain;              ///< Капитан корабля
        private protected int price;                    ///< Цена корабля
        private protected float maxSpeed;               ///< Максимальная скорость корабля
        private protected float currentSpeed;           ///< Текущая скорость корабля
        private protected float maxSurvivability;       ///< Максимальная живучесть корабля (максимальное количество очков прочности)
        private protected float currentSurvivability;   ///< Текущая живучесть корабля (текущее количество очков прочности)
        private protected float mass;                   ///< Масса корабля

        private bool isAlive = true;                    ///< Состояние корабля (на плаву / затоплен)

        /// <summary>
        /// Конструктор класса <c>Ship</c>
        /// </summary>
        /// <param name="typeOfShip">Тип корабля</param>
        /// <param name="shipName">Позывной корабля</param>
        /// <param name="price">Цена корабля</param>
        /// <param name="maxSpeed">Максимальная скорость корабля</param>
        /// <param name="maxSurvivability">Максимальная живучесть корабля</param>
        /// <param name="mass">Масса корабля</param>
        /// <exception cref="ArgumentOutOfRangeException">Если ввести не корректные значения, например <c>maxSpeed <= 0</c></exception>
        private protected Ship(shipType typeOfShip, string shipName, int price, float maxSpeed, float maxSurvivability, float mass)
        {
            this.typeOfShip = typeOfShip;
            this.shipName = shipName;
            captain = new Captain(default(Captain));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            else
                this.price = price;

            if (maxSpeed <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSpeed));
            else
                this.maxSpeed = maxSpeed;

            if (maxSurvivability <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSurvivability));
            else
            {
                this.maxSurvivability = maxSurvivability;
                currentSurvivability = maxSurvivability;
            }

            if (mass <= 0)
                throw new ArgumentOutOfRangeException(nameof(mass));
            else
                this.mass = mass;
        }

        /*private protected Ship( shipType typeOfShip, string shipName, int price, float maxSpeed, float maxSurvivability, float mass, 
                        string captainName, 
                        string captainSurname,
                        string captainFatherName) : this(typeOfShip, shipName, price, maxSpeed, maxSurvivability, mass)
        {
            captain.Name = captainName;
            captain.Surname = captainSurname;
            captain.fatherName = captainFatherName;
        }*/

        /// <summary>
        /// Получить тип корабля
        /// </summary>
        public shipType ShipType { get => typeOfShip; } 

        /// <summary>
        /// Получить цену корабля
        /// </summary>
        public int Price { get => price; }

        /// <summary>
        /// Получить позывной корабля
        /// </summary>
        public string ShipName
        {
            get { return shipName; }
            set { shipName = value; }
        }

        /// <summary>
        /// Получить или установить капитана корабля
        /// </summary>
        public Captain Captain 
        { 
            get => captain; 
            set => captain = value;
        }

        /// <summary>
        /// Получить или установить максимальную скорость
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Если максимальная скорость <c><= 0</c> или максимальная скорость <c><</c> текущей скорости</exception>
        public virtual float MaxSpeed
        {
            get => maxSpeed;
            set 
            {
                if (value <= 0 || value < currentSpeed)
                    throw new ArgumentOutOfRangeException("Max speed cant't be <=0 or <= current speed");
                maxSpeed = value;
            }
        }

        /// <summary>
        /// Получить или установить текущую скорость
        /// 
        /// Если устанавливаемое значение < 0, то установится 0, а если больше максимальной скорости, то установится значение максимальной скорости
        /// </summary>
        public virtual float CurrentSpeed
        {
            get => currentSpeed;
            set
            {
                if (value < 0)
                    currentSpeed = 0;
                else if (value > maxSpeed)
                    currentSpeed = maxSpeed;
                else
                    currentSpeed = value;
            }
        }

        /// <summary>
        /// Получить максимальную живучесть
        /// </summary>
        public float MaxSurvivability
        {
            get => maxSurvivability;
        }

        /// <summary>
        /// Получить текущую живучесть
        /// </summary>
        public float CurrentSurvivability
        {
            get => currentSurvivability;
        }

        /// <summary>
        /// Получить массу
        /// </summary>
        public float Mass { get => mass; }

        /// <summary>
        /// Получить состояние корабля
        /// </summary>
        public bool IsAlive
        {
            get => isAlive;
        }

        /// <summary>
        /// Функция уменьшения текущей живучести
        /// </summary>
        /// <param name="quantity">Количество очков живучести, на которые надо уменьшить текущее значение</param>
        public void reduceCurrentSurviability(float quantity)
        {
            currentSurvivability -= quantity;
            if (currentSurvivability < 0)
            {
                currentSurvivability = 0f;
                isAlive = false;
            }
        }

        /// <summary>
        /// Вывод информации о корабле в консоль
        /// </summary>
        public virtual void info()
        {
            Console.WriteLine($"Ship type: {typeOfShip}\nShip name: {shipName}\nMax seed: {maxSpeed}\n" +
                                $"Max surviability: {maxSurvivability}\nPrice: {price}\n-----------------\n" +
                                $"Current speed: {currentSpeed}\nCurrent surviability: {currentSurvivability}\n");
        }
    }
}