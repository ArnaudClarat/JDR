namespace JDR.Models
{
    public class Hero : Character
    {
        public Direction FacingDirection { get; private set; } = Direction.Right;
        private readonly LevelProgression levelProgression;
        private static readonly LevelProgression progression = new();
        public int ExperienceToNextLevel => levelProgression.ExperienceToLevelUp(Level);
        public event Action? OnLevelUp;
        public int ExperienceValue { get; protected set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Spirit { get; set; }
        public int BonusDamage { get; set; }
        public int HasteRating { get; set; }
        public int DodgeRating { get; set; }

        public Hero(
            string characterName,
            LevelProgression progression
        ) : base(0, 0, characterName)
        {
            levelProgression = progression;
        }
        
        // Makes the Hero move on the map
        public void Move(string direction, int rowCount, int colCount)
        {
            switch (direction)
            {
                case "Up":
                    if (Y > 0) Y--;
                    break;
                case "Down":
                    if (Y < rowCount - 1) Y++;
                    break;
                case "Left":
                    if (X > 0) X--;
                    FacingDirection = Direction.Left;
                    break;
                case "Right":
                    if (X < colCount - 1) X++;
                    FacingDirection = Direction.Right;
                    break;
            }
        }

        public virtual void LowTierAttack(Character target, Action action) { }

        public virtual void MidTierAttack(Character target, Action action) { }

        public virtual void UltimateAttack(Character target, Action action) { }

        // Calculates the experience gained
        public void CalculateExperience(Character target)
        {
            int levelDifference = target.Level - Level;
            double experienceMath = Math.Max(50 * Math.Pow(1.2, levelDifference), 5); // Minimum experience of 5 guaranteed
            int experienceGained = (int)Math.Round(experienceMath);
            GainExperience(experienceGained, target);
        }

        // Adds the amount of experience gained and checks if it increases the level of the hero
        public void GainExperience(int amount, Character target)
        {
            ExperienceValue += amount;
            Console.WriteLine($"{Name} received {amount} experience points from killing {target.Name}.");

            while (levelProgression.CanLevelUp(Level, ExperienceValue))
            {
                LevelUp();
            }
        }
    
        // Adds a level to the character
        protected virtual void LevelUp()
        {
            ExperienceValue -= ExperienceToNextLevel;
            Level++;
            Console.WriteLine($"Yay ! {Name} reached level {Level} !");
            OnLevelUp?.Invoke();
        }
    
        // Equip item and change stats
        public void EquipItem(Item item)
        {
            Stamina += item.StaminaBonus;
            Strength += item.StrengthBonus;
            Intellect += item.IntellectBonus;
            Agility += item.AgilityBonus;
            Spirit += item.SpiritBonus;
            ArmorValue += item.ArmorBonus;
            BonusDamage += item.DamageBonus;
            CriticalChance += item.CriticalChanceBonus;
            HasteRating += item.HasteBonus;
            DodgeRating += item.DodgeBonus;

            Console.WriteLine($"{Name} equipped {item.Name}.");
        }

        public static Hero CreateHero(string heroType, string name)
        {
            return heroType.ToLower() switch
            {
                "mage" => new Mage(name, progression),
                // "warrior" => new Warrior(name, progression),
                // "archer" => new Archer(name, progression),
                _ => throw new ArgumentException("Invalid hero type !")
            };
        }
    }
    
    public enum Direction { Left, Right}
}
