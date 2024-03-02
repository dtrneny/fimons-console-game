using HW01_2024.Enums;

namespace HW01_2024.Classes;

public class FImon (string name, int attackDamage, int health, int speed, FImonOrigin origin)
{
    public string Name { get; } = name;
    public int AttackDamage { get; } = attackDamage;
    public int Health { get; set; } = health;
    public int Speed { get; } = speed;
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    public FImonCharacteristic Characteristic { get; } = new(origin);

    public void Attack(FImon target)
    {
        if (Health <= 0) return;
        
        var damage = Characteristic.Origin == target.Characteristic.WeaknessTo
            ? AttackDamage * 2
            : AttackDamage;
        target.Health -= damage;
    }
}