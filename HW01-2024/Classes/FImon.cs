using System;
using HW01_2024.Enums;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class FImon (string name, int attackDamage, int health, int speed, FImonOrigin origin)
{
    private int _experience;
    public string Name { get; } = name;
    public int AttackDamage { get; private set; } = attackDamage;
    public int Health { get; set; } = health;
    private int MaxHealth { get; set; } = health;
    public int Speed { get; private set; } = speed;
    public int Level { get; private set; } = 1;

    public int Experience
    {
        get => _experience;
        set
        {
            if (value < 0) return;
            if (_experience + value >= 100)
            {
                var random = new Random();
                
                AttackDamage += random.Next(1, 3);
                MaxHealth += random.Next(5, 7);
                Speed += random.Next(1, 3);
                Level++;
                
                _experience = (_experience + value) % 100;
            }
            else
            {
                _experience += value;
            }
        }
    }

    public FImonCharacteristic Characteristic { get; } = new(origin);

    public int Attack(FImon target)
    {
        var damage = Characteristic.Origin == target.Characteristic.WeaknessTo
            ? AttackDamage * 2
            : AttackDamage;
        
        target.Health -= damage;

        return damage;
    }

    public bool WillLevelUp(int experiences)
    {
        return Experience + experiences >= 100;
    }

    public void RecoverHealth()
    {
        Health = MaxHealth;
    }
}