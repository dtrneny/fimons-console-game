using System;
using System.Collections.Generic;
using HW01_2024.Classes;
using HW01_2024.Enums;

namespace HW01_2024.ConsoleManagement;

public static class OutputManager
{
    // General and input oriented messages
    public static void PrintEmptyLine()
    {
        Console.WriteLine();
    }
    
    private static void PrintDivider()
    {
        Console.WriteLine("***");
    }
    
    public static void PrintNotValidIntMessage()
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }

    public static void PrintNotValidIntInRangeMessage(int min, int max)
    {
        Console.WriteLine($"Invalid input. Please enter a number in the range of {min} to {max}.");
    }
    
    public static void PrintActivitySignMessage()
    {
        Console.WriteLine("Press any key to continue...");
    }
    
    public static void PrintSeparatedIntListLengthExceededMessage(int listLength)
    {
        Console.WriteLine($"Invalid input. Please enter {listLength} numbers separated with spaces.");
    }
    
    public static void PrintItemIsNotValidIntInRangeMessage(string item, int min, int max)
    {
        Console.WriteLine($"Invalid input. Input '{item}' isn't a valid number in the range of {min} to {max}.");
    }

    private static void PrintColoredStringsAndClearConsole(string[] texts, ConsoleColor color, bool separateWithNewline = false)
    {
        Console.ForegroundColor = color;
        foreach (var text in texts)
        {
            Console.Write(text);
            if (separateWithNewline)
            {
                PrintEmptyLine();
            }
        }
        Console.ResetColor();
    }
    
    // FImon oriented messages
    private static ConsoleColor GetFImonOriginColor(FImon fimon)
    {
        return fimon.Characteristic.Origin switch
        {
            FImonOrigin.Water => ConsoleColor.Blue,
            FImonOrigin.Fire => ConsoleColor.Red,
            FImonOrigin.Grass => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
    }
    
    public static void PrintOrderedFImonsInfo(List<FImon> fimons, bool extendedInfo = false)
    {
        for (var i = 0; i < fimons.Count; i++)
        {
            var fimon = fimons[i];
            Console.Write($"{i + 1}. ");
            PrintColoredStringsAndClearConsole([ fimon.Name ], GetFImonOriginColor(fimon));
            Console.Write($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed");
        
            if (extendedInfo)
            {
                Console.Write($", level {fimon.Level}, {fimon.Experience}/100 XP");
            }
        
            PrintEmptyLine();
        }
    }
    
    public static void PrintBattleAnnouncementMessage(FImon playerFImon, FImon enemyFImon, int round)
    {
        PrintDivider();
        Console.Write($"Round {round}: ");
        PrintColoredStringsAndClearConsole([ playerFImon.Name ], GetFImonOriginColor(playerFImon));
        Console.Write(" vs. ");
        PrintColoredStringsAndClearConsole([ enemyFImon.Name ], GetFImonOriginColor(enemyFImon));
        PrintEmptyLine();
        PrintDivider();
    }
    
    public static void PrintFImonAttackMessage(FImon attackingFImon, FImon targetedFImon, int damage, bool playersFImon)
    {
        Console.Write(playersFImon ? "Player's " : "Enemy's ");
        PrintColoredStringsAndClearConsole([ attackingFImon.Name ], GetFImonOriginColor(attackingFImon));
        Console.Write($" dealt {damage} damage to ");
        Console.Write(playersFImon ? "enemy's " : "player's ");
        PrintColoredStringsAndClearConsole([ targetedFImon.Name ], GetFImonOriginColor(targetedFImon));
        PrintEmptyLine();
    }
    
    public static void PrintFImonDefeatMessage(FImon defeatedFImon, bool playersFImon)
    {
        Console.Write(playersFImon ? "Player's " : "Enemy's ");
        PrintColoredStringsAndClearConsole([ defeatedFImon.Name ], GetFImonOriginColor(defeatedFImon));
        Console.Write(" was defeated!");
        PrintEmptyLine();
    }
    
    public static void PrintFImonLevelUpMessage(string fimonName, int level)
    {
        PrintColoredStringsAndClearConsole([ $"{fimonName} is now level {level}!" ], ConsoleColor.Yellow);
        PrintEmptyLine();
    }

    public static void PrintChosenFImons(List<FImon> fimons)
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "You have chosen those FImons:"
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
        PrintOrderedFImonsInfo(fimons);
    }
    
    // Battle oriented messages
    public static void PrintBattleResultMessage(bool playerWon)
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "You ",
                playerWon ? "won":"lost",
                " the battle."
            ],
            ConsoleColor.Yellow
        );
        PrintEmptyLine();
        PrintDivider();
    }
    
    // Game oriented messages
    public static void PrintActionsMessages()
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "Select an action (1-5):"
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
        Console.WriteLine("1. check");
        Console.WriteLine("2. fight");
        Console.WriteLine("3. info");
        Console.WriteLine("4. sort");
        Console.WriteLine("5. quit");
    }
    
    public static void PrintIntroductionMessages()
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "Welcome to the FImon Championship! We're delighted to have you here.",
                "Please select three FImons for your upcoming battles using sequence of numbers (e.g. 1 2 3):"
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
    }
    
    public static void PrintSortingMessage()
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "Please enter sequence of numbers which represents their order (e.g. 1 2 3):"
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
    }
    
    public static void PrintEndingMessage()
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "Thank you for playing FImons. We hope you had a great time!"
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
    }
    
    public static void PrintVictoryMessages()
    {
        PrintDivider();
        PrintColoredStringsAndClearConsole(
            [
                "Congratulations! You've emerged victorious, defeating all tournament opponents with skill and determination.",
                "As the new champion, you've unlocked the doors to even more exciting tournaments waiting for you to explore."
            ],
            ConsoleColor.Yellow,
            true
        );
        PrintDivider();
    }
}