using System.Collections.Generic;
using HW01_2024.Enums;

namespace HW01_2024.Interfaces;

public interface IOutputManager
{
    public void PrintEmptyLine();
    public void PrintSeparatedIntListLengthExceededMessage(int listLength);
    public void PrintItemIsNotValidIntInRangeMessage(string part, int min, int max);
    public void PrintActivitySignMessage();
    public void PrintNotValidAction();

    public void PrintNotDistinctValue(int value);

}