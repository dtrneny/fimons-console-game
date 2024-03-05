using System;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class StartingState: IGameState
{
    public void Handle(Game context)
    {
        var starterFImons = context.StarterFImons;
        context.OutputManager.PrintIntroductionMessages();
        context.OutputManager.PrintOrderedFImonsInfo(starterFImons);

        var selection = context.InputManager.GetPlayersIntInRangeListInput(1, starterFImons.Count, 3);
        
        foreach (var orderNum in selection) { context.Player.FImons.Add(starterFImons[orderNum - 1]); }

        context.OutputManager.PrintChosenFImons(context.Player.FImons);

        context.State = new PickingState();
    }
}

public class PickingState: IGameState
{
    public void Handle(Game context)
    {
        var selectedAction = context.InputManager.GetPlayersAction();
        context.ActionController.ExecuteAction(selectedAction);
    }
}

public class FightingState: IGameState
{
    public void Handle(Game context)
    {
        var rival = context.GetUpcomingContestant();

        if (rival == null)
        {
            context.State = new VictoryState();
            return;
        }
        
        var battle = new Battle(context.OutputManager, context.InputManager);
        
        var player = context.Player;
        var playerWon = battle.PerformBattleBetweenContestants(player, rival) == player;

        context.OutputManager.PrintBattleResultMessage(playerWon);
        if (playerWon)
        {
            context.Player.RecoverFImons();
            context.TournamentRivals.Remove(rival);
        }
        else
        {
            rival.RecoverFImons();
            context.Player.RecoverFImons();
        }

        context.State = new PickingState();
    }
}

public class VictoryState: IGameState
{
    public void Handle(Game context)
    {
        context.OutputManager.PrintVictoryMessages();
        context.State = new TerminatingState();
    }
}

public class TerminatingState: IGameState
{
    public void Handle(Game context)
    {
        context.OutputManager.PrintEndingMessage();
        context.GameEnded = true;
    }
}

