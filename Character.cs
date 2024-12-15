namespace JDR;

public abstract class Character
{
    public string CharacterName { get; set; }
    public int Level { get; set; }
    private bool IsDead { get; set; }
    public int HealthValue { get; set; }
    public int EnergyValue { get; set; }
    public int AttackValue { get; set; }
    public int ArmorValue { get; set; }
    public double CriticalHitFactor { get; set; }
    
    public Character(string characterName, bool isDead, int energyValue, int armorValue, int level, double criticalHitFactor = 2)
    {
        CharacterName = characterName;
        Level = level;
        IsDead = isDead;
        EnergyValue = energyValue;
        ArmorValue = armorValue;
        CriticalHitFactor = criticalHitFactor;
    }

    public void Attack(Character target)
    {
        if (target.IsDead || EnergyValue <= 0)
            return;
        
        var damageDealt = AttackValue - target.ArmorValue;
        Console.WriteLine($"{CharacterName} dealt {damageDealt} damage to {target.CharacterName}.");
        target.TakeDamage(damageDealt, this);
    }

    public void TakeDamage(int damage, Character attacker)
    {
        Console.WriteLine($"{CharacterName} took {damage} damage from {attacker.CharacterName}.");
        HealthValue -= damage;
        if (HealthValue <= 0)
        {
            Die(attacker);
        }
    }

    public void Heal(int heal)
    {
        HealthValue += heal;
    }

    public void Die(Character attacker)
    {
        HealthValue = 0;
        IsDead = true;
        Console.WriteLine($"{CharacterName} has died !");
        if (attacker is Hero heroAttacker)
        {
            heroAttacker.CalculateExperience(this);
        }
    }
}