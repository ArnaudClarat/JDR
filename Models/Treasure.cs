using System;
namespace JDR.Models
{
    public class Treasure(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        private static Random random = new Random();

        public static void FoundChest(int level, WeaponType weaponType, Hero hero, MaterialWeapon materialRandom, MaterialWeapon materialType)
        {
            Console.WriteLine($"Bravo {hero.Name}, tu as trouvé un coffre");
            RandomItem(level, weaponType, hero, materialRandom, materialType);
        }
       public static void RandomItem(int level, WeaponType weaponType, Hero hero, MaterialWeapon materialRandom, MaterialWeapon materialType)
        {
            int roll = random.Next(1,2); // 50% chance to have armor or weapon

            if (roll == 1) // 50% chance to have weapon
            {
                Weapon new_weapon = new Weapon("arme", hero);
                Console.WriteLine("Vous avez trouvé une " + new_weapon);
            }
            else if (roll == 2) // 50% chance to have armor
            {
                Console.WriteLine("Vous avez trouvé une armure qui n'est pas encore en place");
            }
            else
            {
                Console.WriteLine("Petit bug dans le programme, dsl loulou ta pas d'item 🖕");
                return;
            }
        }
        // public void GetRandomTreasure(int level)
        // {
        //     MaterialWeapon material = MaterialChance(level);
        //     WeaponType weaponsType = GetMaterialTypes();
        //     return new Weapon(material, weaponsType);
        // }
    }
}