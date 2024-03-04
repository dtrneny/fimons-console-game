using HW01_2024.Interfaces;
using HW01_2024.ConsoleManagement;

namespace HW01_2024.Classes;

public class Battle: IBattle
{
    public ITournamentContestant PerformBattleBetweenContestants(Player player, Rival enemy)
    {
        var roundCounter = 1;
        while (player.FImons.Exists(fimon => fimon.Health > 0) && enemy.FImons.Exists(fimon => fimon.Health > 0))
        {
            // TODO: overit find
            var playerFImon = player.FImons.Find(fimon => fimon.Health > 0);
            var enemyFImon = enemy.FImons.Find(fimon => fimon.Health > 0);

            if (playerFImon == null || enemyFImon == null) continue;
            
            OutputManager.PrintBattleAnnouncementMessage(playerFImon, enemyFImon, roundCounter);
            var victoriousFImon = PerformBattleBetweenFImons(playerFImon, enemyFImon);
            
            if (victoriousFImon == playerFImon)
            {
                OutputManager.PrintFImonDefeatMessage(enemyFImon, false);
            }
            else
            {
                OutputManager.PrintFImonDefeatMessage(playerFImon, true);
            }
            
            InputManager.GetPlayersActivitySign();
            roundCounter++;
        }

        return player.FImons.Exists(fimon => fimon.Health > 0)
            ? player
            : enemy;
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

        OutputManager.PrintFImonAttackMessage(attackingFImon, targetedFImon, damage, playerAttacking);
    }
}