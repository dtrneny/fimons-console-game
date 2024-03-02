using System;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public GameState State { get; set; } = GameState.Start;
    private IInteractionManager InteractionManager { get; } = new InteractionManager();
    public void Start()
    {
        InteractionManager.PrintActions();
    }
}