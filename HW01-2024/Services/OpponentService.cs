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
            new FImon("Gengar", 7, 19, 28, FImonOrigin.Fire),
            new FImon("Jolteon", 6, 20, 28, FImonOrigin.Water),
            new FImon("Alakazam", 7, 18, 29, FImonOrigin.Grass),
        ]),
        new Opponent([
            new FImon("Pikachu", 6, 18, 30, FImonOrigin.Fire),
            new FImon("Squirtle", 6, 19, 29, FImonOrigin.Water),
            new FImon("Bulbasaur", 6, 18, 30, FImonOrigin.Grass),
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