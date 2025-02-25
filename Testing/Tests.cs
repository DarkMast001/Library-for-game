using MillitaryShipConvoy;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Testing
{
    public class Tests
    {
        [Fact]
        public void ConstructorCargoTest()
        {
            // Тест штатных значений конструктора
            CargoShip cargoShip = new CargoShip("Avrora", 1000, 40, 1000, 30000, 20000);

            Assert.Equal(shipType.Transport, cargoShip.ShipType);
            Assert.Equal(0, cargoShip.CurrentWeight);
            Assert.Equal("Avrora", cargoShip.ShipName);
            Assert.Equal(1000, cargoShip.Price);
            Assert.Equal(40, cargoShip.MaxSpeed);
            Assert.Equal(0, cargoShip.CurrentSpeed);
            Assert.Equal(1000, cargoShip.MaxSurvivability);
            Assert.Equal(1000, cargoShip.CurrentSurvivability);
            Assert.Equal(30000, cargoShip.Mass);
            Assert.Equal(20000, cargoShip.MaxWeight);
            Assert.Equal(0, cargoShip.CurrentWeight);
            Assert.True(cargoShip.IsAlive);

            // Тест не штатных значений конструктора
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    CargoShip cargo = new CargoShip("Avrora", -23, 40, 1000, 30000, 20000);
                }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    CargoShip cargo = new CargoShip("Avrora", 1000, -1, 1000, 30000, 20000);
                }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    CargoShip cargo = new CargoShip("Avrora", 1000, 40, -1, 30000, 20000);
                }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    CargoShip cargo = new CargoShip("Avrora", 1000, 40, 1000, -1, 20000);
                }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    CargoShip cargo = new CargoShip("Avrora", 1000, 40, 1000, 30000, -1);
                }
            );
        }

        [Fact]
        public void MethodsCargoTest()
        {
            CargoShip cargoShip = new CargoShip("Avrora", 1000, 30, 1000, 30000, 20000);
            cargoShip.ShipName = "Wind";
            Assert.Equal("Wind", cargoShip.ShipName);
            cargoShip.MaxSpeed = 40;
            Assert.Equal(40, cargoShip.MaxSpeed);
            Assert.Throws<ArgumentOutOfRangeException>(() => cargoShip.MaxSpeed = -1);

            cargoShip.CurrentWeight = 21000;
            Assert.Equal(20000f, cargoShip.CurrentWeight);
            Assert.Equal(20f, cargoShip.MaxSpeed);
            cargoShip.CurrentWeight = -1;
            Assert.Equal(0, cargoShip.CurrentSpeed);
            Assert.Equal(40f, cargoShip.MaxSpeed);
            cargoShip.CurrentWeight = 16000;
            Assert.Equal(16000f, cargoShip.CurrentWeight);
            Assert.Equal(24f, cargoShip.MaxSpeed);

            cargoShip.CurrentSpeed = 52;
            Assert.Equal(24f, cargoShip.CurrentSpeed);
            cargoShip.CurrentSpeed = -1;
            Assert.Equal(0, cargoShip.CurrentSpeed);
            cargoShip.CurrentSpeed = 20;
            Assert.Equal(20f, cargoShip.CurrentSpeed);
        }

        [Fact]
        public void ConstructorMillitaryTest()
        {
            // Тест штатных значений конструктора
            MillitaryShip millitary = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);

            /*Assert.Equal("Battleship", millitary.ShipName);
            Assert.Equal(2000, millitary.Price);
            Assert.Equal(60, millitary.MaxSpeed);
            Assert.Equal(0, millitary.CurrentSpeed);
            Assert.Equal(2500, millitary.MaxSurvivability);
            Assert.Equal(2500, millitary.CurrentSurvivability);
            Assert.Equal(15000, millitary.Mass);*/

            // Тест не штатных значений конструктора
            /*Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                MillitaryShip millitaryShip = new MillitaryShip("Avrora", -23, 60, 2500, 15000);
            }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                MillitaryShip millitaryShip = new MillitaryShip("Avrora", 2000, -1, 2500, 15000);
            }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                MillitaryShip millitaryShip = new MillitaryShip("Avrora", 2000, 60, -1, 15000);
            }
            );
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                MillitaryShip millitaryShip = new MillitaryShip("Avrora", 2000, 60, 2500, -1);
            }
            );*/
        }

        [Fact]
        public void MethodsMillitaryTest()
        {
            MillitaryShip millitary = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Right);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Medium), Side.Left);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Bow);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Sterm);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Bow);

            int price = millitary.countPriceWeapon();
            Assert.Equal(10000, price);
            price = millitary.countPriceWeapon(Side.Bow);
            Assert.Equal(6000, price);

            millitary.CurrentSpeed = -1;
            Assert.Equal(0, millitary.CurrentSpeed);
            millitary.CurrentSpeed = 65;
            Assert.Equal(60, millitary.CurrentSpeed);
            millitary.CurrentSpeed = 33;
            Assert.Equal(33, millitary.CurrentSpeed);
        }

        [Fact]
        public void ConstructorMillitaryCargoTest()
        {
            // Тест штатных значений конструктора
            MillitaryCargoShip millitaryCargo = new MillitaryCargoShip("BattleshipCargo", 2000, 50, 2500, 15000, 10000);

            Assert.Equal(0, millitaryCargo.CurrentSpeed);
            Assert.Equal(0, millitaryCargo.CurrentWeight);

            // Тест не штатных значений конструктора
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                MillitaryCargoShip millitaryCargo = new MillitaryCargoShip("BattleshipCargo", 1000, 40, 1000, 30000, -1);
            }
            );
        }

        [Fact]
        public void MethodsMillitaryCargoTest()
        {
            MillitaryCargoShip millitaryCargoShip = new MillitaryCargoShip("Avrora", 1000, 30, 1000, 30000, 20000);
            millitaryCargoShip.MaxSpeed = 40;
            Assert.Equal(40, millitaryCargoShip.MaxSpeed);
            Assert.Throws<ArgumentOutOfRangeException>(() => millitaryCargoShip.MaxSpeed = 0);

            millitaryCargoShip.CurrentWeight = 21000;
            Assert.Equal(20000, millitaryCargoShip.CurrentWeight);
            Assert.Equal(20f, millitaryCargoShip.MaxSpeed);
            millitaryCargoShip.CurrentWeight = -1;
            Assert.Equal(0, millitaryCargoShip.CurrentWeight);
            Assert.Equal(40f, millitaryCargoShip.MaxSpeed);
            millitaryCargoShip.CurrentWeight = 16000;
            Assert.Equal(16000f, millitaryCargoShip.CurrentWeight);
            Assert.Equal(24f, millitaryCargoShip.MaxSpeed);

            millitaryCargoShip.CurrentSpeed = 52;
            Assert.Equal(24f, millitaryCargoShip.CurrentSpeed);
            millitaryCargoShip.CurrentSpeed = -1;
            Assert.Equal(0, millitaryCargoShip.CurrentSpeed);

            millitaryCargoShip.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Right);
            millitaryCargoShip.addWeapon(Weapon.setDefaultWeapon(WeaponType.Medium), Side.Left);
            millitaryCargoShip.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Bow);
            millitaryCargoShip.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Sterm);
            millitaryCargoShip.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Bow);

            int price = millitaryCargoShip.countPriceWeapon();
            Assert.Equal(10000, price);
            price = millitaryCargoShip.countPriceWeapon(Side.Bow);
            Assert.Equal(6000, price);

            millitaryCargoShip.reduceCurrentSurviability(300);
            Assert.Equal(700, millitaryCargoShip.CurrentSurvivability);
            millitaryCargoShip.reduceCurrentSurviability(1000);
            Assert.Equal(0, millitaryCargoShip.CurrentSurvivability);
            Assert.False(millitaryCargoShip.IsAlive);
        }

        [Fact]
        public void CaptainTest()
        {
            MillitaryShip millitary = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);
            millitary.Captain.Name = "Dmitry";
            millitary.Captain.Surname = "Podstavkin";
            millitary.Captain.FatherName = "Sergeevich";

            Assert.Equal("Dmitry", millitary.Captain.Name);
            Assert.Equal("Podstavkin", millitary.Captain.Surname);
            Assert.Equal("Sergeevich", millitary.Captain.FatherName);

            Captain captain = new Captain("Ivan", "Ivanov", "Ivanovich");
            millitary.Captain = captain;

            Assert.Equal("Ivan", millitary.Captain.Name);
            Assert.Equal("Ivanov", millitary.Captain.Surname);
            Assert.Equal("Ivanovich", millitary.Captain.FatherName);

            string[] ranks = millitary.Captain.Ranks;

            Assert.Contains(millitary.Captain.Rank, ranks);

            captain.Rank = captain.Ranks[3];
            Assert.Equal("Midshipman", captain.Rank);
        }

        [Fact]
        public void TableTest()
        {
            CargoShip cargo1 = new CargoShip("Victory", 1000, 40, 1000, 30000, 20000);
            MillitaryShip millitary1 = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);
            MillitaryCargoShip millitaryCargoShip1 = new MillitaryCargoShip("Avrora", 5000, 40, 1500, 19000, 10000);
            CargoShip cargo2 = new CargoShip("Cargo", 2500, 35, 1500, 27000, 15000);
            MillitaryShip millitary2 = new MillitaryShip("Mill", 1500, 40, 4000, 18000);
            MillitaryCargoShip millitaryCargoShip2 = new MillitaryCargoShip("BMW", 6000, 30, 2000, 20000, 12000);

            Table<Ship> table = new Table<Ship>();
            table.pushFront(cargo2);
            table.pushFront(millitary2);
            table.pushFront(millitaryCargoShip2);
            table.pushBack(cargo1);
            table.pushBack(millitary1);
            table.pushBack(millitaryCargoShip1);
            
            Assert.Equal(6, table.Count);
            Assert.Equal("BMW", table[0].ShipName);
            Assert.Equal("Avrora", table[table.Count - 1].ShipName);

            table.popFront();
            table.popFront();
            table.popBack();
            table.popBack();

            Assert.Equal(2, table.Count);
            Assert.Equal("Cargo", table[0].ShipName);
            Assert.Equal("Victory", table[table.Count - 1].ShipName);

            table.popFront();
            table.popBack();
            table.popFront();
            table.popBack();

            Assert.Equal(0, table.Count);
            Assert.Null(table[0]);

            table.pushBack(cargo1);
            table.pushBack(cargo2);

            Assert.Equal("Cargo", table[table.Count - 1].ShipName);

            table.popBack();
            table.popBack();

            table.insert(cargo1, 0);
            table.insert(millitary1, 0);
            table.insert(millitaryCargoShip1, 2);
            table.insert(cargo2, 1);
            table[3] = millitary2;
            table[3] = millitaryCargoShip2;

            Assert.Equal("Battleship", table[0].ShipName);
            Assert.Equal("Cargo", table[1].ShipName);
            Assert.Equal("Victory", table[2].ShipName);
            Assert.Equal("BMW", table[3].ShipName);
            Assert.Throws<IndexOutOfRangeException>(() => table[-1] = millitary2);
            Assert.Throws<IndexOutOfRangeException>(() => table[5] = millitary2);
            Assert.Throws<IndexOutOfRangeException>(() => table.insert(millitary2, -1));
            Assert.Throws<IndexOutOfRangeException>(() => table.insert(millitary2, 5));

            Ship? ship = table.find("Cargo");
            Assert.Equal("Cargo", ship.ShipName);
            ship = table.find("Cargo1234");
            Assert.Null(ship);
        }

        [Fact]
        public void IteratorTest()
        {
            CargoShip cargo1 = new CargoShip("Victory", 1000, 40, 1000, 30000, 20000);
            MillitaryShip millitary1 = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);
            MillitaryCargoShip millitaryCargoShip1 = new MillitaryCargoShip("Avrora", 5000, 40, 1500, 19000, 10000);
            CargoShip cargo2 = new CargoShip("Cargo", 2500, 35, 1500, 27000, 15000);
            MillitaryShip millitary2 = new MillitaryShip("Mill", 1500, 40, 4000, 18000);
            MillitaryCargoShip millitaryCargoShip2 = new MillitaryCargoShip("BMW", 6000, 30, 2000, 20000, 12000);

            Table<Ship> table = new Table<Ship>();
            table.pushBack(cargo2);
            table.pushBack(millitary2);
            table.pushBack(millitaryCargoShip2);
            table.pushBack(cargo1);
            table.pushBack(millitary1);
            table.pushBack(millitaryCargoShip1);

            Iterator<Ship> it = new Iterator<Ship>(table);
            Assert.Equal("Cargo", it.first().ShipName);
            Assert.Equal(it.first().ShipName, it.get().ShipName);
            Assert.Equal("Avrora", it.last().ShipName);

            int i = 0;
            for(it = it.begin(); !it.isEnd(); it++)
            {
                if (i == 3)
                    Assert.Equal("Victory", it.get().ShipName);
                i++;
            }
            Assert.Null(it.get());
        }

        [Fact]
        public void WeaponTest()
        {
            Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 11f, 8000f, 25, 25, 2000);
            Weapon weaponMedium = new Weapon(WeaponType.Medium, 7f, 5000f, 30, 29, 1500);
            Weapon weaponLight = new Weapon(WeaponType.Light, 1f, 3000f, 40, 25, 1000);

            Assert.Equal(300f, weaponHeavy.getDamage());
            Assert.Equal(200f, weaponMedium.getDamage());
            Assert.Equal(100f, weaponLight.getDamage());

            weaponHeavy.CurrentAmmunition = 30;
            weaponMedium.CurrentAmmunition = 31;
            weaponLight.CurrentAmmunition = 35;

            Assert.Equal(25, weaponHeavy.CurrentAmmunition);
            Assert.Equal(30, weaponMedium.CurrentAmmunition);
            Assert.Equal(35, weaponLight.CurrentAmmunition);

            weaponHeavy.CurrentAmmunition = 20;
            weaponMedium.CurrentAmmunition = 0;
            weaponLight.CurrentAmmunition = 35;

            Assert.Equal(20, weaponHeavy.CurrentAmmunition);
            Assert.Equal(0, weaponMedium.CurrentAmmunition);
            Assert.Equal(35, weaponLight.CurrentAmmunition);

            weaponHeavy.CurrentAmmunition = 25;

            Assert.Equal(25, weaponHeavy.CurrentAmmunition);

            weaponLight.fire();

            Assert.Equal(34, weaponLight.CurrentAmmunition);
            Assert.False(weaponLight.ReadyToShoot);
            Thread.Sleep(1100);
            Assert.True(weaponLight.ReadyToShoot);

            Assert.Equal(WeaponType.Light, weaponLight.Type);
            Assert.Equal(AmmoType.Light, weaponLight.TypeOfAmmo);
            Assert.Equal(60f / weaponLight.ReloadTime, weaponLight.RateOfFire);
            Assert.Equal(3000f, weaponLight.FiringRange);
            Assert.Equal(40, weaponLight.MaxAmmunition);
        }

        [Fact]
        public void WeaponExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 0f, 8000f, 25, 25, 2000); } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 1f, 0f, 25, 25, 2000); } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 1f, 8000f, 0, 25, 2000); } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 1f, 8000f, 25, 30, 2000); } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { Weapon weaponHeavy = new Weapon(WeaponType.Heavy, 1f, 8000f, 25, -1, -1); } );

            Weapon weaponLight = new Weapon(WeaponType.Light, 1f, 3000f, 40, 25, 1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => weaponLight.CurrentAmmunition = -1);
        }
    }
}