namespace Gamigin
{
    internal class GamiginApp
    {
        /// <summary>
        /// 監視を開始する
        /// </summary>
        public void StartMonitoring()
        {
            IsMonitoring = true;
        }

        /// <summary>
        /// 監視を終了する
        /// </summary>
        public void EndMonitoring()
        {
            IsMonitoring = false;
        }

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static GamiginApp Instance => instance;

        /// <summary>
        /// 対象ファイルのパス
        /// </summary>
        public string TargetFilePath { get; set; }

        /// <summary>
        /// 冠詞中か否か
        /// </summary>
        public bool IsMonitoring { get; set; }

        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        private GamiginApp()
        {
            TargetFilePath = "";
            IsMonitoring = false;
        }

        /// <summary>
        /// privateインスタンス
        /// </summary>
        private static readonly GamiginApp instance = new();
    }
}
