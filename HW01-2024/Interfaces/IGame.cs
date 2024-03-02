using HW01_2024.Classes;
using HW01_2024.Enums;

namespace HW01_2024.Interfaces
{
    public interface IGame
    {
        GamePhase Phase { get; set; }
        Player Player { get; }
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start();
    }
}
