using System;

namespace JDR.Models
{
    public class LifeFountain(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        // Heals the Hero when it touches the fountain
        public static void HealPlayer(Hero hero)
        {
            // Calculates an amount from range 25% ~ 75% of Hero's MaxHealthValue
            Random random = new();
            int healPercentage = random.Next(25, 76); // random of 25% ~ 75%
            int healAmount = hero.MaxHealthValue * healPercentage / 100;

            Console.WriteLine($"You touched a Life Fountain ! All of your mana has been restored ! ");
            hero.Heal(healAmount);
            hero.CurrentEnergyValue = hero.MaxEnergyValue;
        }
    }
}
