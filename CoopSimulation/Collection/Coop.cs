

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

        public bool IsDeath(PoultryEnum poultryEnum, int age)
        {
            int deathAge = Statistics.RandomIntValue();

            if (poultryEnum == PoultryEnum.Rabbit)
            {
                if (age < 6)
                    return false;
                else if (age >= 6 && age <= 12)
                {
                    if (deathAge <= 8)
                        return false;
                    else
                        return true;
                }
                else if (age > 12 && age < Statistics.averageLifeTime)
                {
                    if (deathAge >= 4)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            return false;
        }
    }
}
