using System;
using System.Linq;
using HW01_2024.ConsoleManagement;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Battle: IBattle
{
    private readonly OutputManager _outputManager = OutputManager.GetInstance();
    
    public ITrainer PerformBattleBetweenContestants(Player player, Opponent enemy)
    {
        var roundCounter = 1;

        while (BothContestantsHaveActiveFImons(player, enemy))
        {
            var playerFImon = GetNextActiveFImon(player);
            var enemyFImon = GetNextActiveFImon(enemy);
            
            if (playerFImon == null || enemyFImon == null) { continue; }

            _outputManager.PrintBattleAnnouncementMessage(playerFImon, enemyFImon, roundCounter);
            var playersFImonWon = PerformBattleBetweenFImons(playerFImon, enemyFImon) == playerFImon;

            if (playersFImonWon)
            {
                _outputManager.PrintFImonDefeatMessage(enemyFImon, false);
            }
            else
            {
                _outputManager.PrintFImonDefeatMessage(playerFImon, true);
            }
            
            roundCounter++;
        }

        var playerWonOverall = player.FImons.Any(fimon => fimon.Health > 0);

        CalculateAndAwardExperienceToPlayersFImons(roundCounter, player, playerWonOverall);

        return playerWonOverall ? player : enemy;
    }
    
    private bool BothContestantsHaveActiveFImons(Player player, Opponent enemy)
    {
        return player.FImons.Any(fimon => fimon.Health > 0) && enemy.FImons.Any(fimon => fimon.Health > 0);
    }
    
    private FImon? GetNextActiveFImon(ITrainer trainer)
    {
        return trainer.FImons.FirstOrDefault(fimon => fimon.Health > 0);
    }

    public FImon PerformBattleBetweenFImons(FImon playerFImon, FImon enemyFImon)
    {
        while (playerFImon.Health > 0 && enemyFImon.Health > 0)
        {
            if (playerFImon.Speed >= enemyFImon.Speed)
            {
                PerformAttack(playerFImon, enemyFImon, true);
                PerformAttack(enemyFImon, playerFImon, false);
            }
            else
            {
                PerformAttack(enemyFImon, playerFImon, false);
                PerformAttack(playerFImon, enemyFImon, true);
            }   
        }

        return playerFImon.Health > 0
            ? playerFImon
            : enemyFImon;
    }

    private void PerformAttack(FImon attackingFImon, FImon targetedFImon, bool playerAttacking)
    {
        if (attackingFImon.Health <= 0) { return; }
        
        var finalDamage = attackingFImon.Attack(targetedFImon);

        _outputManager.PrintFImonAttackMessage(attackingFImon, targetedFImon, finalDamage, playerAttacking);
    }

    private void CalculateAndAwardExperienceToPlayersFImons(int roundsCount, Player player, bool playerWon)
    {
        var random = new Random();
        var baseExperiences = 5 * roundsCount;
        
        foreach (var fimon in player.FImons)
        {
            var randomizedExperiences = playerWon
                ? random.Next(45, 65)
                : random.Next(15, 45);
            
            AwardExperienceToFImon(randomizedExperiences + baseExperiences, fimon);
        }
    }

    private void AwardExperienceToFImon(int experiences, FImon fimon)
    {
        if (fimon.WillLevelUp(experiences))
        {
            _outputManager.PrintFImonLevelUpMessage(fimon.Name, fimon.Level + 1);
        }
        fimon.Experience = experiences;
    }
}