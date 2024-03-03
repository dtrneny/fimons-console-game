using System.Collections.Generic;
using System.Linq;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Player : ITournamentContestant
{
    public List<FImon> FImons { get; private set; } = [];
    public void RecoverFImons()
    {
        foreach (var fimon in FImons)
        {
            fimon.Health = fimon.MaxHealth;
        }
    }

    public void SortFImons(IEnumerable<int> order)
    {
        // TODO: edge cases
        // TODO: Dat list misto enu
        FImons = order.Select(index => FImons[index - 1]).ToList();
    }
}