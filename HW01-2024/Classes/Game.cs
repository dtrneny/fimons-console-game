using System;
using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public GamePhase Phase { get; set; } = GamePhase.Starting;
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

    private List<Rival> TournamentRivals { get; } =
    [
        new Rival([
            new FImon("Charmeleon", 6, 18, 23, FImonOrigin.Fire),
            new FImon("Wartortle", 6, 18, 23, FImonOrigin.Water),
            new FImon("Ivysaur", 5, 16, 22, FImonOrigin.Grass),
        ]),
        new Rival([
            new FImon("Charizard", 7, 20, 28, FImonOrigin.Fire),
            new FImon("Charmander", 5, 15, 25, FImonOrigin.Fire),
            new FImon("Squirtle", 5, 15, 25, FImonOrigin.Water),
        ]),
        new Rival([
            new FImon("Charizard", 7, 20, 28, FImonOrigin.Fire),
            new FImon("Charmander", 5, 15, 25, FImonOrigin.Fire),
            new FImon("Squirtle", 5, 15, 25, FImonOrigin.Water),
        ])
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
                case GamePhase.Victory:
                    HandleVictoryPhase();
                    break;
                case GamePhase.Terminating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    private void HandlePlayerAction(int actionNumber)
    {
        // TODO: default
        // TODO: handle actionNumber
        switch (actionNumber)
        {
            case 1:
                CheckAction();
                break;
            case 2:
                FightAction();
                break;
            case 3:
                InfoAction();
                break;
            case 4:
                SortAction();
                break;
            case 5:
                QuitAction();
                break;
        }
    }

    private void CheckAction()
    {
        if (!UpcomingContestantAvailable()) { return; }
        
        var rival = TournamentRivals[0];
        InteractionManager.PrintOrderedBattleFImons(rival.FImons);
    }

    private void FightAction()
    {
        Phase = GamePhase.Fighting;
    }

    private void InfoAction()
    {
        InteractionManager.PrintOrderedIdleFImons(Player.FImons);
    }

    private void SortAction()
    {
        InteractionManager.PrintSortingInstructions();
        InteractionManager.PrintOrderedBattleFImons(Player.FImons);
        var order = InteractionManager.GetPlayersIntListInput(1, Player.FImons.Count, Player.FImons.Count);
        Player.SortFImons(order);
        InteractionManager.PrintOrderedBattleFImons(Player.FImons);
    }
    
    private void QuitAction()
    {
        Phase = GamePhase.Ending;
    }
    
    private void HandleStartingPhase()
    {
        InteractionManager.PrintIntroduction();
        InteractionManager.PrintOrderedBattleFImons(StarterFImons);
        
        var selection = InteractionManager.GetPlayersIntListInput(1, StarterFImons.Count, 3);

        foreach (var orderNum in selection) { Player.FImons.Add(StarterFImons[orderNum - 1]); }
        
        InteractionManager.PrintOrderedBattleFImons(Player.FImons);
        
        StarterFImons.Clear();
        Phase = GamePhase.Picking;
    }

    private void HandlePickingPhase()
    {
        InteractionManager.PrintActions();
        var selectedNum = InteractionManager.GetPlayersIntInput(1, 5);
        
        HandlePlayerAction(selectedNum);
    }
    
    private void HandleFightingPhase()
    {
        if (!UpcomingContestantAvailable())
        {
            Phase = GamePhase.Victory;
            return;
        }
        
        var battle = new Battle();
        
        var rival = TournamentRivals[0];
        var battleResult = battle.PerformBattleBetweenContestants(Player, rival) == Player;

        InteractionManager.PrintBattleResult(battleResult);
        if (battleResult)
        {
            HandlePlayersVictory();   
            Player.RecoverFImons();
        }
        else
        {
            HandlePlayersDefeat();   
            rival.RecoverFImons();
            Player.RecoverFImons();
        }

        TournamentRivals.Remove(rival);
        Phase = GamePhase.Picking;
    }
    
    private void HandleEndingPhase()
    {
        InteractionManager.PrintFarewell();
        Phase = GamePhase.Terminating;
    }

    private void HandleVictoryPhase()
    {
        InteractionManager.PrintVictoryMessages();
        Phase = GamePhase.Ending;
    }

    private bool UpcomingContestantAvailable()
    {
        return TournamentRivals.Count > 0;
    }

    private void HandlePlayersVictory()
    {
        var fimonXpBonus = 85 + (15 * TournamentRivals.Count);
        foreach (var fimon in Player.FImons)
        {
            fimon.Experience = fimonXpBonus;
        }
    }

    private void HandlePlayersDefeat()
    {
        var fimonXpBonus = (85 + (15 * TournamentRivals.Count)) / 2;
        foreach (var fimon in Player.FImons)
        {
            fimon.Experience = fimonXpBonus;
        }
    }
}