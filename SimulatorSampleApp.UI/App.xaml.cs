using SimulatorSampleApp.UI.Services;
using SimulatorSampleApp.UI.ViewModels;
using SimulatorSampleApp.Engine.IO;
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

            var fileService = new WpfFileNameService();

            var calculationDataPersistenceService = new CalculationDataPersistenceService();

            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel(fileService, calculationDataPersistenceService)
            };
            mainWindow.Show();
        }
    }
}
