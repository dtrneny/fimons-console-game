using System.Collections.Generic;
using HW01_2024.Classes;
using HW01_2024.Enums;
using HW01_2024.Interfaces;

namespace HW01_2024.Services;

public class FImonService: IFImonsRepository
{
    private List<FImon> _starterFImons = [
        new FImon("Typhlosion", 7, 21, 27, FImonOrigin.Fire),
        new FImon("Feraligatr", 7, 23, 25, FImonOrigin.Water),
        new FImon("Meganium", 7, 22, 26, FImonOrigin.Grass),
        new FImon("Entei", 7, 24, 23, FImonOrigin.Fire),
        new FImon("Suicune", 7, 25, 22, FImonOrigin.Water),
        new FImon("Celebi", 7, 23, 24, FImonOrigin.Grass)
    ];
    
    public List<FImon> GetStarterFImons()
    {
        return _starterFImons;
    }
}