using Caliburn.Micro;
using MvvmArduino.ViewModels;
using System.Windows;

namespace MvvmArduino
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
