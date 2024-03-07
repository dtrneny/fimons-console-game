using System.Collections.Generic;
using HW01_2024.Classes;

namespace HW01_2024.Interfaces;

public interface IFImonsRepository
{
    public List<FImon> GetStarterFImons();
}