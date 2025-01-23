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
            int energyValue = 13,
            int armorValue = 1,
            int bonusDamage = 0,
            int criticalChance = 2,
            int hasteRating = 15,
            int dodgeRating = 15,
            AttackInfo? lowTierAttackInfo = null,
            AttackInfo? midTierAttackInfo = null,
            AttackInfo? ultimateAttackInfo = null
            ) : base(characterName, progression)
        {
            Level = level;
            ExperienceValue = experienceValue;
            CurrentEnergyValue = energyValue;
            ArmorValue = armorValue;
            BonusDamage = bonusDamage;
            CriticalChance = criticalChance;
            HasteValue = hasteRating;
            DodgeRating = dodgeRating;
            LowTierAttackInfo = lowTierAttackInfo ?? new AttackInfo("Frost Spikes", "Casts frost spikes that deals Frost damages.", 6, 2.4);
            MidTierAttackInfo = midTierAttackInfo ?? new AttackInfo("Arcane Shield", "Invokes an Arcane shield around you. Your armor value is now quadrupled.", 14, 4);
            UltimateAttackInfo = ultimateAttackInfo ?? new AttackInfo("Meteor Blast", "Casts a powerful meteor blast that deals Fire damages.", 22, 5.9);
            InitializeStats();
        }

        // Initializes stats
        protected override void InitializeStats()
        {
            Stamina = StatsCalculator.CalculateStat(8, 1.27, Level);
            Strength = StatsCalculator.CalculateStat(1, 1.05, Level);
            Intellect = StatsCalculator.CalculateStat(4, 1.27, Level);
            Agility = StatsCalculator.CalculateStat(1, 1.05, Level);
            Spirit = StatsCalculator.CalculateStat(7, 1.27, Level);
            MaxHealthValue = Stamina * 4;
            MaxEnergyValue = Spirit * 8;
            AttackValue = Intellect * 2;
            if (Level == 1) // First initialization
            {
                CurrentHealthValue = MaxHealthValue;
                CurrentEnergyValue = MaxEnergyValue;
            }
        }

        // Mid tier spell
        public override bool MidTierAttack(Character target, Action refreshUI)
        {
            if (!HandleAttackCost(MidTierAttackInfo.Cost, target)) return false;

            int originalArmorValue = target.ArmorValue;
            target.ArmorValue *= (int)Math.Floor(MidTierAttackInfo.Multiplier);

            Console.WriteLine($"{target.Name} casts {MidTierAttackInfo.Name}! Armor value increased temporarily.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            // await Task.Delay(4000);

            target.ArmorValue = originalArmorValue;
            Console.WriteLine($"{target.Name}'s {MidTierAttackInfo.Name} has worn off. Armor value returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
            return true;
        }
    }
}