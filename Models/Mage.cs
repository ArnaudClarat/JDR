using System;
using System.Threading.Tasks;

namespace JDR.Models
{
    public class Mage : Hero
    {
        public Mage(
            string characterName,
            LevelProgression progression,
            int level = 1,
            int experienceValue = 0,
            int energyValue = 40,
            int armorValue = 2,
            int bonusDamage = 0,
            int criticalChance = 2,
            int hasteRating = 5,
            int dodgeRating = 5
            ) : base(characterName, progression)
        {
            Level = level;
            ExperienceValue = experienceValue;
            CurrentEnergyValue = energyValue;
            ArmorValue = armorValue;
            BonusDamage = bonusDamage;
            CriticalChance = criticalChance;
            HasteRating = hasteRating;
            DodgeRating = dodgeRating;
            InitializeStats();
        }

        // Initializes stats
        private void InitializeStats()
        {
            Stamina = StatsCalculator.CalculateStat(2, 1.2, Level);
            Strength = StatsCalculator.CalculateStat(1, 1.05, Level);
            Intellect = StatsCalculator.CalculateStat(4, 1.25, Level);
            Agility = StatsCalculator.CalculateStat(1, 1.05, Level);
            Spirit = StatsCalculator.CalculateStat(3, 1.15, Level);
            CurrentHealthValue = Stamina * 10;
            MaxHealthValue = CurrentHealthValue;
            CurrentEnergyValue = (int)Math.Round(CurrentEnergyValue * (Spirit * 0.65));
            MaxEnergyValue = CurrentEnergyValue;
            AttackValue = (int)Math.Round(Intellect * 1.8);
        }
    
        // Overrides the base LevelUp method to update the stats
        protected override void LevelUp()
        {
            base.LevelUp();
            InitializeStats(); // Updates stats after level up
        }
    
        // The base attack
        public override void BaseAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 2) { return; }
        
            CurrentEnergyValue -= 2;
            int baseDamage = AttackValue - target.ArmorValue;
            int damage = baseDamage <= 0 ? 0 : baseDamage;

            int calculatedDamage = CriticalHit(damage, out bool isCritical);

            string message = isCritical ? "Critical hit! " : "";
            message += $"Base attack from {Name} dealt {calculatedDamage} damage to {target.Name}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }

        // Low tier spell
        public override void LowTierAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 6) { return; }
       
            CurrentEnergyValue -= 6;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 2.4);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            int calculatedDamage = CriticalHit(damage, out bool isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Frost Spikes from {Name} dealt {calculatedDamage} damage to {target.Name}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }

        // Mid tier spell
        public override async void MidTierAttack(Character target, Action refreshUI)
        {
            if (CurrentHealthValue == 0 || CurrentEnergyValue < 4) {  return; }

            CurrentEnergyValue -= 4;
            int originalArmorValue = target.ArmorValue;
            target.ArmorValue *= 4;

            Console.WriteLine($"{target.Name} casts Arcane Shield! Armor value increased temporarily.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            await Task.Delay(4000);

            target.ArmorValue = originalArmorValue;
            Console.WriteLine($"{target.Name}'s Arcane Shield has worn off. Armor value returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
        }

        // Ultimate spell
        public override void UltimateAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 18) { return; }
        
            CurrentEnergyValue -= 18;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 6.9);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            int calculatedDamage = CriticalHit(damage, out bool isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Meteor Blast from {Name} dealt {calculatedDamage} damage to {target.Name}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }
    }
}