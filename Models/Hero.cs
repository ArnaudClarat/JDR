namespace JDR.Models
{
    public enum Direction { Left, Right }
    public abstract class Hero(
        string characterName,
        LevelProgression levelProgression
        ) : Character(0, 0, characterName)
    {
        public Direction FacingDirection { get; private set; } = Direction.Right;
        public LevelProgression LevelProgression { get; private set; } = new();
        public int ExperienceToNextLevel => LevelProgression.ExperienceToLevelUp(Level);
        public event Action? OnLevelUp;
        public int ExperienceValue { get; protected set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Spirit { get; set; }
        public int BonusDamage { get; set; }
        public AttackInfo? LowTierAttackInfo { get; set; }
        public AttackInfo? MidTierAttackInfo { get; set; }
        public AttackInfo? UltimateAttackInfo { get; set; }
        public Weapon? EquippedWeapon { get; private set; }
        public Armor? EquippedArmor { get; private set; }
        public Inventory? Inventory { get; private set; }

        // Makes the Hero move on the map
        public void Move(string direction, int rowCount, int colCount)
        {
            switch (direction)
            {
                case "Up":
                    if (Y > 0) Y--;
                    break;
                case "Down":
                    if (Y < rowCount - 1) Y++;
                    break;
                case "Left":
                    if (X > 0) X--;
                    FacingDirection = Direction.Left;
                    break;
                case "Right":
                    if (X < colCount - 1) X++;
                    FacingDirection = Direction.Right;
                    break;
            }
        }

        public void RegenEnergy(int? regen = null)
        {
            CurrentEnergyValue = regen.HasValue ? Math.Min(CurrentEnergyValue + regen.Value, MaxEnergyValue) : Math.Min(CurrentEnergyValue + Spirit, MaxEnergyValue);
        }
        
        public void RegenEnergyLow()
        {
            CurrentEnergyValue = (int)Math.Min(CurrentEnergyValue + Math.Floor(Spirit * 0.5), MaxEnergyValue);
        }

        protected abstract void InitializeStats();

        // Overrides the base LevelUp method to update the stats
        protected virtual void LevelUp()
        {
            ExperienceValue -= ExperienceToNextLevel;
            Level++;
            Console.WriteLine($"Yay ! {Name} reached level {Level} !");
            OnLevelUp?.Invoke(); ;
            int previousMaxHealthValue = MaxHealthValue;
            int previousMaxEnergyValue = MaxEnergyValue;
            InitializeStats(); // Updates stats after level up

            // Adjust CurrentHealthValue & CurrentEnergyValue proportionally to the increase in MaxHealthValue & MaxEnergyValue
            CurrentHealthValue += MaxHealthValue - previousMaxHealthValue;
            CurrentEnergyValue += MaxEnergyValue - previousMaxEnergyValue;

            // Ensure CurrentHealthValue & CurrentEnergyValue does not exceed MaxHealthValue & MaxEnergyValue
            if (CurrentHealthValue > MaxHealthValue)
                CurrentHealthValue = MaxHealthValue;
            if (CurrentEnergyValue > MaxEnergyValue)
                CurrentEnergyValue = MaxEnergyValue;
        }
        protected bool HandleAttackCost(int cost, Character target)
        {
            if (target.CurrentHealthValue == 0)
            {
                Console.WriteLine($"{target.Name} is already defeated.");
                return false;
            }

            if (CurrentEnergyValue < cost)
            {
                Console.WriteLine("Not enough Mana.");
                return false;
            }

            CurrentEnergyValue -= cost;
            return true;
        }
        private bool PerformAttack(Character target, AttackInfo attackInfo, Action restartGameAction)
        {
            if (!HandleAttackCost(attackInfo.Cost, target)) return false;

            if (target.Dodge())
            {
                Console.WriteLine($"{target.Name} dodged {Name}'s attack!");
                return true;
            }

            int damage = Math.Max(0, (int)Math.Round((AttackValue - target.ArmorValue) * attackInfo.Multiplier));
            int calculatedDamage = CriticalHit(damage, out bool isCritical);

            string message = isCritical ? "Critical hit! " : "";
            message += $"{attackInfo.Name} from {Name} dealt {calculatedDamage} damage to {target.Name}.";
            Console.WriteLine(message);

            target.TakeDamage(calculatedDamage, this, restartGameAction);
            return true;
        }

        public bool LowTierAttack(Character target, Action restartGameAction) => PerformAttack(target, LowTierAttackInfo, restartGameAction);

        public abstract bool MidTierAttack(Character target, Action action);

        public bool UltimateAttack(Character target, Action restartGameAction) => PerformAttack(target, UltimateAttackInfo, restartGameAction);

        // Calculates the experience gained
        public void CalculateExperience(Character target)
        {
            ArgumentNullException.ThrowIfNull(target);

            int levelDifference = target.Level - Level;
            double experienceMath = Math.Max(50 * Math.Pow(1.2, levelDifference), 5); // Minimum experience of 5 guaranteed
            int experienceGained = (int)Math.Round(experienceMath);
            GainExperience(experienceGained, target);
        }

        // Adds the amount of experience gained and checks if it increases the level of the hero
        public void GainExperience(int amount, Character target)
        {
            ExperienceValue += amount;
            Console.WriteLine($"{Name} received {amount} experience points from killing {target.Name}.");

            while (levelProgression.CanLevelUp(Level, ExperienceValue))
            {
                LevelUp();
            }
        }
    
        // Equip item if better and change stats
        public bool EquipItem (Item item)
        {
            if (item is Weapon weapon)
            {
                if (EquippedWeapon == null || weapon.DamageBonus > EquippedWeapon.DamageBonus)
                {
                    if (EquippedWeapon != null)
                    {
                        BonusDamage -= EquippedWeapon.DamageBonus;
                    }

                    BonusDamage += weapon.DamageBonus;
                    EquippedWeapon = weapon;
                    Console.WriteLine($"{Name} equipped a new weapon: {weapon.Name}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{Name} chose not to equip the weapon {weapon.Name} as it is weaker.");
                    return false;
                }
            }
            else if (item is Armor armor)
            {
                if (EquippedArmor == null || armor.ArmorBonus > EquippedArmor.ArmorBonus)
                {
                    if (EquippedArmor != null)
                    {
                        ArmorValue -= EquippedArmor.ArmorBonus;
                    }

                    ArmorValue += armor.ArmorBonus;
                    EquippedArmor = armor;
                    Console.WriteLine($"{Name} equipped new armor : {armor.Name}");
                    return true;
                }
                else 
                {
                    Console.WriteLine($"{Name} chose not to equip the armor {armor.Name} as it is weaker.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Item {item.Name} is not a weapon or armor and he can be equipped.");
                return false;
            }
        }

        public static Hero CreateHero(string heroType, string name)
        {
            return heroType.ToLower() switch
            {
                "mage" => new Mage(name, new LevelProgression()),
                "warrior" => new Warrior(name, new LevelProgression()),
                "archer" => new Archer(name, new LevelProgression()),
                _ => throw new ArgumentException("Invalid hero type !")
            };
        }
    }
}
