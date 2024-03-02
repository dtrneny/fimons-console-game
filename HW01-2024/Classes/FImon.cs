using HW01_2024.Enums;

namespace HW01_2024.Classes;

public class FImon (string name, int attackDamage, int health, int speed, FImonOrigin origin)
{
    public string Name { get; set; } = name;
    public int AttackDamage { get; set; } = attackDamage;
    public int Health { get; set; } = health;
    public int Speed { get; set; } = speed;
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    public FImonOrigin Origin { get; } = origin;
    
    
}