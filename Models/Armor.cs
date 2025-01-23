namespace JDR.Models
{

    public enum MaterialArmor {cloth, leather, wood, metal, gold}

    public class Armor : Item
    {
        public MaterialArmor MaterialType {get; set; }
        public MaterialArmor MaterialRandom {get; set; }
        
        private static readonly Random Random = new();

        public Armor (Hero hero,
                    string name,
                    int staminaBonus,
                    int strengthBonus,
                    int intellectBonus,
                    int agilityBonus,
                    int spiritBonus,
                    int armorBonus,
                    int damageBonus,
                    int criticalChanceBonus,
                    int hasteBonus,
                    int dodgeBonus)
                    : base(name)
        {
            Name = name;
            StaminaBonus = staminaBonus;
            StrengthBonus = strengthBonus;
            IntellectBonus = intellectBonus;
            AgilityBonus = agilityBonus;
            SpiritBonus = spiritBonus;
            base.ArmorBonus = armorBonus;
            DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            SetAttributes(MaterialType);
        }

        // Random material type selection
        public static MaterialArmor MaterialChance(int level)
        {
            int roll = Random.Next(1, 100);

            switch(level)
            {
                case 1: // Level 1
                    if (roll <= 70) return MaterialArmor.cloth;    // 70% cloth
                    if (roll <= 87) return MaterialArmor.leather;     // 17% leather
                    if (roll <= 95) return MaterialArmor.wood;     // 8% wood
                    if (roll <= 99) return MaterialArmor.metal;    // 4% metal
                    return MaterialArmor.gold;                      // 1% gold

                case 2: // Level 2
                    if (roll <= 50) return MaterialArmor.cloth;    // 50% tissu
                    if (roll <= 75) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 90) return MaterialArmor.wood;     // 15% wood
                    if (roll <= 98) return MaterialArmor.metal;    // 8% metal
                    return MaterialArmor.gold;                      // 2% gold

                case 3: // Level 3
                    if (roll <= 40) return MaterialArmor.cloth;    // 40% cloth
                    if (roll <= 65) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 85) return MaterialArmor.wood;     // 20% wood
                    if (roll <= 95) return MaterialArmor.metal;    // 10% metal
                    return MaterialArmor.gold;                      // 5% gold

                case 4: // Level 4
                    if (roll <= 30) return MaterialArmor.cloth;    // 30% cloth
                    if (roll <= 55) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 75) return MaterialArmor.wood;     // 20% wood
                    if (roll <= 90) return MaterialArmor.metal;    // 15% metal
                    return MaterialArmor.gold;                      // 10% gold

                case 5: // Level 5
                    if (roll <= 20) return MaterialArmor.cloth;    // 20% cloth
                    if (roll <= 45) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 65) return MaterialArmor.wood;     // 20% wood
                    if (roll <= 85) return MaterialArmor.metal;    // 20% metal
                    return MaterialArmor.gold;                      // 15% gold

                case 6: // Level 6
                    if (roll <= 10) return MaterialArmor.cloth;    // 10% cloth
                    if (roll <= 30) return MaterialArmor.leather;     // 20% leather
                    if (roll <= 55) return MaterialArmor.wood;     // 25% wood
                    if (roll <= 80) return MaterialArmor.metal;    // 25% metal
                    return MaterialArmor.gold;                      // 20% gold

                case >= 7: // Level 7+
                    if (roll <= 5) return MaterialArmor.cloth;     // 5% cloth
                    if (roll <= 20) return MaterialArmor.leather;     // 15% leather
                    if (roll <= 45) return MaterialArmor.wood;     // 25% wood
                    if (roll <= 75) return MaterialArmor.metal;    // 30% metal
                    return MaterialArmor.gold;                      // 25% gold

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Error: Invalid level.");
            }
        }
        private void SetAttributes(MaterialArmor MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialArmor.cloth:
                    ArmorBonus = Random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialArmor.leather:
                    ArmorBonus = Random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialArmor.wood:
                    ArmorBonus = Random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialArmor.metal:
                    ArmorBonus = Random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialArmor.gold:
                    ArmorBonus = Random.Next(27, 32);
                    Weight = 10;
                    break;
                
                default:
                    ArmorBonus = 1;
                    Weight = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Name}, made out of {MaterialType} ! \n" +
            $"Defense : {ArmorBonus} | Weight : {Weight}";
        }
    }
}
