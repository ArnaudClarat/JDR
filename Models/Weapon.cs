namespace JDR.Models
{
    
    public enum WeaponType {sword, axe, mace}
    public enum MaterialWeapon {wooden, stone, bone, metal, golden}

    public class Weapon
    {
        public string Name {get; set; }
        public MaterialWeapon MaterialType {get; set; }
        public WeaponType WeaponType {get; set; }
        public MaterialWeapon MaterialRandom {get; set; }
        public int Damage {get; private set; }
        private double speed;
        public double Speed
        {
            get { return speed; }
            set { speed = Math.Round(value, 2); }
        }
        
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = Math.Round(value, 2); }
        }
        
        
        private static Random random = new Random();

        public Weapon (string name, Hero hero)
        {
            Name = name;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            WeaponType = SetWeaponType();
        }

        // Random weapon type selection
        private WeaponType SetWeaponType()
        {
            int roll = random.Next(1, 4);
            WeaponType weaponType;

            switch (roll)
            {
                case 1:
                    weaponType = WeaponType.épée;
                    SetAttributes(MaterialType);
                    Speed *= 0.6;
                    Weight *= 0.1;
                    break;

                case 2:
                    weaponType = WeaponType.hache;
                    SetAttributes(MaterialType);
                    Speed *= 0.4;
                    Weight *= 0.3;
                    break;

                case 3:
                    weaponType = WeaponType.masse;
                    SetAttributes(MaterialType);
                    Speed *= 0.5;
                    Weight *= 0.2;
                    break;

                default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), "Unknown weapon type !");
            }
            return weaponType;
        }

        // Selection aléatoire du type de matériel
        public MaterialWeapon MaterialChance(int level)
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1: // Niveau 1
                    if (roll <= 70) return MaterialWeapon.bois;    // 70% wooden
                    if (roll <= 87) return MaterialWeapon.pierre;  // 17% stone
                    if (roll <= 95) return MaterialWeapon.os;      // 8% bone
                    if (roll <= 99) return MaterialWeapon.métal;   // 4% metal
                    return MaterialWeapon.or;                     // 1% golden

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialWeapon.bois;    // 50% wooden
                    if (roll <= 75) return MaterialWeapon.pierre;  // 25% stone
                    if (roll <= 90) return MaterialWeapon.os;      // 15% bone
                    if (roll <= 98) return MaterialWeapon.métal;   // 8% metal
                    return MaterialWeapon.or;                     // 2% golden

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialWeapon.bois;    // 40% wooden
                    if (roll <= 65) return MaterialWeapon.pierre;  // 25% stone
                    if (roll <= 85) return MaterialWeapon.os;      // 20% bone
                    if (roll <= 95) return MaterialWeapon.métal;   // 10% metal
                    return MaterialWeapon.or;                     // 5% golden

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialWeapon.bois;    // 30% wooden
                    if (roll <= 55) return MaterialWeapon.pierre;  // 25% stone
                    if (roll <= 75) return MaterialWeapon.os;      // 20% bone
                    if (roll <= 90) return MaterialWeapon.métal;   // 15% metal
                    return MaterialWeapon.or;                     // 10% golden

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialWeapon.bois;    // 20% wooden
                    if (roll <= 45) return MaterialWeapon.pierre;  // 25% stone
                    if (roll <= 65) return MaterialWeapon.os;      // 20% bone
                    if (roll <= 85) return MaterialWeapon.métal;   // 20% metal
                    return MaterialWeapon.or;                     // 15% golden

                case 6: // Niveau 6
                    if (roll <= 10) return MaterialWeapon.bois;    // 10% wooden
                    if (roll <= 30) return MaterialWeapon.pierre;  // 20% stone
                    if (roll <= 55) return MaterialWeapon.os;      // 25% bone
                    if (roll <= 80) return MaterialWeapon.métal;   // 25% metal
                    return MaterialWeapon.or;                     // 20% golden

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialWeapon.bois;     // 5% wooden
                    if (roll <= 20) return MaterialWeapon.pierre;  // 15% stone
                    if (roll <= 45) return MaterialWeapon.os;      // 25% bone
                    if (roll <= 75) return MaterialWeapon.métal;   // 30% metal
                    return MaterialWeapon.or;                     // 25% golden

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Invalid level !");
            }
        }
        
        // Implémentation des stats de l'arme en fonction du matériau
        private void SetAttributes(MaterialWeapon MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialWeapon.bois:
                    Damage = random.Next(4, 10);
                    Speed = 20;
                    Weight = 2;
                    break;
                
                case MaterialWeapon.pierre:
                    Damage = random.Next(10, 16);
                    Speed = 15;
                    Weight = 4;
                    break;

                case MaterialWeapon.os:
                    Damage = random.Next(16, 21);
                    Speed = 17;
                    Weight = 6;
                    break;
                
                case MaterialWeapon.métal:
                    Damage = random.Next(21, 27);
                    Speed = 13;
                    Weight = 8;
                    break;
                
                case MaterialWeapon.or:
                    Damage = random.Next(27, 32);
                    Speed = 11;
                    Weight = 10;
                    break;
                
                default:
                    Damage = 1;
                    Speed = 20;
                    Weight = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}, a {WeaponType} made out of {MaterialType} ! \n" +
            $"Damage : {Damage} | Speed : {Speed} | Weight : {Weight}";
        }

        // public WeaponType GetMaterialTypes()
        // {
        //     var weaponsType = Enum.GetValues(typeof(WeaponType));

        //     int randomIndex = random.Next(weaponsType.Length);

        //     return (WeaponType)weaponsType.GetValue(randomIndex);
        // }
    }
}
