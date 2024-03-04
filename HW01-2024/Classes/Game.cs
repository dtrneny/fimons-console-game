using System;
using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public GamePhase Phase { get; set; } = GamePhase.Starting;
    public Player Player { get; } = new();
    private List<FImon> StarterFImons { get; } = [
        new FImon("Typhlosion", 7, 21, 27, FImonOrigin.Fire),
        new FImon("Feraligatr", 7, 23, 25, FImonOrigin.Water),
        new FImon("Meganium", 7, 22, 26, FImonOrigin.Grass),
        new FImon("Entei", 7, 24, 23, FImonOrigin.Fire),
        new FImon("Suicune", 7, 25, 22, FImonOrigin.Water),
        new FImon("Celebi", 7, 23, 24, FImonOrigin.Grass)
    ];
    private List<Rival> TournamentRivals { get; } = [
        new Rival([
            new FImon("Dragonite", 7, 23, 24, FImonOrigin.Fire),
            new FImon("Lapras", 7, 24, 23, FImonOrigin.Water),
            new FImon("Meganium", 7, 22, 25, FImonOrigin.Grass),
        ]),
        new Rival([
            new FImon("Gengar", 7, 19, 28, FImonOrigin.Fire),
            new FImon("Jolteon", 6, 20, 28, FImonOrigin.Water),
            new FImon("Alakazam", 7, 18, 29, FImonOrigin.Grass),
        ]),
        new Rival([
            new FImon("Pikachu", 6, 18, 30, FImonOrigin.Fire),
            new FImon("Squirtle", 6, 19, 29, FImonOrigin.Water),
            new FImon("Bulbasaur", 6, 18, 30, FImonOrigin.Grass),
        ]),
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
        OutputManager.PrintOrderedFImonsInfo(rival.FImons);
    }

    private void FightAction()
    {
        Phase = GamePhase.Fighting;
    }

    private void InfoAction()
    {
        OutputManager.PrintOrderedFImonsInfo(Player.FImons, true);
    }

    private void SortAction()
    {
        OutputManager.PrintSortingMessage();
        OutputManager.PrintOrderedFImonsInfo(Player.FImons);
        var order = InputManager.GetPlayersIntInRangeListInput(1, Player.FImons.Count, Player.FImons.Count);
        Player.SortFImons(order);
        OutputManager.PrintOrderedFImonsInfo(Player.FImons);
    }
    
    private void QuitAction()
    {
        Phase = GamePhase.Ending;
    }
    
    private void HandleStartingPhase()
    {
        OutputManager.PrintIntroductionMessages();
        OutputManager.PrintOrderedFImonsInfo(StarterFImons);

        var selection = InputManager.GetPlayersIntInRangeListInput(1, StarterFImons.Count, 3);
        
        foreach (var orderNum in selection) { Player.FImons.Add(StarterFImons[orderNum - 1]); }

        OutputManager.PrintChosenFImons(Player.FImons);
        
        StarterFImons.Clear();
        Phase = GamePhase.Picking;
    }

    private void HandlePickingPhase()
    {
        OutputManager.PrintActionsMessages();
        var selectedNum = InputManager.GetPlayersIntInputInRange(1, 5);
        
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
        var playerWon = battle.PerformBattleBetweenContestants(Player, rival) == Player;

        OutputManager.PrintBattleResultMessage(playerWon);
        if (playerWon)
        {
            HandlePlayersVictory();   
            Player.RecoverFImons();
            TournamentRivals.Remove(rival);
        }
        else
        {
            HandlePlayersDefeat();   
            rival.RecoverFImons();
            Player.RecoverFImons();
        }
        
        Phase = GamePhase.Picking;
    }
    
    private void HandleEndingPhase()
    {
        OutputManager.PrintEndingMessage();
        Phase = GamePhase.Terminating;
    }

    private void HandleVictoryPhase()
    {
        OutputManager.PrintVictoryMessages();
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