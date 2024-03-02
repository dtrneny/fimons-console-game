using HW01_2024.Enums;

namespace HW01_2024.Classes;

public class FImon
{
    public string Name { get; set; }
    public int AttackDamage { get; set; }
    public int Health { get; set; }
    public int Speed { get; set; }
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    public FImonOrigin Origin { get; set; }
    
    
}