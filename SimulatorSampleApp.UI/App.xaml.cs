using Microsoft.Extensions.DependencyInjection;
using SimulatorSampleApp.Engine.IO;
using SimulatorSampleApp.Model.Calculation;
using SimulatorSampleApp.MVVM.Services;
using SimulatorSampleApp.UI.Interface;
using SimulatorSampleApp.UI.Services;
using SimulatorSampleApp.UI.ViewModels;
using System;
using System.Windows;

namespace SimulatorSampleApp.UI
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFileNameService, DialogService>();
            serviceCollection.AddSingleton<IMessageBoxService, DialogService>();
            serviceCollection.AddSingleton<IPersistenceService<CalculationData>, CalculationDataPersistenceService>();

            serviceCollection.AddTransient<MainViewModel>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetService<MainViewModel>()
            };
            mainWindow.Show();
        }
    }
}
