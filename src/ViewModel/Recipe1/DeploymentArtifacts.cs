using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    public class DeploymentArtifacts
    {
        public void Validate()
        {
            System.Console.WriteLine("検証中...");
        }
    }

    public class DeploymentRepository
    {
        public void SaveStatus(string status)
        {
            System.Console.WriteLine("ステータスを保存中...");
        }
    }

    interface IDeploymentService
    {
        void PerformValidation();
    }

    /// <summary>
    /// プロセス管理
    /// </summary>
    public class DeploymentService : IDeploymentService
    {
        // インスタンス化をしない
        readonly DeploymentArtifacts artifacts;
        readonly DeploymentRepository repository;

        /// <summary>
        /// コンストラクタ
        /// 引数で依存する型をset
        /// IoCコンテナが依存する型のインスタンス化する方法を知るための実装
        /// </summary>
        /// <param name="artifacts">DeploymentArtifacts</param>
        /// <param name="repository">DeploymentRepository</param>
        public DeploymentService(
            DeploymentArtifacts artifacts,
            DeploymentRepository repository)
        {
            this.artifacts = artifacts;
            this.repository = repository;
        }

        public void PerformValidation()
        {
            artifacts.Validate();
            repository.SaveStatus("Status");
        }
    }
}
