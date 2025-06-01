using SimulatorSampleApp.UI.Interface;

namespace SimulatorSampleApp.UI.Services
{
    public class WpfFileNameService : IFileNameService
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
    }
}
