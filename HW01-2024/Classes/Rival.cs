using System.Collections.Generic;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Rival(List<FImon> fimons) : ITournamentContestant
{
    public List<FImon> FImons { get; } = fimons;
}