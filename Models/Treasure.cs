using System;
namespace JDR.Models
{
    public class Treasure(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        private static Random random = new Random();

        public static void FoundChest(Hero hero)
        {
            Console.WriteLine($"Yay ! {hero.Name} has found a chest !");
            RandomItem(hero);
        }
       public static void RandomItem(Hero hero)
        {
            int roll = random.Next(1,3); // 50% chance to have armor or weapon

            if (roll == 1) // 50% chance to have weapon
            {
                Weapon new_weapon = new Weapon("arme", hero);
                Console.WriteLine($"You have found a {new_weapon}.");
            }
            else if (roll == 2) // 50% chance to have armor
            {
                Armor new_armor = new Armor("armure", hero);
                Console.WriteLine($"You have found a {new_armor}.");
            }
            else
            {
                Console.WriteLine("Item not found.");
                return;
            }
        }
    }
}
