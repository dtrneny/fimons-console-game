using HW01_2024.Classes;
using HW01_2024.Enums;

namespace GameTests;

public class PlayerBattleTests
{
    private readonly Battle _battle = new();
    private readonly Player _player = new([
        new FImon("Typhlosion", 7, 21, 27, FImonOrigin.Fire),
        new FImon("Feraligatr", 7, 23, 25, FImonOrigin.Water),
        new FImon("Meganium", 7, 22, 26, FImonOrigin.Grass),
    ]);
    
    private readonly Opponent _strongEnemy = new([
        new FImon("Raichu", 11, 18, 30, FImonOrigin.Fire),
        new FImon("Ninetales", 12, 18, 30, FImonOrigin.Fire),
        new FImon("Squirtle", 8, 19, 29, FImonOrigin.Water),
    ]);
    
    private readonly Opponent _weakEnemy = new([
        new FImon("Dragonite", 7, 23, 24, FImonOrigin.Fire),
        new FImon("Lapras", 7, 24, 23, FImonOrigin.Water),
    ]);

    [TearDown]
    public void TearDown()
    {
        _player.RecoverFImons();
        _strongEnemy.RecoverFImons();
        _weakEnemy.RecoverFImons();
    }

    [Test]
    public void TestPlayerWon()
    {
        var winningContestant = _battle.PerformBattleBetweenContestants(_player, _weakEnemy);
        Console.WriteLine(winningContestant.GetType());
        Assert.That(_player, Is.EqualTo(winningContestant));
    }
    
    [Test]
    public void TestPlayerLost()
    {
        var winningContestant = _battle.PerformBattleBetweenContestants(_player, _strongEnemy);
        Assert.That(_strongEnemy, Is.EqualTo(winningContestant));
    }
}