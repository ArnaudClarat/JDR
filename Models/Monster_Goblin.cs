namespace JDR.Models
{
    public class MonsterGoblin(
        int x,
        int y,
        int heroLevel,
        string characterName = "Goblin",
        int armorValue = 4,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
            ) : Monster(x, y, heroLevel, characterName, armorValue, criticalChance, hasteRating, dodgeRating)
    {
    }
}