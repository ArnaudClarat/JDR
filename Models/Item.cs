namespace JDR.Models
{
    public class Item
    {
        public string Name { get; }
        public int StaminaBonus { get; }
        public int StrengthBonus { get; }
        public int IntellectBonus { get; }
        public int AgilityBonus { get; }
        public int SpiritBonus { get; }
        public int ArmorBonus { get; }
        public int DamageBonus { get; }
        public int CriticalChanceBonus { get; }
        public int HasteBonus { get; }
        public int DodgeBonus { get; }

        public Item(
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
            int dodgeBonus = 0
        )
        {
            Name = name;
            StaminaBonus = staminaBonus;
            StrengthBonus = strengthBonus;
            IntellectBonus = intellectBonus;
            AgilityBonus = agilityBonus;
            SpiritBonus = spiritBonus;
            ArmorBonus = armorBonus;
            DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
        }
    }
}