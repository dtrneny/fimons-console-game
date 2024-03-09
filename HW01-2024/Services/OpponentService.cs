using System.Collections.Generic;
using HW01_2024.Classes;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Services;

public class OpponentService: IOpponentRepository
{
    private List<Opponent> _opponents =
    [
        new Opponent([
            new FImon("Dragonite", 7, 23, 24, FImonOrigin.Fire),
            new FImon("Lapras", 7, 24, 23, FImonOrigin.Water),
            new FImon("Meganium", 7, 22, 25, FImonOrigin.Grass),
        ]),
        new Opponent([
            new FImon("Jolteon", 10, 20, 24, FImonOrigin.Water),
            new FImon("Alakazam", 6, 25, 29, FImonOrigin.Grass),
            new FImon("Gengar", 9, 19, 26, FImonOrigin.Fire),
        ]),
        new Opponent([
            new FImon("Raichu", 11, 18, 30, FImonOrigin.Fire),
            new FImon("Ninetales", 12, 18, 30, FImonOrigin.Fire),
            new FImon("Squirtle", 8, 19, 29, FImonOrigin.Water),
        ]),
    ];
    
    public Opponent? GetUpcomingOpponent()
    {
        return _opponents.Count > 0 ? _opponents[0] : null;
    }

    public void RemoveOpponentFromTournament(Opponent opponent)
    {
        _opponents.Remove(opponent);
    }

    public bool CheckOpponentAvailability()
    {
        return _opponents.Count > 0;
    }
}