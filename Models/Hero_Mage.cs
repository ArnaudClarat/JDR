using System;
using System.Threading.Tasks;

namespace JDR.Models
{
    public class HeroMage : Hero
    {
        public HeroMage(
            string characterName,
            LevelProgression progression,
            int level = 2,
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
            EnergyValue = energyValue;
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
            EnergyValue = (int)Math.Round(EnergyValue * (Spirit * 0.65));
            MaxEnergyValue = EnergyValue;
            AttackValue = (int)Math.Round(Intellect * 1.8);
        }
    
        // Overrides the base LevelUp method to update the stats
        protected override void LevelUp()
        {
            base.LevelUp();
            InitializeStats(); // Updates stats after level up
        }
    
        // Decides if the attack is a critical hit
        public int CriticalHit(int baseDamage, out bool isCritical)
        {
            RollResult = rand.Next(1, 101);
            isCritical = RollResult <= CriticalChance; // Return true if the roll result is in the range of the CriticalChance value
            int damage = isCritical ? (int)Math.Round(baseDamage * CriticalHitFactor) : baseDamage; // if result is true then crit damage, else base damage
        
            return damage;
        }
    
        // The base attack
        public override void Cast_BaseAttack(Character target, Action restartGameAction)
        {
            if (target.IsDead || EnergyValue < 2)
                return;
        
            EnergyValue -= 2;
            int baseDamage = AttackValue - target.ArmorValue;
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            bool isCritical;
            int calculatedDamage = CriticalHit(damage, out isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Base attack from {CharacterName} dealt {calculatedDamage} damage to {target.CharacterName}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }

        // Low tier spell
        public void Cast_FrostSpikes(Character target, Action restartGameAction)
        {
            if (target.IsDead || EnergyValue < 6)
                return;
        
            EnergyValue -= 6;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 2.4);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            bool isCritical;
            int calculatedDamage = CriticalHit(damage, out isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Frost Spikes from {CharacterName} dealt {calculatedDamage} damage to {target.CharacterName}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }

        // Mid tier spell
        public async void Cast_ArcaneShield(Action refreshUI)
        {
            if (IsDead || EnergyValue < 4)
                return;

            EnergyValue -= 4;
            int originalArmorValue = ArmorValue;
            ArmorValue *= 4;

            Console.WriteLine($"{CharacterName} casts Arcane Shield! Armor value increased temporarily.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            await Task.Delay(4000);

            ArmorValue = originalArmorValue;
            Console.WriteLine($"{CharacterName}'s Arcane Shield has worn off. Armor value returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
        }

        // Ultimate spell
        public void Cast_MeteorBlast(Character target, Action restartGameAction)
        {
            if (target.IsDead || EnergyValue < 18)
                return;
        
            EnergyValue -= 18;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 6.9);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            bool isCritical;
            int calculatedDamage = CriticalHit(damage, out isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Meteor Blast from {CharacterName} dealt {calculatedDamage} damage to {target.CharacterName}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
        }
    }
}