namespace JDR.Models
{
    public class Monster : Character
    {
        public int Id { get; set; }
        public Monster(
        int x,
        int y,
        int heroLevel,
        string characterName,
        int armorValue = 4,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
        ) : base(x, y, characterName)
        {
            ArmorValue = armorValue;
            CriticalChance = criticalChance;
            HasteValue = hasteRating;
            DodgeRating = dodgeRating;
            CalculateLevel(heroLevel);
        }
        public int Stamina { get; set; }
        public int Power { get; set; }

        // Initializes stats
        private void InitializeStats()
        {
            Id = Rand.Next(1, 1000);
            Stamina = StatsCalculator.CalculateStat(5, 1.2, Level);
            Power = StatsCalculator.CalculateStat(3, 1.25, Level);
            CurrentHealthValue = Stamina * 10;
            MaxHealthValue = CurrentHealthValue;
            AttackValue = (int)Math.Round(Power * 1.6);
        }
        // Calculates the monster level if the hero level is at least 2
        public void CalculateLevel(int heroLevel)
        {
            RollResult = Rand.Next(1, 101);
            if (RollResult <= 15)
            {
                Level = heroLevel == 1 ? heroLevel : heroLevel - 1;
            }
            else if (RollResult <= 65)
            {
                Level = heroLevel;
            }
            else if (RollResult <= 92)
            {
                Level = heroLevel + 1;
            }
            else
            {
                Level = heroLevel + 2;
            }
            InitializeStats();
        }
        // The base attack
        public override int BaseAttack(Character target, Action restartGameAction)
        {
            int calculatedDamage = base.BaseAttack(target, restartGameAction);
            
            if (target is Hero hero)
            {
                hero.RegenEnergyLow();
            }
            return calculatedDamage;
        }
    }
}
