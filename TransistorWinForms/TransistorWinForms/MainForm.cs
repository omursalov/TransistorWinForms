using TransistorWinForms.Workers;

namespace TransistorWinForms
{
    public partial class MainForm : Form
    {
        public FormWorker FormWorker { get; private set; }
        public StateWorker StateWorker { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            StateWorker = new StateWorker();
            var state = StateWorker.Get();
            FormWorker = new FormWorker(this, state);
        }

        /// <summary>
        /// �������� �����
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormWorker.FillControls();
            FormWorker.Draw();
        }

        private void setDefaultBtn_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ������ � textBoxes ������ �����
        /// </summary>
        private void textBox_KeyPressOnlyDigits(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        /// <summary>
        /// ���������� ����� (���� ��������, ���� ���������)
        /// </summary>
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            // ��������� ��������� �������� (rtf, txt, ini, ������ �������� ����)
            saveFileDialog.Filter = "BMP Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|INI Files (*.ini)|*.ini";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower();

                // ��������� ����������
                if (fileExtension == ".bmp")
                {
                    // ���������� � ������� RTF
                    //richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
                }
                else if (fileExtension == ".png")
                {
                    // ���������� � ������� TXT
                    //richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                }
                else if (fileExtension == ".ini")
                {
                    // ���������� � ������� INI
                    // ...
                }
            }
        }

        #region �����������
        private void colorLineCB_SelectedIndexChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void fillColorCB_SelectedIndexChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void transitionType1_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void transitionType2_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void circleCheckBox_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void cxTextBox_TextChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void cyTextBox_TextChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void widthTextBox_TextChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void mSizeTextBox_TextChanged(object sender, EventArgs e) => FormWorker.Draw();
        #endregion
    }
}
