using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_Csharp_CookBook.ViewModel.Recipe1
{
    /// <summary>
    /// Recipe1-3
    /// </summary>
    public class Program3
    {
        readonly ThirdPartyDeploymentService service;

        /// <summary>
        /// ファクトリークラスを用いてサードパーティーオブジェクトを生成
        /// </summary>
        /// <param name="factory">ファクトリークラス</param>
        public Program3(IValidatorFactory factory)
        {
            service = factory.CreateDeploymentService();
        }

        static void Main()
        {
            var factory = new ValidatorFactory();
            var program = new Program3(factory);
            program.PerformValidation();
        }

        /// <summary>
        /// サードパーティー製の機能をつかう
        /// </summary>
        void PerformValidation()
        {
            service.Validate();
        }

    }
}
