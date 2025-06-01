using SimulatorSampleApp.Model.Calculation;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulatorSampleApp.Engine.IO
{
    /// <summary>
    /// 計算データの永続化サービス
    /// </summary>
    public class CalculationDataPersistenceService : IPersistenceService<CalculationData>
    {
        /// <summary>
        /// データを指定されたファイルパスに保存します。
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SaveDataAsync(string filePath, CalculationData data, CancellationToken token)
        {
            string fileExtension = Path.GetExtension(filePath)?.ToLowerInvariant();

            if (fileExtension == ".json")
            {
                throw new NotImplementedException("JSON serialization is not implemented yet.");
            }
            else
            {
                // XML シリアライズ
                await Task.Run(() =>
                {
                    var serializer = new XmlSerializer(typeof(CalculationData));
                    using (var writer = new StreamWriter(filePath))
                    {
                        serializer.Serialize(writer, data);
                    }
                }, token).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 指定されたファイルパスからデータを非同期で読み込みます。
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CalculationData> LoadDataAsync(string filePath, CancellationToken token)
        {
            string fileExtension = Path.GetExtension(filePath)?.ToLowerInvariant();
            CalculationData loadedData = null;

            if (fileExtension == ".json")
            {
                throw new NotImplementedException("JSON serialization is not implemented yet.");
            }
            else
            {
                await Task.Run(() =>
                {
                    var serializer = new XmlSerializer(typeof(CalculationData));
                    using (var reader = new StreamReader(filePath))
                    {
                        loadedData = (CalculationData)serializer.Deserialize(reader);
                    }
                }, token).ConfigureAwait(false);
            }
            return loadedData;
        }
    }
}
