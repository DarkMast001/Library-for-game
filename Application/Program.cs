using MillitaryShipConvoy;
using UnityEngine.TextCore.Text;

namespace Application
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            MillitaryCargoShip millitaryCargoShip = new MillitaryCargoShip("Avrora", 1000, 40, 1000, 30000, 20000);
            millitaryCargoShip.CurrentWeight = 21000;
            Console.WriteLine(millitaryCargoShip.CurrentWeight);
            Console.WriteLine(millitaryCargoShip.MaxSpeed);
            // Console.WriteLine((1 - millitaryCargoShip.CurrentWeight * 0.000025f) * millitaryCargoShip.MaxSpeed);


            // CargoShip cargo = new CargoShip("Lol", 1000, 40, 1000, 30000, 20000);
            /*MillitaryShip millitary = new MillitaryShip("Battleship", 2000, 60, 2500, 15000);
            MillitaryCargoShip millitaryCargoShip = new MillitaryCargoShip("Avrora", 5000, 40, 1500, 19000, 10000);

            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Medium), Side.Right);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Left);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Light), Side.Bow);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Stern);
            millitary.addWeapon(Weapon.setDefaultWeapon(WeaponType.Heavy), Side.Right);
            Console.WriteLine(millitary.countPriceWeapon());
            
            Table<Ship> table = new Table<Ship>();
            table.pushBack(cargo);
            table.pushBack(millitary);
            table.pushBack(millitaryCargoShip);

            table.remove(cargo);

            Iterator<Ship> it = new Iterator<Ship>(table);
            for (it = it.begin(); it.isEnd(); it++)
            {
                if (it.get() is not null)
                    Console.WriteLine(it.get().ShipName);
            }

            Mission mission = new Mission(table);
            Console.WriteLine(mission.Balance);
            Console.WriteLine(mission.AbilityToStartMission);*/

            /*Ship? s = table.find("Lol");
            if (s != null)
                Console.WriteLine(s.ShipName);
            else
                Console.WriteLine("null");*/



            /*foreach(var ship in table)
            {

            }*/
            /*float angle = 0f;
            angle = angle - (int)(angle / 360) * 360;
            angle = (angle < 0) ? 360 + angle : angle;
            Console.WriteLine(angle);*/
        }
    }
}