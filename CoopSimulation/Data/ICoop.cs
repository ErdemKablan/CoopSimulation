
using CoopSimulation.Enums;

namespace CoopSimulation.Data
{
    public interface ICoop
    {
        void AddPoultry(PoultryEnum poultryEnum, GenderEnum genderEnum);

        int GetPercentageofBorn();

        void SetPercentageofBorn(int percentageofBorn);

        int GetNumberofNewborn();

    }
}
