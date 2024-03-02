using System;
using System.Collections.Generic;
using HW01_2024.Enums;
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

    public void PrintFarewell()
    {
        Console.WriteLine("Thank you for playing FImons. We hope you enjoyed your stay.");
    }

    public void GetPlayersIntInput(int min, int max, out int value)
    {
        // TODO: domyslet jak resit defaultni hodnotu
        var valid = false;
        value = 0;

        while (!valid)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out value))
            {
                if (value >= min && value <= max)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter number in range of {min} to {max}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
    
    // Start phase functions
    public void HandleIntroduction(List<FImon> starterFImons, out List<FImon> selectedFImons)
    {
        Console.WriteLine("Hello there, this is FImon championship. We are glad that you arrived.");
        Console.WriteLine("Please pick three FImons for your upcoming battles");
        
        // TODO: Extract from InteractionManager
        selectedFImons = [];

        while (selectedFImons.Count < 3)
        {
            PrintOrderedFImons(starterFImons);
            GetPlayersIntInput(1, starterFImons.Count, out var selected);
            var selectedFImon = starterFImons[selected - 1];
            selectedFImons.Add(selectedFImon);
            starterFImons.Remove(selectedFImon);
        }
    }


    // FImon printing functions
    private ConsoleColor GetFImonOriginColor(FImonOrigin origin)
    {
        return origin switch
        {
            FImonOrigin.Water => ConsoleColor.Blue,
            FImonOrigin.Fire => ConsoleColor.Red,
            FImonOrigin.Grass => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
    }
    
    public void PrintFImonIdleStats(FImon fimon)
    {
        Console.ForegroundColor = GetFImonOriginColor(fimon.Origin);
        Console.Write(fimon.Name);
        Console.ResetColor();
        Console.WriteLine($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed, level {fimon.Level}, {fimon.Experience}/100 XP");
    }

    public void PrintFImonBattleStats(FImon fimon)
    {
        Console.ForegroundColor = GetFImonOriginColor(fimon.Origin);
        Console.Write(fimon.Name);
        Console.ResetColor();
        Console.WriteLine($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed");
    }

    public void PrintOrderedFImons(List<FImon> fimons)
    {
        for (var i = 0; i < fimons.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            PrintFImonBattleStats(fimons[i]);
        }
    }
}