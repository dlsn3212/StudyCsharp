﻿using Caliburn.Micro;
using MqttIoTMonitoringApp.ViewModels;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using MqttIoTMonitoringApp.Helpers;

namespace MqttIoTMonitoringApp
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.RegisterInstance(typeof(IDialogService), null, new DialogService(dialogTypeLocator: new DialogTypeLocator()));
            container.PerRequest<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }


    }
}
