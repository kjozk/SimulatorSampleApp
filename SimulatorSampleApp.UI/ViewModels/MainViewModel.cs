using SimulatorSampleApp.Engine.Calculation;
using SimulatorSampleApp.Engine.IO;
using SimulatorSampleApp.Model.Calculation;
using SimulatorSampleApp.Model.Common;
using SimulatorSampleApp.MVVM;
using SimulatorSampleApp.MVVM.Services;
using SimulatorSampleApp.UI.Interface;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// 保存するファイル名を取得するためのサービス
        /// </summary>
        private readonly IFileNameService _fileNameService;

        /// <summary>
        /// メッセージボックスを表示するためのサービス
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// 計算データを永続化するためのサービス
        /// </summary>
        private readonly IPersistenceService<CalculationData> _persistenceService;

        #endregion

        #region Properties

        /// <summary>
        /// 形状の選択肢を提供するコレクション
        /// </summary>
        public ObservableCollection<string> ShapeTypes { get; } = new ObservableCollection<string>() { "Plane", "Sphere" };

        private string _selectedShape;

        /// <summary>
        /// 現在選択されている形状
        /// </summary>
        public string SelectedShape
        {
            get => _selectedShape;
            set
            {
                if (SetProperty(ref _selectedShape, value))
                {
                    UpdateConditionViewModel();
                }
            }
        }

        private ConditionViewModelWrapper _conditionViewModel;

        /// <summary>
        /// 計算条件のビューモデル
        /// </summary>
        public ConditionViewModelWrapper ConditionViewModel
        {
            get => _conditionViewModel;
            set => SetProperty(ref _conditionViewModel, value);
        }

        /// <summary>
        /// 計算結果のコレクション
        /// </summary>
        public ObservableCollection<CalculationResultItem> Results { get; } = new ObservableCollection<CalculationResultItem>();

        #endregion

        #region Commands

        /// <summary>
        /// 計算を実行するコマンド
        /// </summary>
        public ICommand CalculateCommand { get; }

        /// <summary>
        /// 保存を行うコマンド
        /// </summary>
        public ICommand SaveAsCommand { get; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileService"></param>
        /// <param name="persistenceService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MainViewModel(IFileNameService fileNameService, IMessageBoxService messageBoxService, IPersistenceService<CalculationData> persistenceService)
        {
            _fileNameService = fileNameService ?? throw new ArgumentNullException(nameof(fileNameService));
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            _persistenceService = persistenceService ?? throw new ArgumentNullException(nameof(persistenceService));

            SelectedShape = "Plane"; // 初期選択
            CalculateCommand = new DelegateCommand(Calculate);
            SaveAsCommand = new AsyncCommand(SaveAsAsync);
            UpdateConditionViewModel();
        }

        private void UpdateConditionViewModel()
        {
            switch (SelectedShape)
            {
                case "Plane":
                    ConditionViewModel = new PlaneConditionViewModel(
                        new PlaneCalculationCondition()
                        {
                            Shape = new PlaneCalculationShape()
                            {
                                CountX = 10,
                                CountY = 10,
                                Width = 100,
                                Depth = 100,
                                Origin = new Point3D(0, 0)
                            }
                        }
                    );
                    break;
                case "Sphere":
                    ConditionViewModel = new SphereConditionViewModel(new SphereCalculationCondition());
                    break;
            }
        }

        private void Calculate()
        {
            Results.Clear();

            try
            {
                var calculation = CalculationFactory.Create(ConditionViewModel.Model);

                calculation.Execute(CancellationToken.None);

                foreach (var item in calculation.Results)
                {
                    Results.Add(item);
                }
            }
            catch (OperationCanceledException)
            {
                // キャンセルされた場合の処理（必要に応じて）
                Debug.WriteLine("計算がキャンセルされました。");
            }
            catch (Exception ex)
            {
                // エラーハンドリング（ログ出力やユーザー通知など）
                Debug.WriteLine($"Error during calculation: {ex.Message}");
            }
        }

        private async Task SaveAsAsync(CancellationToken token)
        {
            try
            {
                if (!_fileNameService.TryGetSaveFileName(
                    "XMLファイル (*.xml)|*.xml|JSONファイル (*.json)|*.json|全てのファイル (*.*)|*.*",
                    ".xml",
                    "calculationData.xml", 
                    out string filePath))
                {
                    Debug.WriteLine("ファイル保存がキャンセルされました。");
                    return; // ユーザーがキャンセルした場合
                }

                var data = new CalculationData
                {
                    Condition = ConditionViewModel.Model,
                    Results = Results.ToList()
                };

                await _persistenceService.SaveDataAsync(filePath, data, token);

                _messageBoxService.ShowMessage($"{filePath} にデータが保存されました。", "保存");

                Console.WriteLine($"{filePath} にデータがシリアル化されました。");
            }
            catch (Exception ex)
            {
                // エラーハンドリング（ログ出力やユーザー通知など）
                Debug.WriteLine($"Error during save: {ex.Message}");
            }
        }
    }
}