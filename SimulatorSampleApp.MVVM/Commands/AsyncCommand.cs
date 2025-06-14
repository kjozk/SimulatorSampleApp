using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimulatorSampleApp.MVVM
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<CancellationToken, Task> _execute;
        private readonly Func<bool> _canExecute;
        private CancellationTokenSource _cts; // コマンドのキャンセル用トークンソース
        private bool _isExecuting; // コマンドが実行中かどうかを示すフラグ

        /// <summary>
        /// コマンドが現在使用している CancellationTokenSource を取得します。
        /// コマンド実行中にのみ利用可能です。
        /// </summary>
        public CancellationTokenSource CurrentCancellationTokenSource => _cts;

        /// <summary>
        /// コマンドが現在実行中であるかどうかを示します。
        /// </summary>
        public bool IsExecuting
        {
            get => _isExecuting;
            private set
            {
                if (_isExecuting != value)
                {
                    _isExecuting = value;
                    // ICommand.CanExecuteChanged イベントを発火させ、UIのボタンなどの状態を更新させる
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// コマンドの実行可否が変更されたときに発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 新しい AsyncCommand のインスタンスを初期化します。
        /// </summary>
        /// <param name="execute">実行する非同期操作 (CancellationToken を受け取る Task を返す関数)。</param>
        /// <param name="canExecute">コマンドの実行可否を判断する関数 (省略可能)。</param>
        public AsyncCommand(Func<CancellationToken, Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// コマンドを実行できるかどうかを定義するメソッド。
        /// </summary>
        /// <param name="parameter">コマンドによって使用されるデータ。コマンドを実行できるかどうかは考慮されない。</param>
        /// <returns>コマンドを実行できる場合は true。それ以外の場合は false。</returns>
        public bool CanExecute(object parameter)
        {
            // コマンドが実行中でない AND _canExecute が設定されている場合はその結果、
            // 設定されていない場合は常に true (実行可能)
            return !IsExecuting && (_canExecute?.Invoke() ?? true);
        }

        /// <summary>
        /// コマンドが呼び出されたときに実行されるメソッド。
        /// </summary>
        /// <param name="parameter">コマンドによって使用されるデータ。コマンドを実行できるかどうかは考慮されない。</param>
        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _cts = new CancellationTokenSource(); // 新しいキャンセル用トークンソースを作成
                IsExecuting = true; // 実行中フラグを立てる

                try
                {
                    await _execute(_cts.Token); // 非同期操作を実行し、CancellationToken を渡す
                }
                catch (OperationCanceledException)
                {
                    // キャンセルされた場合の処理 (ログ出力など)
                    System.Diagnostics.Debug.WriteLine("AsyncCommand: Operation was cancelled.");
                }
                catch (Exception ex)
                {
                    // その他の例外処理 (ログ出力、ユーザーへの通知など)
                    System.Diagnostics.Debug.WriteLine($"AsyncCommand Error: {ex.Message}");
                    // throw; // コマンドの外に例外を伝播させる場合はコメントを外す
                }
                finally
                {
                    IsExecuting = false; // 実行中フラグをクリア
                    _cts.Dispose(); // CancellationTokenSource を破棄
                    _cts = null;
                }
            }
        }

        /// <summary>
        /// 現在実行中のコマンドをキャンセルします。
        /// </summary>
        public void Cancel()
        {
            _cts?.Cancel(); // キャンセル要求を発行
        }

        /// <summary>
        /// CanExecute メソッドの評価を強制的に再トリガーします。
        /// UI 要素の有効/無効状態を更新するために呼び出されます。
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
