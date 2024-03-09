using HW01_2024.Classes;

namespace HW01_2024.Interfaces;

public interface IGameState
{
    public void Handle(Game context);
}