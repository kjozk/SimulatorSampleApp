using SimulatorSampleApp.MVVM.Services;
using SimulatorSampleApp.UI.Interface;
using System.Windows;

namespace SimulatorSampleApp.UI.Services
{
    public class DialogService : IFileNameService, IMessageBoxService
    {
        public bool TryGetOpenFileName(string filter, string defaultExt, out string filePath)
        {
            var openDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt
            };
            var result = openDialog.ShowDialog();

            if (result == true)
            {
                filePath = openDialog.FileName; // 成功したらファイル名をセット
                return true;
            }
            else
            {
                filePath = null; // 失敗したら null をセット
                return false;
            }
        }

        public bool TryGetSaveFileName(string filter, string defaultExt, string defaultFileName, out string filePath)
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt,
                FileName = defaultFileName
            };
            var result = saveDialog.ShowDialog();

            if (result == true)
            {
                filePath = saveDialog.FileName; // 成功したらファイル名をセット
                return true;
            }
            else
            {
                filePath = null; // 失敗したら null をセット
                return false;
            }
        }

        // IMessageBoxService の実装
        public void ShowInfoMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowConfirmation(string message, string title)
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question);
            return result == MessageBoxResult.OK;
        }
    }
}
