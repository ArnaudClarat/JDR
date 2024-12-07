namespace JDR;

public abstract class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int HealthValue { get; set; }
    public int EnergyValue { get; set; }
    public int AttackValue { get; set; }
    public int ArmorValue { get; set; }
    
    public Character(string name, int level, int experience, int healthValue, int energyValue, int attackValue, int armorValue)
    {
        Name = name;
        Experience = experience;
        HealthValue = healthValue;
        EnergyValue = energyValue;
        AttackValue = attackValue;
        ArmorValue = armorValue;
    }

    public void Attack(Character target)
    {
        EnergyValue -= 3;
        var damageDealt = AttackValue - target.ArmorValue;
        target.TakeDamage(damageDealt, this);
        Console.WriteLine($"{this.Name} dealt {damageDealt} damage to {target.Name}");
    }

    public void TakeDamage(int damage, Character attacker)
    {
        HealthValue -= damage;
        if (HealthValue <= 0)
        { 
            Die(attacker);
        }
        Console.WriteLine($"{this.Name} took {damage} damage from {attacker.Name}");
    }

    public void Heal(int heal)
    {
        HealthValue += heal;
    }

    public void Die(Character attacker)
    {
        Console.WriteLine("You died !");
        attacker.Experience += Level * 10;
    }
}