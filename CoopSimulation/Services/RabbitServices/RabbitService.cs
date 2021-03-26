using CoopSimulation.Collection;
using CoopSimulation.Data;
using CoopSimulation.Enums;
using System.Linq;
using System.Text;
using System.Windows;

namespace CoopSimulation.Services.RabbitServices
{
    class RabbitService : ICoopService
    {
        public void StartCoop()
        {
            getInstance();
            LifeCyclePoultry(new Coop(), Statistics.months);
        }
        public void getInstance()
        {
            Statistics.getInstance();
        }

        public void LifeCyclePoultry(Coop coop, int months)
        {
            if (months <= 0)
            {
                MessageBox.Show("There are 1 female and 1 male newborn rabbits in the coop", "Info");
            }
            else
            {
                coop.AddPoultry(PoultryEnum.Rabbit, GenderEnum.Female);
                coop.AddPoultry(PoultryEnum.Rabbit, GenderEnum.Male);

                for (int month = 0; month <= months;)
                {
                    if (coop.PoultryList.ToList().Count() > 0)
                    {
                        int newBornFemale = 0;
                        int newBornMale = 0;
                        foreach (Poultry femalePoultry in coop.PoultryList.Where(x => x.GenderEnum == GenderEnum.Female).ToList())
                        {
                            if (femalePoultry.GenderEnum == GenderEnum.Female && femalePoultry.LoseofFertility > femalePoultry.Age && femalePoultry.Age > 0)
                            {
                                if (femalePoultry.isPregnant)
                                {
                                    newBornFemale += coop.GetNumberofNewborn() * coop.GetPercentageofBorn() / 100;
                                    newBornMale += coop.GetNumberofNewborn() * (100 - coop.GetPercentageofBorn()) / 100;
                                    femalePoultry.isPregnant = false;
                                    femalePoultry.isPostPartumPeriod = true;
                                }
                                else if (femalePoultry.Age > 0 && femalePoultry.isPostPartumPeriod)
                                    femalePoultry.isPostPartumPeriod = false;
                                else
                                    femalePoultry.isPregnant = true;
                            }
                        }

                        for (int i = 0; i < newBornFemale; i++)
                        {
                            coop.AddPoultry(PoultryEnum.Rabbit, GenderEnum.Female);
                        }

                        for (int i = 0; i < newBornMale; i++)
                        {
                            coop.AddPoultry(PoultryEnum.Rabbit, GenderEnum.Male);
                        }

                        AddLifeCycle(coop);

                        month += Statistics.addLife;
                    }
                }
            }
            Show(months, coop);
        }
        public void AddLifeCycle(Coop coop)
        {
            foreach (Poultry poultry in coop.PoultryList.ToList())
            {
                if (IsDeath(poultry.Age))
                {
                    coop.PoultryList.Remove(poultry);
                }

                poultry.Age += Statistics.addLife;
            }
        }

        public void Show(int _months, Coop _coop)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= _months; i++)
            {
                int numberFemale = 0;
                int numberMale = 0;

                foreach (Poultry poultry in _coop.PoultryList)
                {
                    if (poultry.PoultryEnum == PoultryEnum.Rabbit)
                    {
                        if (poultry.Age == i)
                        {
                            if (poultry.GenderEnum == GenderEnum.Female)
                                numberFemale++;
                            else
                                numberMale++;
                        }
                    }
                }

                if (numberFemale > 0 || numberMale > 0)
                    sb.AppendLine(string.Format(i + " month old " + numberFemale + " female " + numberMale + " male rabbits"));
            }
            sb.AppendLine("");

            int FemaleRabbitCount = _coop.PoultryList.Where(x => x.GenderEnum == GenderEnum.Female && x.PoultryEnum == PoultryEnum.Rabbit).ToList().Count();
            int MaleRabbitCount = _coop.PoultryList.Where(x => x.GenderEnum == GenderEnum.Male && x.PoultryEnum == PoultryEnum.Rabbit).ToList().Count();
            sb.AppendLine(string.Format("Total :" + FemaleRabbitCount + " female " + MaleRabbitCount + " male rabbits"));

            MessageBox.Show(sb.ToString(), "Result");
        }
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
