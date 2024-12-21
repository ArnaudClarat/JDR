namespace JDR.Models
{
    public class NPCVillager : NPC
    {
        public int Id { get; set; }
        public NPCVillager(
            int x,
            int y,
            string characterName = "Villageois",
            int id = 0,
            bool isDead = false,
            ) : base(x, y, characterName, isDead)
        {
            Id = id;
        }
    }
}
