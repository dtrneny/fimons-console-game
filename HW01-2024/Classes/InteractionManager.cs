using System;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class InteractionManager: IInteractionManager
{
    public void PrintActions()
    {
        Console.WriteLine("Choose your action [1-5]: ");
        Console.WriteLine("1. check");
        Console.WriteLine("2. fight");
        Console.WriteLine("3. info");
        Console.WriteLine("4. sort");
        Console.WriteLine("5. quit");
    }

    public void PrintFImonIdleStats(FImon fimon)
    {
        throw new System.NotImplementedException();
    }

    public void PrintFImonBattleStats(FImon fimon)
    {
        throw new System.NotImplementedException();
    }
}