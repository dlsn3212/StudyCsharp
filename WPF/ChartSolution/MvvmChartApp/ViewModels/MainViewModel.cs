using Caliburn.Micro;
using MvvmChartApp.Views;
using System;

namespace MvvmChartApp.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel());         //display<>~하는거랑 같음
        }

        public void LoadGaugeChart()
        {
            ActivateItem(new GaugeChartViewModel());
        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }

    }
}
