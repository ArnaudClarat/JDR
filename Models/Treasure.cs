namespace JDR
{
    public abstract class Treasure 
    {
        private static Random random = new Random();

        public WeaponsType GetMaterialTypes()
        {
            var weaponsType = Enum.GetValues(typeof(WeaponsType));

            int randomIndex = random.Next(weaponsType.Length);

            return (WeaponsType)weaponsType.GetValue(randomIndex);
        }
        public MaterialWeapons MaterialChance(int level)
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

                case >= 7 : 
                    if (roll <=50) return MaterialWeapons.Wood;
                    if (roll <=80) return MaterialWeapons.Stone;
                    if (roll <=90) return MaterialWeapons.Bone;
                    if (roll <=95) return MaterialWeapons.Metal;
                    return MaterialWeapons.Gold;

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Niveau invalide !");
            }
        }

        public Treasure GetRandomTreasure(int level)
        {
            MaterialWeapons material = MaterialChance(level);
            WeaponsType weaponsType = GetMaterialTypes();
            return new Weapons(material, weaponsType);
        }
    }
}