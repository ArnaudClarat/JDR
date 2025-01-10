namespace JDR.Models
{

    public enum MaterialArmor {Cloth, Leather, Wood, Metal, Gold}

    public class Armor
    {
        public string Name {get; set; }
        public MaterialArmor MaterialType {get; set; }
        public int BaseDefense {get; private set; }
        public int Weight {get; private set; }
        
        private static Random random = new Random();

        public Armor (string name, MaterialArmor materialType)
        {
            Name = name;
            MaterialType = materialType;
            SetAttributes(materialType);
        }

        private void SetAttributes(MaterialArmor MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialArmor.Cloth:
                    BaseDefense = random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialArmor.Leather:
                    BaseDefense = random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialArmor.Wood:
                    BaseDefense = random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialArmor.Metal:
                    BaseDefense = random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialArmor.Gold:
                    BaseDefense = random.Next(27, 32);
                    Weight = 10;
                    break;
                
                default:
                    BaseDefense = 1;
                    Weight = 0;
                    break;
            }
        }
    }
}