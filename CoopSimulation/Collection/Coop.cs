

using CoopSimulation.Data;
using CoopSimulation.Enums;
using System.Collections.Generic;

namespace CoopSimulation.Collection
{
    public class Coop : ICoop
    {
        private int percentageofBorn;
        private int numberofNewborn;
        public List<Poultry> PoultryList = new List<Poultry>();
        public Coop()
        {
            percentageofBorn = Statistics.percentageofBorn;
        }
        public void AddPoultry(PoultryEnum poultryEnum, GenderEnum genderEnum)
        {
            PoultryList.Add(new Poultry()
            {
                Age = 0,
                PoultryEnum = poultryEnum,
                GenderEnum = genderEnum,
                isPregnant = false,
                isPostPartumPeriod = false,
                AverageLifeTime = Statistics.averageLifeTime,
                LoseofFertility = Statistics.loseofFertility,
                PercentageofBorn = Statistics.percentageofBorn,
                TimeofPregnancy = Statistics.timeofPregnancy,
            });
        }

        public int GetPercentageofBorn()
        {
            return percentageofBorn;
        }

        public void SetPercentageofBorn(int percentageofRabbitsBorn)
        {
            this.percentageofBorn = percentageofRabbitsBorn;
        }

        public int GetNumberofNewborn()
        {
            numberofNewborn = Statistics.RandomIntValue();
            return numberofNewborn;
        }       
    }
}
