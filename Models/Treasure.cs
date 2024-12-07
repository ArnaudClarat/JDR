namespace JDR
{
    public abstract class Treasure 
    {
        private static Random random = new Random();

        //void MaterialChance(double lvl);

        public MaterialWeapons MaterialChance(int level) // Wood, Stone, Bone, Metal, Gold
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1 :
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                case 3 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                case 4 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                case 5 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                case 6 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                case 7 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Niveau invalide !");
            }
        }

        public Treasure GetRandomTreasure()
        {
        }
    }
}