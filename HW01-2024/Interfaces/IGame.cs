using HW01_2024.Enums;

namespace HW01_2024.Interfaces
{
    public interface IGame
    {
        GameState State { get; set; }
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start();
    }
}
