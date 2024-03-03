using System;
using System.Collections.Generic;

namespace HW01_2024.Managers;

public static class InputManager
{
    private static int? SanitizeIntFromString(string? value)
    {
        return int.TryParse(value, out var output) ? output : null;
    }
    
    public static int GetPlayersIntInputInRange(int min, int max)
    {
        while (true)
        {
            var input = Console.ReadLine();
            var sanitizedInt = SanitizeIntFromString(input);

            if (!sanitizedInt.HasValue)
            {
                OutputManager.PrintNotValidIntMessage();
                continue;
            }

            if (!(sanitizedInt < min) && !(sanitizedInt > max)) { return sanitizedInt.Value; }
            
            OutputManager.PrintNotValidIntInRangeMessage(min, max);
        }
    }
    
    public static void GetPlayersActivitySign()
    {
        OutputManager.PrintActivitySignMessage();
        Console.ReadKey();
        OutputManager.PrintEmptyLine();
    }
    
    public static List<int> GetPlayersIntInRangeListInput(int min, int max, int listLength)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            var parts = input.Split(' ');
            if (parts.Length != listLength)
            {
                OutputManager.PrintSeparatedIntListLengthExceededMessage(listLength);
                continue;
            }

            List<int> output = [];
            foreach (var part in parts)
            {
                var sanitizedInt = SanitizeIntFromString(part);

                if (!sanitizedInt.HasValue || sanitizedInt < min || sanitizedInt > max)
                {
                    OutputManager.PrintItemIsNotValidIntInRangeMessage(part, min, max);
                    output.Clear();
                    break;
                }

                output.Add(sanitizedInt.Value);
            }

            if (output.Count == listLength) { return output; }
        }
    }
}