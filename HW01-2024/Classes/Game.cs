using System;
using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public GameState State { get; set; } = GameState.Start;
    private InteractionManager InteractionManager { get; } = new();
    public Player Player { get; } = new();

    private List<FImon> StarterFImons { get; } =
    [
        new FImon("Charizard", 7, 20, 28, FImonOrigin.Fire),
        new FImon("Charmander", 5, 15, 25, FImonOrigin.Fire),
        new FImon("Squirtle", 5, 15, 25, FImonOrigin.Water),
        new FImon("Bulbasaur", 4, 17, 20, FImonOrigin.Grass),
        new FImon("Charmeleon", 6, 18, 23, FImonOrigin.Fire),
        new FImon("Wartortle", 6, 18, 23, FImonOrigin.Water),
        new FImon("Ivysaur", 5, 16, 22, FImonOrigin.Grass),
    ];

    public void Start()
    {
        StartGameLoop();
    }

    public void StartGameLoop()
    {
        while (State != GameState.Finished)
        {
            switch (State)
            {
                case GameState.Start:
                    InteractionManager.HandleIntroduction(StarterFImons, out var selectedFImons);
                    StarterFImons.Clear();
                    Player.FImons = selectedFImons;
                    foreach (var fimon in Player.FImons)
                    {
                        InteractionManager.PrintFImonIdleStats(fimon);
                    }

                    State = GameState.Battle;
                    break;
                case GameState.Battle:
                    InteractionManager.PrintActions();
                    InteractionManager.GetPlayersIntInput(1, 5, out var action);
                    HandlePlayerAction(action);
                    State = GameState.Finished;
                    break;
                case GameState.Finished:
                    Console.WriteLine("Finished");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
    }
    
    // Console.WriteLine("1. check");
    // Console.WriteLine("2. fight");
    // Console.WriteLine("3. info");
    // Console.WriteLine("4. sort");
    // Console.WriteLine("5. quit");

    private void HandlePlayerAction(int actionNumber)
    {
        switch (actionNumber)
        {
            case 1:
                Console.WriteLine("Checking");
                break;
            case 2:
                Console.WriteLine("Fighting");
                break;
            case 3:
                Console.WriteLine("Getting info");
                break;
            case 4:
                Console.WriteLine("Sorting");
                break;
            case 5:
                Console.WriteLine("Quiting");
                break;
        }
    }
}