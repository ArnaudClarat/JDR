namespace JDR.Models
{
    
    public enum WeaponType {épée, hache, masse}
    public enum MaterialWeapon {bois, pierre, os, métal, or}

    public class Weapon
    {
        public string Name {get; set; }
        public MaterialWeapon MaterialType {get; set; }
        public WeaponType WeaponType {get; set; }
        public MaterialWeapon MaterialRandom {get; set; }
        public int Damage {get; private set; }
        public double Speed {get; private set; }
        public double Weight {get; private set; }
        
        private static Random random = new Random();

        public Weapon (string name, Hero hero)
        {
            Name = name;
            WeaponType = SetWeaponType();
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            SetAttributes(MaterialType);
        }

        // Selection aléatoire du type d'arme
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
                throw new ArgumentOutOfRangeException(nameof(weaponType), "Type d'arme inconnu !");
            }
            return weaponType;
        }

        // Selection aléatoire du type de matériel
        public MaterialWeapon MaterialChance(int level)
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1 :
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case 2 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case 3 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case 4 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case 5 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case 6 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                case >= 7 : 
                    if (roll <=50) return MaterialWeapon.bois;
                    if (roll <=80) return MaterialWeapon.pierre;
                    if (roll <=90) return MaterialWeapon.os;
                    if (roll <=95) return MaterialWeapon.métal;
                    return MaterialWeapon.or;

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Niveau invalide !");
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
            return $"{Name} de type {WeaponType}, fabriquée en {MaterialType} ! \n" +
            $"Dégâts : {Damage}, Vitesse : {Speed}, Poids : {Weight}";
        }

        // public WeaponType GetMaterialTypes()
        // {
        //     var weaponsType = Enum.GetValues(typeof(WeaponType));

        //     int randomIndex = random.Next(weaponsType.Length);

        //     return (WeaponType)weaponsType.GetValue(randomIndex);
        // }
    }
}