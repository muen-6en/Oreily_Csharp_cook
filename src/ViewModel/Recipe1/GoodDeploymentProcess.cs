using System;
using System.IO;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    public class GoodDeploymentProcess : IDisposable
    {
        bool disposed;

        readonly StreamWriter report = new StreamWriter("DeploymentReport.txt");

        public bool CheckStatus()
        {
            report.WriteLine($"{DateTime.Now} アプリケーションが配置されました");

            return true;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // 純粋なマネージリソースはこの位置で破棄する
                }

                report?.Close();
                disposed = true;
            }
        }

        ~GoodDeploymentProcess()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


    // mainメソッド: 呼び出し側
    //using (var deployer = GoodDeploymentProcess())
    //{
    //    deployer.CheckStatus();    
    //}
}
