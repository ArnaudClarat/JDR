namespace JDR
{
    
    public enum WeaponsType {Sword, Axe, Mace}
    public enum MaterialWeapons {Wood, Stone, Bone, Metal, Gold}

    public abstract class Weapons : Treasure
    {
        public string Name {get; set; }
        public MaterialWeapons MaterialType {get; set; }
        public WeaponsType WeaponType {get; set; }
        public int Damage {get; private set; }
        public double Speed {get; private set; }
        public double Weight {get; private set; }
        
        private static Random random = new Random();

        public Weapons (string name, MaterialWeapons materialType, WeaponsType weaponsType)
        {
            Name = name;
            WeaponType = weaponsType;
            SetWeaponsType(weaponsType);
            MaterialType = materialType;
            SetAttributes(materialType);
        }
        
        private void SetWeaponsType(WeaponsType weaponsType)
        {
            switch (weaponsType)
            {
                case WeaponsType.Sword:
                    SetAttributes(MaterialType);
                    Speed *= 0.6;
                    Weight *= 0.1;
                    break;

                case WeaponsType.Axe:
                    SetAttributes(MaterialType);
                    Speed *= 0.3;
                    Weight *= 0.3;
                    break;

                case WeaponsType.Mace:
                    SetAttributes(MaterialType);
                    Speed *= 0.4;
                    Weight *= 0.2;
                    break;

                default:
                throw new ArgumentOutOfRangeException(nameof(weaponsType), "Type d'arme inconnu !");
            }
        }
        private void SetAttributes(MaterialWeapons MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialWeapons.Wood:
                    Damage = random.Next(4, 10);
                    Speed = 20;
                    Weight = 2;
                    break;
                
                case MaterialWeapons.Stone:
                    Damage = random.Next(10, 16);
                    Speed = 15;
                    Weight = 4;
                    break;

                case MaterialWeapons.Bone:
                    Damage = random.Next(16, 21);
                    Speed = 17;
                    Weight = 6;
                    break;
                
                case MaterialWeapons.Metal:
                    Damage = random.Next(21, 27);
                    Speed = 13;
                    Weight = 8;
                    break;
                
                case MaterialWeapons.Gold:
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
    }
}