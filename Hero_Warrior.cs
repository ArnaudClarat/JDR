namespace JDR;

public class HeroWarrior : Hero
{
    public HeroWarrior(
        string characterName,
        bool isDead,
        int energyValue,
        int armorValue,
        LevelProgression progression,
        int level,
        int experienceValue,
        int armor = 4,
        int bonusDamage = 0,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
    ) : base(characterName, isDead, energyValue, armorValue, progression, level, experienceValue)
    {
        Armor = armor;
        BonusDamage = bonusDamage;
        CriticalChance = criticalChance;
        HasteRating = hasteRating;
        DodgeRating = dodgeRating;
        InitializeStats();
    }

    // Initializes stats
    private void InitializeStats()
    {
        Stamina = HeroStatsCalculator.CalculateStat(4, 1.3, Level);
        Strength = HeroStatsCalculator.CalculateStat(4, 1.25, Level);
        Intellect = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Agility = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Spirit = HeroStatsCalculator.CalculateStat(2, 1.15, Level);
        HealthValue = Stamina * 10;
        AttackValue = (int)Math.Round(Strength * 1.8);
    }
    
    protected override void LevelUp()
    {
        base.LevelUp();
        InitializeStats(); // Updates stats after level up
    }
}