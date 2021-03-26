
using CoopSimulation.Data;
using CoopSimulation.Enums;
using System.Collections.Generic;

namespace CoopSimulation.Collection
{
    public interface ICoop
    {
        Poultry AddPoultry(PoultryEnum poultryEnum, GenderEnum genderEnum);

        int GetPercentageofBorn();

        void SetPercentageofBorn(int percentageofBorn);

        int GetNumberofNewborn();

        bool IsDeath(int age);
    }
}
