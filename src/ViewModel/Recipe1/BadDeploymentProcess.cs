using System;
using System.IO;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    public class BadDeploymentProcess
    {
        StreamWriter report = new StreamWriter("Deployment.txt");

        public bool CheckStatus()
        {
            report.WriteLine($"{DateTime.Now} アプリケーションが配置されました");

            return true;
        }
    }
}
