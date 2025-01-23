using System;
namespace JDR.Models
{
    public class Treasure(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        private readonly static Random random = new();

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
                Weapon Weapon = new(hero, "weapon", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                Console.WriteLine($"You have just found {Weapon} !");
                return Weapon;
            }
            else if (roll == 2) // 50% chance to have armor
            {
                Armor Armor = new(hero, "armor", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                Console.WriteLine($"You have just found {Armor} !");
                return Armor;
            }
            else
            {
                throw new Exception("Erreur mathématique");
            }
        }
    }
}
