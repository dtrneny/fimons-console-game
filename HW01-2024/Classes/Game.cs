using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public GamePhase Phase { get; set; } = GamePhase.Starting;
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
        while (Phase != GamePhase.Terminating)
        {
            switch (Phase)
            {
                case GamePhase.Starting:
                    HandleStartingPhase();
                    break;
                case GamePhase.Picking:
                    HandlePickingPhase();
                    break;
                case GamePhase.Fighting:
                    HandleFightingPhase();
                    break;
                case GamePhase.Ending:
                    HandleEndingPhase();
                    break;
                default:
                    break;
            }
        }
    }

    private void HandleStartingPhase()
    {
        InteractionManager.HandleIntroduction(StarterFImons, out var selectedFImons);
        StarterFImons.Clear();
        
        Player.FImons = selectedFImons;
        InteractionManager.PrintOrderedFImons(Player.FImons);

        Phase = GamePhase.Picking;
    }

    private void HandlePickingPhase()
    {
        InteractionManager.PrintActions();
        InteractionManager.GetPlayersIntInput(1, 5, out var action);
        
        HandlePlayerAction(action);
    }
    
    private void HandleFightingPhase()
    {
        Phase = GamePhase.Ending;
    }
    
    private void HandleEndingPhase()
    {
        InteractionManager.PrintFarewell();
        Phase = GamePhase.Terminating;
    }

    private void HandlePlayerAction(int actionNumber)
    {
        switch (actionNumber)
        {
            case 1:
                // TODO: Check enemy
                break;
            case 2:
                Phase = GamePhase.Fighting;
                break;
            case 3:
                InteractionManager.PrintOrderedFImons(Player.FImons);
                break;
            case 4:
                Player.SortFImons();
                break;
            case 5:
                Phase = GamePhase.Ending;
                break;
        }
    }
}