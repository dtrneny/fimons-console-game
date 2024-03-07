using System;
using System.Collections.Generic;
using HW01_2024.Classes;
using HW01_2024.Enums;
using HW01_2024.Interfaces;
using Action = HW01_2024.Enums.Action;

namespace HW01_2024.ConsoleManagement;

public sealed class OutputManager: IOutputManager
{
    private OutputManager() { }
    private static OutputManager _instance;
    
    public static OutputManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OutputManager();
        }
        return _instance;
    }
    // General and input oriented messages
    public void PrintEmptyLine()
    {
        Console.WriteLine();
    }
    
    private void PrintDivider()
    {
        Console.WriteLine("***");
    }
    
    public void PrintActivitySignMessage()
    {
        Console.WriteLine("Press any key to continue...");
    }
    
    public void PrintSeparatedIntListLengthExceededMessage(int listLength)
    {
        Console.WriteLine($"Invalid input. Please enter {listLength} numbers separated with spaces.");
    }
    
    public void PrintItemIsNotValidIntInRangeMessage(string item, int min, int max)
    {
        Console.WriteLine($"Invalid input. Input '{item}' isn't a valid number in the range of {min} to {max}.");
    }
    
    public void PrintNotValidAction()
    {
        Console.WriteLine("This player action isn't valid.");
    }

    private void PrintColoredStringsAndClearConsole(string[] texts, ConsoleColor color, bool separateWithNewline = false)
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

    private void PrintDecoratedConsoleTexts(string[] texts)
    {
        _instance.PrintDivider();
        _instance.PrintColoredStringsAndClearConsole(texts, ConsoleColor.Yellow, true);
        _instance.PrintDivider();
    }
    
    // FImon oriented messages
    private ConsoleColor GetFImonOriginColor(FImon fimon)
    {
        return fimon.Characteristic.Origin switch
        {
            FImonOrigin.Water => ConsoleColor.Blue,
            FImonOrigin.Fire => ConsoleColor.Red,
            FImonOrigin.Grass => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
    }
    
    public void PrintOrderedFImonsInfo(List<FImon> fimons, bool extendedInfo = false)
    {
        for (var i = 0; i < fimons.Count; i++)
        {
            var fimon = fimons[i];
            
            Console.Write($"{i + 1}. ");
            PrintColoredStringsAndClearConsole([ fimon.Name ], _instance.GetFImonOriginColor(fimon));
            Console.Write($": {fimon.AttackDamage} Attack, {fimon.Health} HP, {fimon.Speed} Speed");
        
            if (extendedInfo)
            {
                Console.Write($", level {fimon.Level}, {fimon.Experience}/100 XP");
            }
        
            PrintEmptyLine();
        }
    }
    
    public void PrintBattleAnnouncementMessage(FImon playerFImon, FImon enemyFImon, int round)
    {
        _instance.PrintDivider();
        Console.Write($"Round {round}: ");
        _instance.PrintColoredStringsAndClearConsole([ playerFImon.Name ], _instance.GetFImonOriginColor(playerFImon));
        Console.Write(" vs. ");
        _instance.PrintColoredStringsAndClearConsole([ enemyFImon.Name ], _instance.GetFImonOriginColor(enemyFImon));
        _instance.PrintEmptyLine();
        _instance.PrintDivider();
    }
    
    public void PrintFImonAttackMessage(FImon attackingFImon, FImon targetedFImon, int damage, bool playersFImon)
    {
        Console.Write(playersFImon ? "Player's " : "Opponent's ");
        _instance.PrintColoredStringsAndClearConsole([ attackingFImon.Name ], _instance.GetFImonOriginColor(attackingFImon));
        Console.Write($" dealt {damage} damage to ");
        Console.Write(playersFImon ? "opponent's " : "player's ");
        _instance.PrintColoredStringsAndClearConsole([ targetedFImon.Name ], _instance.GetFImonOriginColor(targetedFImon));
        _instance.PrintEmptyLine();
    }
    
    public void PrintFImonDefeatMessage(FImon defeatedFImon, bool playersFImon)
    {
        Console.Write(playersFImon ? "Player's " : "Opponent's ");
        _instance.PrintColoredStringsAndClearConsole([ defeatedFImon.Name ], _instance.GetFImonOriginColor(defeatedFImon));
        Console.Write(" was defeated!");
        _instance.PrintEmptyLine();
    }
    
    public void PrintFImonLevelUpMessage(string fimonName, int level)
    {
        _instance.PrintColoredStringsAndClearConsole([ $"{fimonName} is now level {level}!" ], ConsoleColor.Yellow);
        _instance.PrintEmptyLine();
    }

    public void PrintChosenFImons(List<FImon> fimons)
    {
        _instance.PrintDecoratedConsoleTexts(["You have chosen those FImons:"]);
        _instance.PrintOrderedFImonsInfo(fimons);
    }
    
    // Battle oriented messages
    public void PrintBattleResultMessage(bool playerWon)
    {
        _instance.PrintDecoratedConsoleTexts([ $"You {(playerWon ? "won" : "lost")} the battle." ]);
    }
    
    // Game oriented messages
    public void PrintActionMessages(Dictionary<Action, IAction> availableActions)
    {
        _instance.PrintDecoratedConsoleTexts(["Select an action (1-5):"]);
        foreach (var actionPair in availableActions)
        {
            Console.WriteLine($"{(int)actionPair.Key}. {actionPair.Key.ToString()}");
        }
    }
    
    public void PrintIntroductionMessages()
    {
        _instance.PrintDecoratedConsoleTexts([
            "Welcome to the FImon Championship! We're delighted to have you here.",
            "Please select three FImons for your upcoming battles using sequence of numbers (e.g. 1 2 3):"
        ]);
    }
    
    public void PrintSortingMessage()
    {
        _instance.PrintDecoratedConsoleTexts(["Please enter sequence of numbers which represents their order (e.g. 1 2 3):"]);
    }
    
    public void PrintEndingMessage()
    {
        _instance.PrintDecoratedConsoleTexts(["Thank you for playing FImons. We hope you had a great time!"]);
    }
    
    public void PrintVictoryMessages()
    {
        _instance.PrintDecoratedConsoleTexts([
            "Congratulations! You've emerged victorious, defeating all tournament opponents with skill and determination.",
            "As the new champion, you've unlocked the doors to even more exciting tournaments waiting for you to explore."
        ]);
    }
}