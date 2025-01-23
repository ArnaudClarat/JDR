namespace JDR.Models
{

    public enum WeaponType { Sword, Axe, Mace }
    public enum MaterialWeapon { Wood, Stone, Bone, Metal, Gold }

    public class Weapon : Item
    {
        public MaterialWeapon MaterialType { get; set; }
        public WeaponType WeaponType { get; set; }
        public MaterialWeapon MaterialRandom { get; set; }
        public double Haste { get; set; }
        
        
        private static readonly Random Random = new();

        public Weapon(Hero hero,
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
            ArmorBonus = armorBonus;
            base.DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            WeaponType = SetWeaponType();
        }

        // Random weapon type selection
        private WeaponType SetWeaponType()
        {
            int roll = Random.Next(1, 4);
            WeaponType weaponType;

            switch (roll)
            {
                case 1:
                    weaponType = WeaponType.Sword;
                    SetAttributes(MaterialType);
                    Haste *= 0.6;
                    Weight *= 0.1;
                    break;

                case 2:
                    weaponType = WeaponType.Axe;
                    SetAttributes(MaterialType);
                    Haste *= 0.4;
                    Weight *= 0.3;
                    break;

                case 3:
                    weaponType = WeaponType.Mace;
                    SetAttributes(MaterialType);
                    Haste *= 0.5;
                    Weight *= 0.2;
                    break;

                default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), "Error: Invalid weapon type.");
            }
            return weaponType;
        }

        // Random material type selection
        public static MaterialWeapon MaterialChance(int level)
        {
            int roll = Random.Next(1, 100);

            return level switch
            {
                1 => roll <= 70 ? MaterialWeapon.Wood :
                     roll <= 87 ? MaterialWeapon.Stone :
                     roll <= 95 ? MaterialWeapon.Bone :
                     roll <= 99 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                2 => roll <= 50 ? MaterialWeapon.Wood :
                     roll <= 75 ? MaterialWeapon.Stone :
                     roll <= 90 ? MaterialWeapon.Bone :
                     roll <= 98 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                3 => roll <= 40 ? MaterialWeapon.Wood :
                     roll <= 65 ? MaterialWeapon.Stone :
                     roll <= 85 ? MaterialWeapon.Bone :
                     roll <= 95 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                4 => roll <= 30 ? MaterialWeapon.Wood :
                     roll <= 55 ? MaterialWeapon.Stone :
                     roll <= 75 ? MaterialWeapon.Bone :
                     roll <= 90 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                5 => roll <= 20 ? MaterialWeapon.Wood :
                     roll <= 45 ? MaterialWeapon.Stone :
                     roll <= 65 ? MaterialWeapon.Bone :
                     roll <= 85 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                6 => roll <= 10 ? MaterialWeapon.Wood :
                     roll <= 30 ? MaterialWeapon.Stone :
                     roll <= 55 ? MaterialWeapon.Bone :
                     roll <= 80 ? MaterialWeapon.Metal :
                                  MaterialWeapon.Gold,

                >= 7 => roll <= 5 ? MaterialWeapon.Wood :
                         roll <= 20 ? MaterialWeapon.Stone :
                         roll <= 45 ? MaterialWeapon.Bone :
                         roll <= 75 ? MaterialWeapon.Metal :
                                      MaterialWeapon.Gold,

                _ => throw new ArgumentOutOfRangeException(nameof(level), "Invalid level")
            };
        }
        
        // Implementation of weapons' stats from material type
        private void SetAttributes(MaterialWeapon materialType)
        {
            (int damage, double haste, double weight) = materialType switch
            {
                MaterialWeapon.Wood => (Random.Next(4, 10), 20, 2),
                MaterialWeapon.Stone => (Random.Next(10, 16), 15, 4),
                MaterialWeapon.Bone => (Random.Next(16, 21), 17, 6),
                MaterialWeapon.Metal => (Random.Next(21, 27), 13, 8),
                MaterialWeapon.Gold => (Random.Next(27, 32), 11, 10),
                _ => (1, 20, 0)
            };

            base.DamageBonus = damage;
            this.Haste = haste;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name}, a {WeaponType} made out of {MaterialType} ! \n" +
            $"Damage : {base.DamageBonus} | Speed : {Haste} | Weight : {Weight}";
        }
    }
}
