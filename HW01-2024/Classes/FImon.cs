using HW01_2024.Enums;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class FImon (string name, int attackDamage, int health, int speed, FImonOrigin origin)
{
    private int _experience;
    public string Name { get; } = name;
    public int AttackDamage { get; private set; } = attackDamage;
    public int Health { get; set; } = health;
    public int MaxHealth { get; private set; } = health;
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
                AttackDamage += 2;
                MaxHealth += 5;
                Speed++;
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

    public void Attack(FImon target, int damage)
    {
        target.Health -= damage;
    }

    public bool WillLevelUp(int experiences)
    {
        return Experience + experiences >= 100;
    }
}