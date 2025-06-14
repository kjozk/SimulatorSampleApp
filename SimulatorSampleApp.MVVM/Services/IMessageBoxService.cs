using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorSampleApp.MVVM.Services
{
    public interface IMessageBoxService
    {
        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        void ShowInfoMessage(string message, string title);

        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        void ShowErrorMessage(string message, string title);

        /// <summary>
        /// 確認ダイアログを表示します。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        bool ShowConfirmation(string message, string title);
    }
}
