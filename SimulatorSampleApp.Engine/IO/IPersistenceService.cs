using System.Threading;
using System.Threading.Tasks;

namespace SimulatorSampleApp.Engine.IO
{
    public interface IPersistenceService<T>
    {
        // データを指定されたパスに保存
        Task SaveDataAsync(string filePath, T data, CancellationToken token);

        // 指定されたパスからデータを読み込む
        Task<T> LoadDataAsync(string filePath, CancellationToken token);
    }
}
