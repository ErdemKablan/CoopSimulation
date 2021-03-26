using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace CoopSimulation.Data
{
    public class Statistics
    {
        public static int months;
        public static int defaultMonths = 15;
        public static int averageLifeTime;
        public static int timeofPregnancy;
        public static int loseofFertility;
        public static int percentageofBorn;
        public static int addLife;
        public static int lowRisk;
        public static int highLife;
        private static Statistics singleton = new Statistics();
        public static Statistics getInstance()
        {
            return singleton;
        }
        private Statistics() { getStaticInformations(); }

        public void getStaticInformations()
        {
            months = LifeCycleMonth();
            averageLifeTime = 15;
            timeofPregnancy = 1;
            loseofFertility = 6;
            percentageofBorn = 25;
            addLife = 1;
            lowRisk = 8;
            highLife = 4;
        }
        public static int RandomIntValue()
        {
            Random random = new Random();
            return random.Next(2, 10);
        }

        private int LifeCycleMonth()
        {
            if (File.Exists(Application.StartupPath + @"\LifeCycleMonth.json"))
            {
                using (StreamReader _StreamReader = new StreamReader(Application.StartupPath + @"\LifeCycleMonth.json"))
                {
                    string jsonData = _StreamReader.ReadToEnd();
                    LifeCycleMonths jsonConvert = JsonConvert.DeserializeObject<LifeCycleMonths>(jsonData);

                    if (jsonConvert.LifeCycleMonth != 0)
                        return jsonConvert.LifeCycleMonth;
                    else
                        return defaultMonths;
                }
            }
            else
                return defaultMonths;
        }
    }
}
