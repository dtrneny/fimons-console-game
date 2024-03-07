using System.Collections.Generic;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Opponent(List<FImon> fimons) : ITrainer
{
    public List<FImon> FImons { get; } = fimons;
    
    public void RecoverFImons()
    {
        foreach (var fimon in FImons)
        {
            fimon.RecoverHealth();
        }
    }
}