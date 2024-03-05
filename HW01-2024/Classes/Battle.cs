using System;
using HW01_2024.Interfaces;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class Battle(OutputManager outputManager, InputManager inputManager): IBattle
{
    public ITournamentContestant PerformBattleBetweenContestants(Player player, Rival enemy)
    {
        var roundCounter = 1;
        while (player.FImons.Exists(fimon => fimon.Health > 0) && enemy.FImons.Exists(fimon => fimon.Health > 0))
        {
            // TODO: overit find a exists
            var playerFImon = player.FImons.Find(fimon => fimon.Health > 0);
            var enemyFImon = enemy.FImons.Find(fimon => fimon.Health > 0);

            if (playerFImon == null || enemyFImon == null) continue;
            
            outputManager.PrintBattleAnnouncementMessage(playerFImon, enemyFImon, roundCounter);
            var victoriousFImon = PerformBattleBetweenFImons(playerFImon, enemyFImon);
            
            if (victoriousFImon == playerFImon)
            {
                outputManager.PrintFImonDefeatMessage(enemyFImon, false);
            }
            else
            {
                outputManager.PrintFImonDefeatMessage(playerFImon, true);
            }
            
            inputManager.GetPlayersActivitySign();
            roundCounter++;
        }

        var playerWon = player.FImons.Exists(fimon => fimon.Health > 0);
        
        CalculateAndAwardExperienceToPlayersFimons(roundCounter, player, playerWon);

        return playerWon ? player : enemy;
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

        return playerFImon.Health >= 0
            ? playerFImon
            : enemyFImon;
    }

    private void PerformAttack(FImon attackingFImon, FImon targetedFImon, bool playerAttacking)
    {
        if (attackingFImon.Health <= 0) { return; }
        
        var damage = attackingFImon.Characteristic.Origin == targetedFImon.Characteristic.WeaknessTo
            ? attackingFImon.AttackDamage * 2
            : attackingFImon.AttackDamage;
        
        attackingFImon.Attack(targetedFImon, damage);

        outputManager.PrintFImonAttackMessage(attackingFImon, targetedFImon, damage, playerAttacking);
    }

    private void CalculateAndAwardExperienceToPlayersFimons(int roundsCount, Player player, bool playerWon)
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
            outputManager.PrintFImonLevelUpMessage(fimon.Name, fimon.Level + 1);
        }
        fimon.Experience = experiences;
    }
}