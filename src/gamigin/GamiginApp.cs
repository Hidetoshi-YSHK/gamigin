namespace Gamigin
{
    internal class GamiginApp
    {
        /// <summary>
        /// 監視を開始する
        /// </summary>
        /// <returns>true:開始に成功 false:失敗</returns>
        public bool StartMonitoring()
        {
            IsMonitoring = true;

            if (!File.Exists(TargetFilePath))
            {
                return false;
            }
            
            var directoryPath = Path.GetDirectoryName(TargetFilePath);
            if (directoryPath == null)
            {
                return false;
            }

            var fileName = Path.GetFileName(TargetFilePath);
            if (fileName == null)
            {
                return false;
            }

            fileWatcher = new();
            fileWatcher.Path = directoryPath;
            fileWatcher.Filter = fileName;
            fileWatcher.NotifyFilter = 
                NotifyFilters.LastWrite | NotifyFilters.FileName;
            fileWatcher.Changed +=
                new FileSystemEventHandler(OnTargetFileChanged);
            fileWatcher.Deleted +=
                new FileSystemEventHandler(OnTargetFileDeleted);
            fileWatcher.Renamed +=
                new RenamedEventHandler(OnTargetFileRenamed);
            fileWatcher.EnableRaisingEvents = true;

            return true;
        }

        /// <summary>
        /// 監視を終了する
        /// </summary>
        public void EndMonitoring() {
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
                fileWatcher = null;
            }
            IsMonitoring = false;
        }

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static GamiginApp Instance => instance;

        /// <summary>
        /// メインフォームのインスタンス
        /// </summary>
        public MainForm? MainFormInstance { get; set; }

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
            MainFormInstance = null;
            TargetFilePath = "";
            IsMonitoring = false;
        }

        /// <summary>
        /// ファイル変更イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント</param>
        private void OnTargetFileChanged(object sender, FileSystemEventArgs e)
        {
        }

        /// <summary>
        /// ファイル削除イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント</param>
        private void OnTargetFileDeleted(object sender, FileSystemEventArgs e)
        {
            TargetFilePath = string.Empty;
            if (MainFormInstance != null)
            {
                MainFormInstance.InvokeUpdateTargetFilePath(TargetFilePath);
            }
        }

        /// <summary>
        /// ファイル名変更イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント</param>
        private void OnTargetFileRenamed(object sender, RenamedEventArgs e)
        {
            TargetFilePath = e.FullPath;
            var fileName = Path.GetFileName(e.FullPath);
            if ((fileWatcher != null) && (fileName != null))
            {
                fileWatcher.Filter = fileName;
            }
            if (MainFormInstance != null)
            {
                MainFormInstance.InvokeUpdateTargetFilePath(TargetFilePath);
            }
        }

        /// <summary>
        /// privateインスタンス
        /// </summary>
        private static readonly GamiginApp instance = new();

        /// <summary>
        /// ファイル監視インスタンス
        /// </summary>
        private FileSystemWatcher? fileWatcher = null;
    }
}
