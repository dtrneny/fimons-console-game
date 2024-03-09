using System;
using System.Collections.Generic;
using System.Linq;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Player : ITrainer
{
    public List<FImon> FImons { get; set; } = [];

    public Player() {}
    
    public Player(List<FImon> fimons)
    {
        FImons = fimons;
    }
    
    public void RecoverFImons()
    {
        foreach (var fimon in FImons)
        {
            fimon.RecoverHealth();
        }
    }

    public void SortFImons(List<int> order)
    {
        if (order.Count != FImons.Count || order.Any(index => index < 1 || index > FImons.Count)) { return; }

        FImons = order
            .Select(index => FImons[index - 1])
            .ToList();
    }
}