using System;
using HW01_2024.Enums;

namespace HW01_2024.Classes;

public class FImonCharacteristic(FImonOrigin origin)
{
    public FImonOrigin Origin { get; } = origin;
    public FImonOrigin WeaknessTo { get; } = origin switch
    {
        FImonOrigin.Water => FImonOrigin.Grass,
        FImonOrigin.Fire => FImonOrigin.Water,
        FImonOrigin.Grass => FImonOrigin.Fire,
        _ => throw new ArgumentOutOfRangeException(nameof(origin), origin, null)
    };
}