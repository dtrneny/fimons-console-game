using HW01_2024.Classes;
using HW01_2024.Enums;

namespace GameTests;

public class FImonBattleTests
{

    private FImon _strongFImon = new("Charizard", 10, 30, 35, FImonOrigin.Fire);
    private FImon _weakFImon = new("Magikarp", 3, 15, 40, FImonOrigin.Water);
    private readonly Battle _battle = new();
    
    [TearDown]
    public void TearDown()
    {
        _strongFImon.RecoverHealth();
        _weakFImon.RecoverHealth();
    }
    
    [Test]
    public void TestStrongerFImonWins()
    {
        var winningFImon = _battle.PerformBattleBetweenFImons(_strongFImon, _weakFImon);
        Assert.That(_strongFImon, Is.EqualTo(winningFImon));
    }
    
    [Test]
    public void TestWeakerFImonLost()
    {
        var winningFImon = _battle.PerformBattleBetweenFImons(_strongFImon, _weakFImon);
        Assert.That(_weakFImon, Is.Not.EqualTo(winningFImon));
    }
    
    [Test]
    public void TestFImonDamageDealing()
    {
        var strongerStartingHealth = _strongFImon.Health;
        var weakerStartingHealth = _weakFImon.Health;
        
        _battle.PerformBattleBetweenFImons(_strongFImon, _weakFImon);
        
        Assert.That(_strongFImon.Health, Is.LessThan(strongerStartingHealth));
        Assert.That(_weakFImon.Health, Is.LessThan(weakerStartingHealth));
    }
    
    [Test]
    public void TestFImonRecovery()
    {
        var strongerStartingHealth = _strongFImon.Health;
        _strongFImon.Health -= 5;
        
        _strongFImon.RecoverHealth();
        
        Assert.That(_strongFImon.Health, Is.EqualTo(strongerStartingHealth));
    }
}