namespace JDR.Models
{

    public enum MaterialArmor {tissu, cuir, bois, métal, or}

    public class Armor
    {
        public string Name {get; set; }
        public MaterialArmor MaterialType {get; set; }
        public int BaseDefense {get; private set; }
        public int Weight {get; private set; }
        public MaterialArmor MaterialRandom {get; set; }
        
        private static Random random = new Random();

        public Armor (string name, Hero hero)
        {
            Name = name;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            SetAttributes(MaterialType);

        }

        // Selection aléatoire du type de matériel
        public MaterialArmor MaterialChance(int level)
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1 :
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case 2 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case 3 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case 4 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case 5 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case 6 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                case >= 7 : 
                    if (roll <=50) return MaterialArmor.tissu;
                    if (roll <=80) return MaterialArmor.cuir;
                    if (roll <=90) return MaterialArmor.bois;
                    if (roll <=95) return MaterialArmor.métal;
                    return MaterialArmor.or;

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Niveau invalide !");
            }
        }
        private void SetAttributes(MaterialArmor MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialArmor.tissu:
                    BaseDefense = random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialArmor.cuir:
                    BaseDefense = random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialArmor.bois:
                    BaseDefense = random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialArmor.métal:
                    BaseDefense = random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialArmor.or:
                    BaseDefense = random.Next(27, 32);
                    Weight = 10;
                    break;
                
                default:
                    BaseDefense = 1;
                    Weight = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Name}, fabriquée en {MaterialType} ! \n" +
            $"Défense : {BaseDefense} | Poids : {Weight}";
        }
    }
}