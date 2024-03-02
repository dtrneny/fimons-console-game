using System;
using System.Collections.Generic;
using System.Linq;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class InteractionManager: IInteractionManager
{
    public void PrintActions()
    {
        Console.WriteLine("Choose your action e. g. [1]: ");
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
    
    public void PrintIntroduction()
    {
        Console.WriteLine("Hello there, this is FImon championship. We are glad that you arrived.");
        Console.WriteLine("Please pick three FImons for your upcoming battles e. g. [1 2 3]");
    }

    public void PrintSortingInstructions()
    {
        Console.WriteLine("Please enter FImons order [e. g. 1 2 3]");
    }
    
    private int? SanitizeIntFromString(string? value)
    {
        return int.TryParse(value, out var output) ? output : null;
    }

    public int GetPlayersIntInput(int min, int max)
    {
        while (true)
        {
            var input = Console.ReadLine();
            var sanitizedInt = SanitizeIntFromString(input);

            if (!sanitizedInt.HasValue)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (!(sanitizedInt < min) && !(sanitizedInt > max)) { return sanitizedInt.Value; }
            
            Console.WriteLine($"Invalid input. Please enter a number in the range of {min} to {max}.");

        }
    }

    public IEnumerable<int> GetPlayersIntListInput(int min, int max, int length)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            var parts = input.Split(' ');
            if (parts.Length != length)
            {
                Console.WriteLine($"Invalid input. Please enter {length} numbers separated with spaces.");
                continue;
            }

            List<int> output = [];
            foreach (var part in parts)
            {
                var sanitizedInt = SanitizeIntFromString(part);

                if (!sanitizedInt.HasValue || sanitizedInt < min || sanitizedInt > max)
                {
                    Console.WriteLine($"Invalid input. Input '{part}' isn't a valid number in the range of {min} to {max}. Please try again.");
                    output.Clear();
                    break;
                }

                output.Add(sanitizedInt.Value);
            }

            if (output.Count == length) { return output; }
        }
    }
    
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