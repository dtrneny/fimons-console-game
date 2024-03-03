using System;
using System.Collections.Generic;
using HW01_2024.Enums;

namespace HW01_2024.Classes;

public static class InteractionManager
{
    public static void PrintActions()
    {
        Console.WriteLine("Choose your action e. g. [1]: ");
        Console.WriteLine("1. check");
        Console.WriteLine("2. fight");
        Console.WriteLine("3. info");
        Console.WriteLine("4. sort");
        Console.WriteLine("5. quit");
    }

    public static void PrintFarewell()
    {
        Console.WriteLine("Thank you for playing FImons. We hope you enjoyed your stay.");
    }
    
    public static void PrintIntroduction()
    {
        Console.WriteLine("Hello there, this is FImon championship. We are glad that you arrived.");
        Console.WriteLine("Please pick three FImons for your upcoming battles e. g. [1 2 3]");
    }

    public static void PrintSortingInstructions()
    {
        Console.WriteLine("Please enter FImons order [e. g. 1 2 3]");
    }
    
    private static int? SanitizeIntFromString(string? value)
    {
        return int.TryParse(value, out var output) ? output : null;
    }

    public static int GetPlayersIntInput(int min, int max)
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

    public static void GetPlayersActivityInput()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
    }

    public static IEnumerable<int> GetPlayersIntListInput(int min, int max, int length)
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
    
    private static void PrintFImonColoredName(FImon fimon)
    {
        var originColor = fimon.Characteristic.Origin switch
        {
            FImonOrigin.Water => ConsoleColor.Blue,
            FImonOrigin.Fire => ConsoleColor.Red,
            FImonOrigin.Grass => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
        
        Console.ForegroundColor = originColor;
        Console.Write(fimon.Name);
        Console.ResetColor();
    }
    
    public static void PrintOrderedBattleFImons(List<FImon> fimons)
    {
        for (var i = 0; i < fimons.Count; i++)
        {
            var fimon = fimons[i];
            Console.Write($"{i + 1}. ");
            PrintFImonColoredName(fimon);
            Console.WriteLine($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed");
        }
    }
    
    public static void PrintOrderedIdleFImons(List<FImon> fimons)
    {
        for (var i = 0; i < fimons.Count; i++)
        {
            var fimon = fimons[i];
            Console.Write($"{i + 1}. ");
            PrintFImonColoredName(fimon);
            Console.WriteLine($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed, level {fimon.Level}, {fimon.Experience}/100 XP");
        }
    }

    public static void PrintBattleAnnouncement(FImon playerFImon, FImon enemyFImon, int round)
    {
        PrintDivider();
        Console.Write($"Round {round}: ");
        PrintFImonColoredName(playerFImon);
        Console.Write(" vs. ");
        PrintFImonColoredName(enemyFImon);
        Console.WriteLine();
        PrintDivider();
    }

    public static void PrintAttackMessage(FImon attackingFImon, FImon targetedFImon, int damage, bool playerAttacking)
    {
        Console.Write(playerAttacking ? "Player's " : "Enemy's ");
        PrintFImonColoredName(attackingFImon);
        Console.Write($" dealt {damage} damage to ");
        Console.Write(playerAttacking ? "enemy's " : "player's ");
        PrintFImonColoredName(targetedFImon);
        Console.WriteLine();
    }

    public static void PrintFImonDefeatMessage(FImon defeatedFImon, bool playersFImon)
    {
        Console.Write(playersFImon ? "Player's " : "Enemy's ");
        PrintFImonColoredName(defeatedFImon);
        Console.Write(" was defeated!");
        Console.WriteLine();
    }

    public static void PrintBattleResult(bool playerWon)
    {
        PrintDivider();
        Console.Write("You ");
        Console.Write(playerWon ? "won":"lost");
        Console.WriteLine(" the battle.");
        PrintDivider();
    }

    public static void PrintFImonLevelUpMessage(string fimonName, int level)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{fimonName} is now level {level}!");
        Console.ResetColor();
    }

    private static void PrintDivider()
    {
        Console.WriteLine("***");
    }

    public static void PrintVictoryMessages()
    {
        PrintDivider();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Congratulations! You've emerged victorious, defeating all tournament opponents with skill and determination.");
        Console.WriteLine("As the new champion, you've unlocked the doors to even more exciting tournaments waiting for you to explore.");
        Console.ResetColor();
        PrintDivider();
    }
}