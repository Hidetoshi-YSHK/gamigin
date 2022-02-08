using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamigin
{
    internal class GamiginApp
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static GamiginApp Instance => instance;

        /// <summary>
        /// 対象ファイルのパス
        /// </summary>
        public string TargetFilePath { get; set; }

        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        private GamiginApp()
        {
            TargetFilePath = "";
        }

        /// <summary>
        /// privateインスタンス
        /// </summary>
        private static readonly GamiginApp instance = new();
    }
}
