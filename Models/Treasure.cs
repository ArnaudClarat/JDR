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
            Console.WriteLine($"Bravo {hero.Name}, tu as trouvé un coffre");
            RandomItem(hero);
        }
       public static void RandomItem(Hero hero)
        {
            int roll = random.Next(1,3); // 50% chance to have armor or weapon

            if (roll == 1) // 50% chance to have weapon
            {
                Weapon new_weapon = new Weapon("arme", hero);
                Console.WriteLine("Vous avez trouvé une " + new_weapon);
            }
            else if (roll == 2) // 50% chance to have armor
            {
                Armor new_armor = new Armor("armure", hero);
                Console.WriteLine("Vous avez trouvé une " + new_armor);
            }
            else
            {
                Console.WriteLine("Petit bug dans le programme, dsl loulou ta pas d'item 🖕");
                return;
            }
        }
    }
}