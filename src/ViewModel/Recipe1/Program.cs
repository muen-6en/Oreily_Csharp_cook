using System;
using Microsoft.Extensions.DependencyInjection;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    class Program
    {
        readonly IDeploymentService service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service">インターフェース</param>
        public Program(IDeploymentService service)
        {
            this.service = service;
        }

        static void Main()
        {
            // IoCコンテナインスタンス化
            var services = new ServiceCollection();

            // 依存する型の追加
            // 型のリクエストに応じてインスタンスを生成
            services.AddTransient<DeploymentArtifacts>();
            services.AddTransient<DeploymentRepository>();
            services.AddTransient<IDeploymentService, DeploymentService>();

            // 同じインスタンスを使いまわす場合
            // services.AddSingleton<DeploymentArtifacts>();

            // オブジェクトの生存期間を細かく管理する場合
            // services.AddScoped<DeploymentArtifacts>();

            // ServiceProvider型に変換
            // 依存性が注入された型の管理を行うインスタンス
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // インターフェイスの実装インスタンスを取得
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
