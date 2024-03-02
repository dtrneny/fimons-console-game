using System.Collections.Generic;
using HW01_2024.Classes;

namespace HW01_2024.Interfaces;

public interface IInteractionManager
{
    public void PrintActions();
    public void PrintFImonIdleStats(FImon fimon);
    public void PrintFImonBattleStats(FImon fimon);
    public int GetPlayersIntInput(int min, int max);

    public IEnumerable<int> GetPlayersIntListInput(int min, int max, int length);
}