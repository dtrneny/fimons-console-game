using System.Collections.Generic;
using HW01_2024.Enums;

namespace HW01_2024.Interfaces;

public interface IOutputManager
{
    void PrintEmptyLine();
    void PrintSeparatedIntListLengthExceededMessage(int listLength);
    void PrintItemIsNotValidIntInRangeMessage(string part, int min, int max);
    void PrintActivitySignMessage();
    public void PrintNotValidAction();

}