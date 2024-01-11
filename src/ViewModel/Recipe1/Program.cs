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
            // IoCコンテナインスタンス化
            var services = new ServiceCollection();

            // 依存する型の追加
            // 型のリクエストに応じてインスタンスを生成する
            services.AddTransient<DeploymentArtifacts>();
            services.AddTransient<DeploymentRepository>();
            services.AddTransient<IDeploymentService, DeploymentService>();

            // 同じインスタンスを使いまわす場合
            // services.AddSingleton<DeploymentArtifacts>();

            // オブジェクトの生存期間を細かく管理する場合
            // services.AddScoped<DeploymentArtifacts>();

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
