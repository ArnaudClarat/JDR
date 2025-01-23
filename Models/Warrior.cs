using System;
using System.Threading.Tasks;

namespace JDR.Models
{
    public class Warrior : Hero
    {
        public Warrior(
            string characterName,
            LevelProgression progression,
            int level = 1,
            int experienceValue = 0,
            int energyValue = 12,
            int armorValue = 4,
            int bonusDamage = 0,
            int criticalChance = 3,
            int hasteRating = 10,
            int dodgeRating = 20,
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
            LowTierAttackInfo = lowTierAttackInfo ?? new AttackInfo("Shield Bash", "A stunning blow with the shield that costs stamina.", 4, 2.2);
            MidTierAttackInfo = midTierAttackInfo ?? new AttackInfo("Battle Cry", "Unleashes a fearsome war cry. Your attack value is now doubled.", 12, 2);
            UltimateAttackInfo = ultimateAttackInfo ?? new AttackInfo("Earthshatter", "A powerful ground strike that damages all enemies in range.", 24, 4.7);
            InitializeStats();
        }

        // Initializes stats
        protected override void InitializeStats()
        {
            Stamina = StatsCalculator.CalculateStat(10, 1.35, Level);
            Strength = StatsCalculator.CalculateStat(3, 1.25, Level);
            Intellect = StatsCalculator.CalculateStat(2, 1.05, Level);
            Agility = StatsCalculator.CalculateStat(3, 1.15, Level);
            Spirit = StatsCalculator.CalculateStat(5, 1.1, Level);
            MaxHealthValue = Stamina * 5;
            MaxEnergyValue = Spirit * 5;
            AttackValue = Strength * 3;
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

            int attackBoost = (int)Math.Floor(AttackValue * 0.5);
            AttackValue += attackBoost;

            Console.WriteLine($"{Name} uses {MidTierAttackInfo.Name}! Attack power temporarily increased.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            // await Task.Delay(5000);
             
            AttackValue -= attackBoost;
            Console.WriteLine($"{Name}'s {MidTierAttackInfo.Name} has worn off. Attack power returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
            return true;
        }
    }
}
