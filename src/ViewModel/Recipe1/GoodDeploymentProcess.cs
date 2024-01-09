using System;
using System.IO;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    public class GoodDeploymentProcess : IDisposable
    {
        // 解放状態
        bool disposed;

        readonly StreamWriter report = new StreamWriter("DeploymentReport.txt");

        public bool CheckStatus()
        {
            report.WriteLine($"{DateTime.Now} アプリケーションが配置されました");

            return true;
        }

        /// <summary>
        /// リソース解放
        /// </summary>
        /// <param name="disposing">マネージリソースの解放</param>
        public virtual void Dispose(bool disposing)
        {
            // 解放済みの場合は処理しない
            if (!disposed)
            {
                if (disposing)
                {
                    // 純粋なマネージリソースはこの位置で破棄する
                }

                report?.Close();

                // 多重解放を防ぐために設定
                // 設定漏れリスク：ObjectDisposedException
                disposed = true;
            }
        }

        /// <summary>
        /// ファイナライザ/デストラクタ
        /// マネージリソースを解放しない
        /// </summary>
        ~GoodDeploymentProcess()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// マネージリソースを解放する
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
