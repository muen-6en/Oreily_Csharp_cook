﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    /// <summary>
    /// サードパーティー製のライブラリなど
    /// </summary>
    public class ThirdPartyDeploymentService
    {
        public void Validate()
        {
            Console.WriteLine("検証されました");
        }
    }

    /// <summary>
    /// IoCコンテナと組み合わせるためのインターフェイス
    /// </summary>
    public interface IValidatorFactory
    {
        ThirdPartyDeploymentService CreateDeploymentService();
    }

    /// <summary>
    /// ファクトリー
    /// </summary>
    public class ValidatorFactory : IValidatorFactory
    {
        // 本来ならここでIoCコンテナを使用して依存性を注入する

        // オブジェクトを生成する
        public ThirdPartyDeploymentService CreateDeploymentService()
        {
            return new ThirdPartyDeploymentService();
        }
    }
}
