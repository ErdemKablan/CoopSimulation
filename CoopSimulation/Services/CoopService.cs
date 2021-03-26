using CoopSimulation.Collection;
using CoopSimulation.Data;
using CoopSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CoopSimulation.Services
{
    public class CoopService
    {
        public void CreateCoopSimulation()
        {
            try
            {
                Statistics.getInstance();

                int months = Statistics.months;
                if (months <= 0)
                {
                    MessageBox.Show("There are 1 female and 1 male newborn rabbits in the coop", "Info");
                }
                else
                {
                    Coop coop = new Coop();
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

                            LifeCyclePoultry(months, coop, month);

                            month += Statistics.addLife;
                        }
                    }

                    Show(months, coop);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LifeCyclePoultry(int months, Coop coop, int month)
        {
            foreach (Poultry poultry in coop.PoultryList.ToList())
            {
                if (coop.IsDeath(poultry.Age))
                {
                    coop.PoultryList.Remove(poultry);
                }

                poultry.Age += Statistics.addLife;
            }
        }
        private static void Show(int months, Coop coop)
        {
            #region RabbitsShow

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= months; i++)
            {
                int numberFemale = 0;
                int numberMale = 0;

                foreach (Poultry poultry in coop.PoultryList)
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

            int FemaleRabbitCount = coop.PoultryList.Where(x => x.GenderEnum == GenderEnum.Female && x.PoultryEnum == PoultryEnum.Rabbit).ToList().Count();
            int MaleRabbitCount = coop.PoultryList.Where(x => x.GenderEnum == GenderEnum.Male && x.PoultryEnum == PoultryEnum.Rabbit).ToList().Count();
            sb.AppendLine(string.Format("Total :" + FemaleRabbitCount + " female " + MaleRabbitCount + " male rabbits"));

            MessageBox.Show(sb.ToString(), "Result");
            #endregion


        }
    }
}
