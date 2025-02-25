using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    public class Mission
    {
        private int balance;
        private Table<Ship> tableAlies;
        private Table<Ship> tableEnemies;
        private bool abilityToStartMission;

        private Mission() { }

        public Mission(int balance, Table<Ship> tableAlies) 
        {
            this.balance = balance;
            this.tableAlies = tableAlies;

            int sum = count();
            balance -= sum;
            abilityToStartMission = (balance < 0) ? false : true;

            tableEnemies = generator();
        }

        public Mission(Table<Ship> tableAlies)
        {
            this.tableAlies = tableAlies;
            Random rand = new Random();
            balance = rand.Next(50000, 100000);

            int sum = count();
            balance -= sum;
            abilityToStartMission = (balance < 0) ? false : true;

            tableEnemies = generator();
        }

        public Mission(Table<Ship> tableAlies, Table<Ship> tableEnemies) : this(tableAlies) 
        {
            this.tableEnemies = tableEnemies;
        }

        public int Balance { get => balance; }

        public bool AbilityToStartMission { get => abilityToStartMission; }

        public Table<Ship>? Table { get => tableAlies; }

        public int count()
        {
            int sum = 0;
            if (tableAlies.Count == 0)
                return sum;

            Iterator<Ship> it = new Iterator<Ship>(tableAlies);
            for(it = it.begin(); it.isEnd(); it++)
            {
                Ship? ship = it.get();
                sum += ship.Price;
                if (ship is MillitaryShip millitary)
                    sum += millitary.countPriceWeapon();
                else if (ship is MillitaryCargoShip millitaryCargo)
                    sum += millitaryCargo.countPriceWeapon();

            }
            return sum;
        }

        public Weapon genWeapon()
        {
            Random random = new Random();
            WeaponType type;
            int weaponTypeInt = random.Next(1, 4);
            if (weaponTypeInt == 1)
                type = WeaponType.Light;
            else if (weaponTypeInt == 2)
                type = WeaponType.Medium;
            else
                type = WeaponType.Heavy;



            Weapon weapon = new Weapon();
            return weapon;
        }

        public Table<Ship> generator()
        {
            Random rand = new Random();

            Table<Ship> table = new Table<Ship>();
            int countOfShips = rand.Next(2, 9);
            for(int i = 0; i < countOfShips; i++)
            {
                MillitaryShip ship = new MillitaryShip("Enemy " + (i + 1).ToString(), 0, rand.Next(15, 30), rand.Next(2000, 5000), rand.Next(7000, 15000));
                int countLeftSideWeapon = rand.Next(5);
                int countRightSideWeapon = rand.Next(5);
                int countBowSideWeapon = rand.Next(3);
                int countSternSideWeapon = rand.Next(3);

                for(int j = 0; j < countLeftSideWeapon; j++)
                {
                    ship.addWeapon(genWeapon(), Side.Left);
                }
            }

            return table;
        }
    }
}
