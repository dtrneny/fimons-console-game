using System;
using System.Collections.Generic;
using HW01_2024.Interfaces;
using Action = HW01_2024.Enums.Action;

namespace HW01_2024.ConsoleManagement;

public sealed class InputManager
{
    
    private readonly OutputManager _outputManager = OutputManager.GetInstance();
    private InputManager() { }
    private static InputManager _instance;
    
    public static InputManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new InputManager();
        }
        return _instance;
    }
    
    private int? SanitizeIntFromString(string? value)
    {
        return int.TryParse(value, out var output) ? output : null;
    }
    
    private Action? SanitizeActionFromString(string? value)
    {
        return Enum.TryParse<Action>(value, out var output) ? output : null;
    }

    public Action GetPlayersAction()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var sanitizedAction = _instance.SanitizeActionFromString(input);
    
            if (!sanitizedAction.HasValue)
            {
                _outputManager.PrintNotValidAction();
                continue;
            }
    
            return sanitizedAction.Value;
        }
    }
    
    public List<int> GetPlayersIntInRangeListInput(int min, int max, int listLength)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            var parts = input.Split(' ');
            if (parts.Length != listLength)
            {
                _outputManager.PrintSeparatedIntListLengthExceededMessage(listLength);
                continue;
            }

            List<int> output = [];
            foreach (var part in parts)
            {
                var sanitizedInt = _instance.SanitizeIntFromString(part);

                if (!sanitizedInt.HasValue || sanitizedInt < min || sanitizedInt > max)
                {
                    _outputManager.PrintItemIsNotValidIntInRangeMessage(part, min, max);
                    output.Clear();
                    continue;
                }
                
                if (output.Contains(sanitizedInt.Value))
                {
                    _outputManager.PrintNotDistinctValue(sanitizedInt.Value);
                    output.Clear();
                    break;
                }

                output.Add(sanitizedInt.Value);
            }

            if (output.Count == listLength) { return output; }
        }
    }
}