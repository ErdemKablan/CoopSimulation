

using CoopSimulation.Data;
using CoopSimulation.Enums;
using System.Collections.Generic;

namespace CoopSimulation.Collection
{
    public class Rabbit : Coop
    {
        public bool IsDeath(int age)
        {
            int deathAge = Statistics.RandomIntValue();

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
    }
}
