namespace JDR.Models
{
    public abstract class Character
    {
        
        protected static Random rand = new();
        public int RollResult { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string CharacterName { get; set; }
        public int Level { get; set; }
        internal bool IsDead { get; set; }
        public int MaxHealthValue { get; set; }
        public int CurrentHealthValue { get; set; }
        public int MaxEnergyValue { get; set; }
        public int EnergyValue { get; set; }
        public int AttackValue { get; set; }
        public int ArmorValue { get; set; }
        public double CriticalHitFactor { get; set; }
        
        public Character(
            int x,
            int y,
            string characterName,
            bool isDead,
            double criticalHitFactor = 1.72
            )
        {
            X = x;
            Y = y;
            CharacterName = characterName;
            IsDead = isDead;
            CriticalHitFactor = criticalHitFactor;
        }
        
        // The base attack
        public virtual void Cast_BaseAttack(Character target, Action gameOverAction)
        {
            if (target.IsDead)
                return;

            int baseDamage = AttackValue - target.ArmorValue;
            int damage = baseDamage <= 0 ? 0 : baseDamage;

            target.TakeDamage(damage, this, gameOverAction);
        }
        
        public void Heal(int heal)
        {
            int healthBeforeHeal = CurrentHealthValue;
            CurrentHealthValue = Math.Min(CurrentHealthValue + heal, MaxHealthValue);
            int healAmount = CurrentHealthValue - healthBeforeHeal;

            Console.WriteLine($"You healed of {healAmount} HP.");
        }
    
        public void TakeDamage(int damage, Character attacker, Action gameOverAction)
        {
            CurrentHealthValue -= damage;
            
            if (CurrentHealthValue <= 0)
            {
                Die(attacker, gameOverAction);
            }
        }
    
        public void Die(Character attacker, Action gameOverAction)
        {
            CurrentHealthValue = 0;
            IsDead = true;
            Console.WriteLine($"{CharacterName} has died !");
            
            if (attacker is Hero heroAttacker)
            {
                heroAttacker.CalculateExperience(this);
            }
            
            if (attacker is Monster)
            {
                gameOverAction.Invoke();
            }
        }
    }
}