namespace Gamigin
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            gamiginApp = GamiginApp.Instance;
            InitializeComponent();
        }

        /// <summary>
        /// 開くボタン押下イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント</param>
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "対象ファイルを選択してください";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                updateTargetFilePath(ofd.FileName);
            }
        }

        /// <summary>
        /// 開始/終了ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startAndEndButton_Click(object sender, EventArgs e)
        {
            if (gamiginApp.IsMonitoring)
            {
                endMonitoring();
            }
            else
            {
                startMonitoring();
            }
        }

        /// <summary>
        /// 対象ファイルパスを更新する
        /// </summary>
        /// <param name="targetFilePath">対象ファイルパス</param>
        private void updateTargetFilePath(string targetFilePath)
        {
            gamiginApp.TargetFilePath = targetFilePath;
            targetFilePathTextBox.Text = targetFilePath;
            targetFilePathTextBox.Select(targetFilePath.Length, 0);
        }

        /// <summary>
        /// 監視を開始する
        /// </summary>
        private void startMonitoring()
        {
            // 開くボタンを無効化
            openButton.Enabled = false;

            // 終了ボタンに変更する
            startAndEndButton.Text = END_BUTTON_TEXT;
            startAndEndButton.Image = Properties.Resources.hourglass_red;

            // 監視を開始
            gamiginApp.StartMonitoring();
        }

        /// <summary>
        /// 監視を終了する
        /// </summary>
        private void endMonitoring()
        {
            // 開くボタンを有効化
            openButton.Enabled = true;

            // 開始ボタンに変更する
            startAndEndButton.Text = START_BUTTON_TEXT;
            startAndEndButton.Image = Properties.Resources.hourglass_blue;

            // 監視を終了
            gamiginApp.EndMonitoring();
        }

        /// <summary>
        /// GamiginAppインスタンス
        /// </summary>
        private GamiginApp gamiginApp;

        /// <summary>
        /// 開始ボタンのテキスト
        /// </summary>
        const string START_BUTTON_TEXT = "start";

        /// <summary>
        /// 終了ボタンのテキスト
        /// </summary>
        const string END_BUTTON_TEXT = "end";

    }
}