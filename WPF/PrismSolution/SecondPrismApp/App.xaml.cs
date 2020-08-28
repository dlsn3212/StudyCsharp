using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using SecondPrismApp.Views;
using System.Windows;

namespace SecondPrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<LeftModule.ModduleLoader>();
            moduleCatalog.AddModule<RightModule.RightModuleLoader>();
        }

    }
}
