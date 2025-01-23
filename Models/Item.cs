namespace JDR.Models
{
    public class Item(
        string name,
        int staminaBonus = 0,
        int strengthBonus = 0,
        int intellectBonus = 0,
        int agilityBonus = 0,
        int spiritBonus = 0,
        int armorBonus = 0,
        int damageBonus = 0,
        int criticalChanceBonus = 0,
        int hasteBonus = 0,
        int dodgeBonus = 0,
        int weight = 0
        )
    {
        public string Name { get; set; } = name;
        public int StaminaBonus { get; protected set; } = staminaBonus;
        public int StrengthBonus { get; protected set; } = strengthBonus;
        public int IntellectBonus { get; protected set; } = intellectBonus;
        public int AgilityBonus { get; protected set; } = agilityBonus;
        public int SpiritBonus { get; protected set; } = spiritBonus;
        public int ArmorBonus { get; protected set; } = armorBonus;
        public int DamageBonus { get; protected set; } = damageBonus;
        public int CriticalChanceBonus { get; protected set; } = criticalChanceBonus;
        public int HasteBonus { get; protected set; } = hasteBonus;
        public int DodgeBonus { get; protected set; } = dodgeBonus;
        public double Weight { get; protected set; } = weight;
    }
}