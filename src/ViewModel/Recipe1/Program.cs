using System;
using Microsoft.Extensions.DependencyInjection;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    class Program
    {
        readonly IDeploymentService service;

        public Program(IDeploymentService service)
        {
            this.service = service;
        }

        static void Main()
        {
            var services = new ServiceCollection();

            services.AddTransient<DeploymentArtifacts>();
            services.AddTransient<DeploymentRepository>();
            services.AddTransient<IDeploymentService, DeploymentService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IDeploymentService deploymentService = serviceProvider.GetRequiredService<IDeploymentService>();

            var program = new Program(deploymentService);

            program.StartDeployment();
        }

        public void StartDeployment()
        {
            service.PerformValidation();
            Console.WriteLine("検証が完了 - 処理を継続します...");
        }
    }
}
