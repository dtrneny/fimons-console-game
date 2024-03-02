using System;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Battle: IBattle
{
    public ITournamentContestant PerformBattleBetweenContestants(Player player, Rival enemy)
    {
        while (player.FImons.Exists(fimon => fimon.Health > 0) && enemy.FImons.Exists(fimon => fimon.Health > 0))
        {
            var playerFImon = player.FImons.Find(fimon => fimon.Health > 0);
            var enemyFImon = enemy.FImons.Find(fimon => fimon.Health > 0);

            if (playerFImon != null && enemyFImon != null)
            {
                PerformBattleBetweenFImons(playerFImon, enemyFImon);
            }
        }

        return player;
    }

    public FImon PerformBattleBetweenFImons(FImon playerFImon, FImon enemyFImon)
    {
        while (playerFImon.Health > 0 && enemyFImon.Health > 0)
        {
            if (playerFImon.Speed >= enemyFImon.Speed)
            {
                playerFImon.Attack(enemyFImon);
                enemyFImon.Attack(playerFImon);
                Console.WriteLine($"Player {playerFImon.Name} {playerFImon.Health} : Enemy {enemyFImon.Name} {enemyFImon.Health}");
            }
            else
            {
                enemyFImon.Attack(playerFImon);
                playerFImon.Attack(enemyFImon);
                Console.WriteLine($"Player {playerFImon.Name} {playerFImon.Health} : Enemy {enemyFImon.Name} {enemyFImon.Health}");
            }   
        }

        return playerFImon.Health >= 0
            ? playerFImon
            : enemyFImon;
    }
}