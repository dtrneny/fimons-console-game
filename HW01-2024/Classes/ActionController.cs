using System.Collections.Generic;
using HW01_2024.Interfaces;
using Action = HW01_2024.Enums.Action;

namespace HW01_2024.Classes;

public class ActionController(Game context)
{
    private Game Context { get; } = context;
    
    private Dictionary<Action, IAction> _actions = new()
    {
        { Action.Check, new CheckAction() },
        { Action.Fight, new FightAction() },
        { Action.Info, new InfoAction() },
        { Action.Sort, new SortAction() },
        { Action.Quit, new QuitAction() }
    };

    public void ExecuteAction(Action action)
    {
        if (_actions.TryGetValue(action, out var value))
        {
            value.Execute(Context);
        }
        else
        {
            Context.OutputManager.PrintNotValidAction();
        }
    }
}