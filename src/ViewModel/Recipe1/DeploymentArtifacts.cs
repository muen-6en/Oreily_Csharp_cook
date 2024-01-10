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

    public class DeploymentService : IDeploymentService
    {
        readonly DeploymentArtifacts artifacts;
        readonly DeploymentRepository repository;

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
