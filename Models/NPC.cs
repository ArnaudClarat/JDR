namespace JDR.Models
{
    public class NPC : Character
    {
        public NPC(
            int x,
            int y,
            string characterName,
            bool isDead = false
        ) : base(x, y, characterName, isDead)
        {
        }
    }
}
