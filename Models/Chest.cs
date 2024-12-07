namespace JDR
{

    public enum MaterialChest {Cloth, Leather, Wood, Metal, Gold}

    public abstract class Chest : Treasure
    {
        public string Name {get; set; }
        public MaterialChest MaterialType {get; set; }
        public int BaseDefense {get; private set; }
        public int Weight {get; private set; }
        
        private static Random random = new Random();

        public Chest (string name, MaterialChest materialType)
        {
            Name = name;
            MaterialType = materialType;
            SetAttributes(materialType);
        }

        private void SetAttributes(MaterialChest MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialChest.Cloth:
                    BaseDefense = random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialChest.Leather:
                    BaseDefense = random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialChest.Wood:
                    BaseDefense = random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialChest.Metal:
                    BaseDefense = random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialChest.Gold:
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