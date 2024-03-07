using HW01_2024.Classes;

namespace HW01_2024.Interfaces
{
    public interface IBattle
    {
        /// <summary>
        /// Performs a battle between two trainers.
        /// </summary>
        /// <param name="player">Player trainer</param>
        /// <param name="enemy">Enemy trainer</param>
        /// <returns>Winner trainer</returns>
        public ITrainer PerformBattleBetweenContestants(Player player, Opponent enemy);

        /// <summary>
        /// Performs one round of a battle between two FImons.
        /// </summary>
        /// <param name="playerFImon">Player trainer's FImon</param>
        /// <param name="enemyFImon">Enemy trainer's FImon</param>
        /// <returns>Winner FImon</returns>
        public FImon PerformBattleBetweenFImons(FImon playerFImon, FImon enemyFImon);

    }
}
