namespace JDR;

public class Hero : Character
{
    public int ExperienceValue { get; private set; }
    private LevelProgression levelProgression;
    public int ExperienceToNextLevel => levelProgression.ExperienceToLevelUp(Level);
    public event Action OnLevelUp;
    public Hero(string characterName, bool isDead, int healthValue, int energyValue, int attackValue, int armorValue, LevelProgression progression, int level = 1, int experienceValue = 0) : base(characterName, level, isDead, healthValue, energyValue, attackValue, armorValue)
    {
        ExperienceValue = experienceValue;
        levelProgression = progression;
    }

    // Calculates the experience gained
    public void CalculateExperience(Character target)
    {
        int levelDifference = target.Level - Level;
        double experienceMath = 50 * Math.Pow(1.2, levelDifference);
        if (experienceMath < 5)
        {
            experienceMath = 5; // Minimum quantity of experience guaranteed
        }
        
        int experienceGained = (int)Math.Round(experienceMath);
        GainExperience(experienceGained, target);
    }

    // Adds the amount of experience gained and checks if it increases the level of the hero
    public void GainExperience(int amount, Character target)
    {
        ExperienceValue += amount;
        Console.WriteLine($"{CharacterName} received {amount} experience points from killing {target.CharacterName}.");

        while (levelProgression.CanLevelUp(Level, ExperienceValue))
        {
            LevelUp();
        }
    }
    
    // Adds a level to the character
    private void LevelUp()
    {
        ExperienceValue -= ExperienceToNextLevel;
        Level++;
        Console.WriteLine($"Yay ! {CharacterName} reached level {Level} !");
        OnLevelUp?.Invoke();
    }
}