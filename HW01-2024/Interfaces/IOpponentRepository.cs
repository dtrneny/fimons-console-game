using HW01_2024.Classes;

namespace HW01_2024.Interfaces;

public interface IOpponentRepository
{
    public Opponent? GetUpcomingOpponent();
    public void RemoveOpponentFromTournament(Opponent opponent);
    public bool CheckOpponentAvailability();
}