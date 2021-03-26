
using CoopSimulation.Enums;

namespace CoopSimulation.Data
{
    public class Poultry
    {
        public int Age { get; set; }
        public bool isPregnant { get; set; }
        public bool isPostPartumPeriod { get; set; }
        public GenderEnum GenderEnum { get; set; }
        public PoultryEnum PoultryEnum { get; set; }
        public int AverageLifeTime { get; set; }
        public int TimeofPregnancy { get; set; }
        public int LoseofFertility { get; set; }
        public int PercentageofBorn { get; set; }     

    }
}
