namespace JDR.Models
{
    public record AttackInfo(string Name, string Description, int Cost, double Multiplier);
    public abstract class Character(
        int x,
        int y,
        string characterName,
        double criticalHitFactor = 1.72,
        int? hasteValue = null,
        int? dodgeRating = null,
        AttackInfo? baseAttackInfo = null
            )
    {
        protected static readonly Random Rand = new();
        public int RollResult { get; protected set; }
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public string Name { get; set; } = characterName;
        public int Level { get; set; }
        public int CriticalChance { get; set; }
        public int MaxHealthValue { get; set; }
        public int CurrentHealthValue { get; set; }
        public int MaxEnergyValue { get; set; }
        public int CurrentEnergyValue { get; set; }
        public int AttackValue { get; set; }
        public int ArmorValue { get; set; }
        public double CriticalHitFactor { get; set; } = criticalHitFactor;
        public int HasteValue { get; set; } = hasteValue ?? Rand.Next(1, 21);
        public int DodgeRating { get; set; } = dodgeRating ?? Rand.Next(1, 21);
        public AttackInfo BaseAttackInfo { get; protected set; } = baseAttackInfo ?? new AttackInfo("Base attack", "A swift attack with bare hands or a weapon.", 0, 1);

        // The base attack
        public virtual int BaseAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0) return 0;

            int calculatedDamage = 0;
            if (target.Dodge())
            {
                Console.WriteLine($"{target.Name} dodged {Name}'s attack !");
            }
            else
            {
                int damage = Math.Max(0, (int)Math.Floor(AttackValue - target.ArmorValue * BaseAttackInfo.Multiplier));

                calculatedDamage = CriticalHit(damage, out bool isCritical);

                string message = isCritical ? "Critical hit! " : "";
                message += $"{BaseAttackInfo.Name} from {Name} dealt {calculatedDamage} damage to {target.Name}.";

                Console.WriteLine(message);

                target.TakeDamage(calculatedDamage, this, restartGameAction);
            }
            return calculatedDamage;

        }

        public void Heal(int heal)
        {
            int healAmount = Math.Min(CurrentHealthValue + heal, MaxHealthValue) - CurrentHealthValue;
            CurrentHealthValue += healAmount;
            Console.WriteLine($"{Name} healed of {healAmount} HP.");
        }

        // Decides if the attack is dodged
        public bool Dodge() => (Rand.Next(1, 101) <= DodgeRating); // Return true if the roll result is in the range of the DodgeRating value
           
        public void TakeDamage(int damage, Character attacker, Action gameOverAction)
        {
            CurrentHealthValue -= damage;
            
            if (CurrentHealthValue <= 0) Die(attacker, gameOverAction);
        }

        // Decides if the attack is a critical hit
        public int CriticalHit(int baseDamage, out bool isCritical)
        {
            isCritical = Rand.Next(1, 101) <= CriticalChance; // Return true if the roll result is in the range of the CriticalChance value
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