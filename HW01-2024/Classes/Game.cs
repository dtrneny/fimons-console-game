using System;
using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public bool GameEnded { get; set; }
    public IGameState State { get; set; } = new StartingState();
    public Player Player { get; } = new();
    public readonly InputManager InputManager = InputManager.GetInstance();
    public readonly OutputManager OutputManager = OutputManager.GetInstance();
    public readonly ActionController ActionController;

    public Game()
    {
        ActionController = new ActionController(this);
    }

    public List<FImon> StarterFImons { get; } = [
        new FImon("Typhlosion", 7, 21, 27, FImonOrigin.Fire),
        new FImon("Feraligatr", 7, 23, 25, FImonOrigin.Water),
        new FImon("Meganium", 7, 22, 26, FImonOrigin.Grass),
        new FImon("Entei", 7, 24, 23, FImonOrigin.Fire),
        new FImon("Suicune", 7, 25, 22, FImonOrigin.Water),
        new FImon("Celebi", 7, 23, 24, FImonOrigin.Grass)
    ];
    public List<Opponent> TournamentOpponents { get; } = [
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
    
    public void Start()
    {
        while (!GameEnded)
        {
           State.Handle(this);
        }
    }
    
    public Opponent? GetUpcomingOpponent()
    {
        return TournamentOpponents.Count > 0 ? TournamentOpponents[0] : null;
    }
}