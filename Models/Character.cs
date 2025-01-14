namespace JDR.Models
{
    public abstract class Character
    {
        
        protected static Random rand = new();
        public int RollResult { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int CriticalChance { get; set; }
        public int MaxHealthValue { get; set; }
        public int CurrentHealthValue { get; set; }
        public int MaxEnergyValue { get; set; }
        public int CurrentEnergyValue { get; set; }
        public int AttackValue { get; set; }
        public int ArmorValue { get; set; }
        public double CriticalHitFactor { get; set; }
        public int HasteValue { get; set; }
        public int DodgeRating { get; set; }

        public Character(
            int x,
            int y,
            string characterName,
            double criticalHitFactor = 1.72,
            int? hasteValue = null,
            int? dodgeRating = null
            )
        {
            X = x;
            Y = y;
            Name = characterName;
            CriticalHitFactor = criticalHitFactor;
            HasteValue = hasteValue ?? rand.Next(1, 21);
            DodgeRating = dodgeRating ?? rand.Next(1, 21);
        }
        
        // The base attack
        public virtual void BaseAttack(Character target, Action gameOverAction)
        {
            if (target.CurrentHealthValue == 0) { return; }

            int baseDamage = AttackValue - target.ArmorValue;
            int damage = baseDamage <= 0 ? 0 : baseDamage;

            target.TakeDamage(damage, this, gameOverAction);
        }
        
        public void Heal(int heal)
        {
            int healthBeforeHeal = CurrentHealthValue;
            CurrentHealthValue = Math.Min(CurrentHealthValue + heal, MaxHealthValue);
            int healAmount = CurrentHealthValue - healthBeforeHeal;

            Console.WriteLine($"{Name} healed of {healAmount} HP.");
        }

        // Decides if the attack is dodged
        public bool Dodge()
        {
            if (rand.Next(1, 101) <= DodgeRating) // Return true if the roll result is in the range of the DodgeRating value
            {
                return true;
            }
            return false;
        }
        
        public void TakeDamage(int damage, Character attacker, Action gameOverAction)
        {
            CurrentHealthValue -= damage;
            
            if (CurrentHealthValue <= 0)
            {
                Die(attacker, gameOverAction);
            }
        }

        // Decides if the attack is a critical hit
        public int CriticalHit(int baseDamage, out bool isCritical)
        {
            isCritical = rand.Next(1, 101) <= CriticalChance; // Return true if the roll result is in the range of the CriticalChance value
            return isCritical ? (int)(baseDamage * CriticalHitFactor) : baseDamage; // if result is true then crit damage, else base damage
        }
        
        public void Die(Character attacker, Action gameOverAction)
        {
            CurrentHealthValue = 0;
            Console.WriteLine($"{Name} has died !");
            
            if (attacker is Hero heroAttacker)
            {
                heroAttacker.CalculateExperience(this);
                heroAttacker.RegenEnergy();
            }
            
            if (attacker is Monster)
            {
                gameOverAction.Invoke();
            }
        }
    }
}