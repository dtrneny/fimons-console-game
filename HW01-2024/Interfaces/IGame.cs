using HW01_2024.Classes;
using HW01_2024.Enums;

namespace HW01_2024.Interfaces
{
    public interface IGame
    {
        GameState State { get; set; }
        Player Player { get; }
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start();

        public void StartGameLoop();
    }
}
