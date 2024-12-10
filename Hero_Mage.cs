namespace JDR;

public class HeroMage : Hero
{
    public HeroMage(string characterName, bool isDead, int healthValue, int energyValue, int attackValue, int armorValue, LevelProgression progression, int level, int experienceValue) : base(characterName, isDead, healthValue, energyValue, attackValue, armorValue, progression, level, experienceValue)
    {
    }
}