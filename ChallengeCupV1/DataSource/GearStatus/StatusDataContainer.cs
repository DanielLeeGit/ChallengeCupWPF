﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCupV1.DataSource.GearStatus
{
    public class StatusDataContainer
    {
        public List<StatusDataTemplate> StatusData = new List<StatusDataTemplate>()
        {
            new StatusDataTemplate("Stress", StatusCalculator.StressCalculator, "N"),
            new StatusDataTemplate("Strain", StatusCalculator.StressCalculator, "N"),
            new StatusDataTemplate("Temperature", StatusCalculator.TemperatureCalculator, "N"),
            new StatusDataTemplate("Frequency", StatusCalculator.FrequencyCalculator, "N")
        };

        public void Calculate()
        {
            StatusData[0].Calculate(new List<double>() { });
            StatusData[1].Calculate(new List<double>() { });
            StatusData[2].Calculate(new List<double>() { });
            StatusData[3].Calculate(new List<double>() { });
        }
    }
}
