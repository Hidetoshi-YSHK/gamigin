namespace Gamigin
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MainForm()
        {
            gamiginApp = GamiginApp.Instance;
            InitializeComponent();
        }

        /// <summary>
        /// �J���{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g������</param>
        /// <param name="e">�C�x���g</param>
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "�Ώۃt�@�C����I�����Ă�������";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                updateTargetFilePath(ofd.FileName);
            }
        }

        /// <summary>
        /// �Ώۃt�@�C���p�X���X�V����
        /// </summary>
        /// <param name="targetFilePath">�Ώۃt�@�C���p�X</param>
        private void updateTargetFilePath(string targetFilePath)
        {
            gamiginApp.TargetFilePath = targetFilePath;
            targetFilePathTextBox.Text = targetFilePath;
            targetFilePathTextBox.Select(targetFilePath.Length, 0);
        }

        /// <summary>
        /// GamiginApp�C���X�^���X
        /// </summary>
        private GamiginApp gamiginApp;
    }
}