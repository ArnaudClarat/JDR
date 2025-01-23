using System;
using System.Threading.Tasks;

namespace JDR.Models
{
    public class Archer : Hero
    {
        public Archer(
            string characterName,
            LevelProgression levelProgression,
            int level = 1,
            int experienceValue = 0,
            int energyValue = 11,
            int armorValue = 2,
            int bonusDamage = 0,
            int criticalChance = 5,
            int hasteRating = 20,
            int dodgeRating = 15,
            AttackInfo? lowTierAttackInfo = null,
            AttackInfo? midTierAttackInfo = null,
            AttackInfo? ultimateAttackInfo = null
        ) : base(characterName, levelProgression)
        {
            Level = level;
            ExperienceValue = experienceValue;
            CurrentEnergyValue = energyValue;
            ArmorValue = armorValue;
            BonusDamage = bonusDamage;
            CriticalChance = criticalChance;
            HasteValue = hasteRating;
            DodgeRating = dodgeRating;
            LowTierAttackInfo = lowTierAttackInfo ?? new AttackInfo("Quick Shot", "A swift arrow shot dealing minor damage.", 5, 1.4);
            MidTierAttackInfo = midTierAttackInfo ?? new AttackInfo("Piercing Arrow", "Fires an arrow that ignores half of the target's armor.", 16, 0.5);
            UltimateAttackInfo = ultimateAttackInfo ?? new AttackInfo("Rain of Arrows", "Launches a volley of arrows, damaging all enemies in range.", 20, 3.9);
            InitializeStats();
        }

        // Initializes stats
        protected override void InitializeStats()
        {
            Stamina = StatsCalculator.CalculateStat(8, 1.3, Level);
            Strength = StatsCalculator.CalculateStat(2, 1.15, Level);
            Intellect = StatsCalculator.CalculateStat(3, 1.1, Level);
            Agility = StatsCalculator.CalculateStat(5, 1.3, Level);
            Spirit = StatsCalculator.CalculateStat(6, 1.2, Level);
            MaxHealthValue = Stamina * 4;
            MaxEnergyValue = Spirit * 6;
            AttackValue = Agility * 3;
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

            int reducedArmor = (int)Math.Floor(target.ArmorValue * MidTierAttackInfo.Multiplier);
            int originalArmorValue = target.ArmorValue;
            target.ArmorValue -= reducedArmor;

            Console.WriteLine($"{Name} uses {MidTierAttackInfo.Name}! {target.Name}'s armor is reduced temporarily.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            // await Task.Delay(4000);

            target.ArmorValue = originalArmorValue;
            Console.WriteLine($"{Name}'s {MidTierAttackInfo.Name} effect has worn off. {target.Name}'s armor returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
            return true;
        }
    }
}
