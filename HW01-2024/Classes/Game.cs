using System;
using System.Collections.Generic;
using HW01_2024.Enums;
using HW01_2024.Interfaces;
using HW01_2024.ConsoleManagement;
using HW01_2024.Services;

namespace HW01_2024.Classes;

public class Game : IGame
{
    public bool GameEnded { get; set; }
    public IGameState State { get; set; } = new StartingState();
    public Player Player { get; } = new();
    public readonly InputManager InputManager = InputManager.GetInstance();
    public readonly OutputManager OutputManager = OutputManager.GetInstance();
    public OpponentService OpponentService = new();
    public FImonService FImonService = new();
    public readonly ActionController ActionController;

    public Game()
    {
        ActionController = new ActionController(this);
    }
    
    public void Start()
    {
        while (!GameEnded)
        {
           State.Handle(this);
        }
    }
}