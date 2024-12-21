namespace JDR.Models
{
    public class Monster : Character
    {
        public int Stamina { get; set; }
        public int Power { get; set; }
        public int CriticalChance { get; set; }
        public int HasteRating { get; set; }
        public int DodgeRating { get; set; }
        public Monster(
            int x,
            int y,
            string characterName,
            bool isDead = false
        ) : base(x, y, characterName, isDead)
        {
        }
    }
}
