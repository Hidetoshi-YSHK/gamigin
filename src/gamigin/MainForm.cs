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
        /// GamiginAppインスタンス
        /// </summary>
        private GamiginApp gamiginApp;
    }
}