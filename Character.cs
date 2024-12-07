namespace JDR;

public abstract class Character
{
    public string CharacterName { get; set; }
    public int Level { get; set; }
    public int ExperienceValue { get; set; }
    public bool IsDead { get; set; }
    public int HealthValue { get; set; }
    public int EnergyValue { get; set; }
    public int AttackValue { get; set; }
    public int ArmorValue { get; set; }
    
    public Character(string characterName, int level, int experienceValue, bool isDead, int healthValue, int energyValue, int attackValue, int armorValue)
    {
        CharacterName = characterName;
        Level = level;
        ExperienceValue = experienceValue;
        IsDead = isDead;
        HealthValue = healthValue;
        EnergyValue = energyValue;
        AttackValue = attackValue;
        ArmorValue = armorValue;
    }

    public void Attack(Character target)
    {
        if (target.IsDead || EnergyValue <= 0)
            return;
        
        EnergyValue -= 3;
        var damageDealt = AttackValue - target.ArmorValue;
        Console.WriteLine($"{CharacterName} dealt {damageDealt} damage to {target.CharacterName}.");
        target.TakeDamage(damageDealt, this);
    }

    public void TakeDamage(int damage, Character attacker)
    {
        HealthValue -= damage;
        if (HealthValue <= 0)
        {
            Die(attacker);
        }
        Console.WriteLine($"{CharacterName} took {damage} damage from {attacker.CharacterName}.");
    }

    public void Heal(int heal)
    {
        HealthValue += heal;
    }

    public void Die(Character attacker)
    {
        HealthValue = 0;
        IsDead = true;
        Console.WriteLine($"{CharacterName} died !");
        attacker.ExperienceValue += Level * 10;
    }
}