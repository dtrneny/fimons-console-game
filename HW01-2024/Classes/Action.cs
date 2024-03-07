using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class CheckAction : IAction
{
    public void Execute(Game context)
    {
        var opponent = context.GetUpcomingOpponent();
        if (opponent == null)
        {
            context.State = new VictoryState();
            return;
        }
        
        context.OutputManager.PrintOrderedFImonsInfo(opponent.FImons);
    }
}

public class FightAction : IAction
{
    public void Execute(Game context)
    {
        context.State = new FightingState();
    }
}

public class InfoAction : IAction
{
    public void Execute(Game context)
    { 
        context.OutputManager.PrintOrderedFImonsInfo(context.Player.FImons, true);
    }
}

public class SortAction : IAction
{
    public void Execute(Game context)
    {
        var player = context.Player;
        context.OutputManager.PrintSortingMessage();
        context.OutputManager.PrintOrderedFImonsInfo(player.FImons);
        var order = context.InputManager.GetPlayersIntInRangeListInput(1, player.FImons.Count, player.FImons.Count);
        player.SortFImons(order);
        context.OutputManager.PrintOrderedFImonsInfo(player.FImons);
    }
}

public class QuitAction : IAction
{
    public void Execute(Game context)
    {
        context.State = new TerminatingState();
    }
}