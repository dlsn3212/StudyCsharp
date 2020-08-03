using Caliburn.Micro;
using MvvmChartApp.ViewModels;
using System.Windows;

namespace MvvmChartApp
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();            //화면을 띄우기위한
        }
    }
}
