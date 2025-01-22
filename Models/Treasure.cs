using System;
namespace JDR.Models
{
    public class Treasure(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        private static Random random = new Random();

        public static void FoundChest(Hero hero, Inventory inventory)
        {
            Console.WriteLine($"Yay ! {hero.Name} has found a chest !");
            var newItem = RandomItem(hero);
            if (newItem != null)
            {
                if (newItem is Weapon)
                {
                    inventory.AddWeaponItem(newItem);
                }
                else if (newItem is Armor)
                {
                    inventory.AddArmorItem(newItem); 
                }
                hero.EquipItem(newItem);
            }
        }
       public static Item RandomItem(Hero hero)
        {
            int roll = random.Next(1,3); // 50% chance to have armor or weapon

            if (roll == 1) // 50% chance to have weapon
            {
                Weapon new_weapon = new Weapon(hero, "weapon", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                Console.WriteLine($"You have just found {new_weapon} !");
                return new_weapon;
            }
            else if (roll == 2) // 50% chance to have armor
            {
                Armor new_armor = new Armor(hero, "armor", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                Console.WriteLine($"You have just found {new_armor} !");
                return new_armor;
            }
            return null;
        }
    }
}
