using System.Collections.Generic;
using System.Linq;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Player : ITrainer
{
    public List<FImon> FImons { get; private set; } = [];
    public void RecoverFImons()
    {
        foreach (var fimon in FImons)
        {
            fimon.RecoverHealth();
        }
    }

    public void SortFImons(List<int> order)
    {
        FImons = order
            .Where(index => index >= 1 && index <= FImons.Count)
            .Select(index => FImons[index - 1])
            .ToList();
    }
}