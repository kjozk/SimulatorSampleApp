using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorSampleApp.MVVM
{
    /// <summary>
    /// ViewModelの基底クラス。
    /// バインディング通知、リソース解放、将来的な共通処理をまとめる。
    /// </summary>
    public abstract class ViewModelBase : BindableBase, IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~ViewModelBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// IDisposable の実装。明示的に ViewModel を解放できる。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 派生クラスで Dispose 処理をオーバーライド可能。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                // マネージドリソースの解放（必要に応じて）
            }

            // アンマネージドリソースの解放（必要に応じて）

            _isDisposed = true;
        }

        /// <summary>
        /// 初期化処理（必要に応じて非同期でオーバーライド可）
        /// </summary>
        public virtual void Initialize() { }
    }
}
