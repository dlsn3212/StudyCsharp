using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pie 미완성
namespace MvvmChartApp.ViewModels
{
    public class PieChartViewModel : Conductor<object>
    {
        double pieValues;
        public double PieValue
        {
            get => pieValues;
            set
            {
                pieValues = value;
                NotifyOfPropertyChange(() => PieValue);
            }
        }
    }
}
