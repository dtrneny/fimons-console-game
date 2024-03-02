using HW01_2024.Classes;

namespace HW01_2024.Interfaces;

public interface IInteractionManager
{
    public void PrintActions();
    public void PrintFImonIdleStats(FImon fimon);
    public void PrintFImonBattleStats(FImon fimon);
}