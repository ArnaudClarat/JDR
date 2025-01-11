namespace JDR.Models
{
    public class MonsterGoblin : Monster
    {
        public int Id { get; set; }
        public MonsterGoblin(
            int x,
            int y,
            int heroLevel,
            string characterName = "Goblin",
            int armorValue = 4,
            int criticalChance = 2,
            int hasteRating = 5,
            int dodgeRating = 5
            ) : base(x, y, heroLevel, characterName) { }
    }
}