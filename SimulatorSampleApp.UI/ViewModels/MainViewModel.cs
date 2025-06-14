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

        private readonly PlaneConditionViewModel _planeCondition = new PlaneConditionViewModel(
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

        private readonly SphereConditionViewModel _sphereCondition = new SphereConditionViewModel(new SphereCalculationCondition());

        #endregion

        private bool _isIdle;
        public bool IsIdle
        {
            get => _isIdle;
            private set => SetProperty(ref _isIdle, value);
        }

        public ICommand CancelCommand { get; }

        private void ExecuteCancel()
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel(); // キャンセルを要求
                IsIdle = true;
            }
        }

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
        public AsyncCommand SaveAsCommand { get; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileService"></param>
        /// <param name="persistenceService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MainViewModel(IFileNameService fileNameService, IMessageBoxService messageBoxService, IPersistenceService<CalculationData> persistenceService)
        {
            IsIdle = true; // 初期状態ではキャンセル可能

            _fileNameService = fileNameService ?? throw new ArgumentNullException(nameof(fileNameService));
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            _persistenceService = persistenceService ?? throw new ArgumentNullException(nameof(persistenceService));

            SelectedShape = "Plane"; // 初期選択
            CalculateCommand = new DelegateCommand(Calculate);
            SaveAsCommand = new AsyncCommand(SaveAsAsync);
            CancelCommand = new DelegateCommand(ExecuteCancel, () =>
            {
                // キャンセル可能な状態であるかどうかをチェック
                return !IsIdle && _cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested;
            });
            UpdateConditionViewModel();
        }

        private void UpdateConditionViewModel()
        {
            switch (SelectedShape)
            {
                case "Plane":
                    ConditionViewModel = _planeCondition;
                    break;
                case "Sphere":
                    ConditionViewModel = _sphereCondition;
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported shape type: {SelectedShape}");
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

        private CancellationTokenSource _cancellationTokenSource;

        private async Task SaveAsAsync(CancellationToken token)
        {
            this.IsIdle = false;
            _cancellationTokenSource = SaveAsCommand.CurrentCancellationTokenSource;
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

                IsIdle = false; // 初期状態ではキャンセル可能

                await _persistenceService.SaveDataAsync(filePath, data, token);

                var loadData = await _persistenceService.LoadDataAsync(filePath, token);

                if (data.Equals(loadData))
                {
                    _messageBoxService.ShowInfoMessage($"{filePath} にデータが保存されました。", "保存");
                }
                else
                {
                    throw new Exception($"{filePath} の内容が一致しません。");
                }

                Console.WriteLine($"{filePath} にデータがシリアル化されました。");
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("ファイル保存がキャンセルされました。");
            }
            catch (Exception ex)
            {
                // エラーハンドリング（ログ出力やユーザー通知など）
                Debug.WriteLine($"Error during save: {ex.Message}");
                _messageBoxService.ShowErrorMessage($"ファイルの保存に失敗しました。{ex.Message}ユーザーサポートにお問い合わせください。", "保存");
            }
            finally
            {
                this.IsIdle = true;
                _cancellationTokenSource = null; // キャンセル用トークンソースをリセット
            }
        }
    }
}