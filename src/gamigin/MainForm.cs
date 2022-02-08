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
        /// �J�n/�I���{�^�������C�x���g
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
        /// �Ď����J�n����
        /// </summary>
        private void startMonitoring()
        {
            // �J���{�^���𖳌���
            openButton.Enabled = false;

            // �I���{�^���ɕύX����
            startAndEndButton.Text = END_BUTTON_TEXT;
            startAndEndButton.Image = Properties.Resources.hourglass_red;

            // �Ď����J�n
            gamiginApp.StartMonitoring();
        }

        /// <summary>
        /// �Ď����I������
        /// </summary>
        private void endMonitoring()
        {
            // �J���{�^����L����
            openButton.Enabled = true;

            // �J�n�{�^���ɕύX����
            startAndEndButton.Text = START_BUTTON_TEXT;
            startAndEndButton.Image = Properties.Resources.hourglass_blue;

            // �Ď����I��
            gamiginApp.EndMonitoring();
        }

        /// <summary>
        /// GamiginApp�C���X�^���X
        /// </summary>
        private GamiginApp gamiginApp;

        /// <summary>
        /// �J�n�{�^���̃e�L�X�g
        /// </summary>
        const string START_BUTTON_TEXT = "start";

        /// <summary>
        /// �I���{�^���̃e�L�X�g
        /// </summary>
        const string END_BUTTON_TEXT = "end";

    }
}