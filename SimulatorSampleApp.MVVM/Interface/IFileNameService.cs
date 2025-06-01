namespace SimulatorSampleApp.UI.Interface
{
    public interface IFileNameService
    {
        /// <summary>
        /// 開くファイルダイアログを表示し、選択されたファイルのパスを返します。
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="defaultExt"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool TryGetOpenFileName(string filter, string defaultExt, out string filePath);

        /// <summary>
        /// 名前を付けて保存するファイルダイアログを表示し、選択されたファイルのパスを返します。
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="defaultExt"></param>
        /// <param name="defaultFileName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool TryGetSaveFileName(string filter, string defaultExt, string defaultFileName, out string filePath);
    }
}
