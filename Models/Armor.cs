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
                case 1: // Niveau 1
                    if (roll <= 70) return MaterialArmor.tissu;    // 70% tissu
                    if (roll <= 87) return MaterialArmor.cuir;     // 17% cuir
                    if (roll <= 95) return MaterialArmor.bois;     // 8% bois
                    if (roll <= 99) return MaterialArmor.métal;    // 4% métal
                    return MaterialArmor.or;                      // 1% or

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialArmor.tissu;    // 50% tissu
                    if (roll <= 75) return MaterialArmor.cuir;     // 25% cuir
                    if (roll <= 90) return MaterialArmor.bois;     // 15% bois
                    if (roll <= 98) return MaterialArmor.métal;    // 8% métal
                    return MaterialArmor.or;                      // 2% or

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialArmor.tissu;    // 40% tissu
                    if (roll <= 65) return MaterialArmor.cuir;     // 25% cuir
                    if (roll <= 85) return MaterialArmor.bois;     // 20% bois
                    if (roll <= 95) return MaterialArmor.métal;    // 10% métal
                    return MaterialArmor.or;                      // 5% or

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialArmor.tissu;    // 30% tissu
                    if (roll <= 55) return MaterialArmor.cuir;     // 25% cuir
                    if (roll <= 75) return MaterialArmor.bois;     // 20% bois
                    if (roll <= 90) return MaterialArmor.métal;    // 15% métal
                    return MaterialArmor.or;                      // 10% or

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialArmor.tissu;    // 20% tissu
                    if (roll <= 45) return MaterialArmor.cuir;     // 25% cuir
                    if (roll <= 65) return MaterialArmor.bois;     // 20% bois
                    if (roll <= 85) return MaterialArmor.métal;    // 20% métal
                    return MaterialArmor.or;                      // 15% or

                case 6: // Niveau 6
                    if (roll <= 10) return MaterialArmor.tissu;    // 10% tissu
                    if (roll <= 30) return MaterialArmor.cuir;     // 20% cuir
                    if (roll <= 55) return MaterialArmor.bois;     // 25% bois
                    if (roll <= 80) return MaterialArmor.métal;    // 25% métal
                    return MaterialArmor.or;                      // 20% or

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialArmor.tissu;     // 5% tissu
                    if (roll <= 20) return MaterialArmor.cuir;     // 15% cuir
                    if (roll <= 45) return MaterialArmor.bois;     // 25% bois
                    if (roll <= 75) return MaterialArmor.métal;    // 30% métal
                    return MaterialArmor.or;                      // 25% or

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