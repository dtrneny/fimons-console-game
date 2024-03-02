using System.Collections.Generic;
using System.Linq;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Player : ITournamentContestant
{
    public List<FImon> FImons { get; private set; } = [];

    public void SortFImons(IEnumerable<int> order)
    {
        FImons = order.Select(index => FImons[index - 1]).ToList();
    }
}