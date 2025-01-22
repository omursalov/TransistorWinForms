using System.Drawing.Imaging;
using TransistorWinForms.Data;
using TransistorWinForms.Workers;

namespace TransistorWinForms
{
    public partial class MainForm : Form
    {
        public FormWorker FormWorker { get; private set; }
        public StateWorker StateWorker { get; private set; }
        public IntTextBoxValidator IntTextBoxValidator { get; private set; }

        /// <summary>
        /// ��� ������� ��������� ����� (������ ��� default)
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StateWorker = new StateWorker();
            var state = StateWorker.Get();
            FormWorker = new FormWorker(this, state);
            IntTextBoxValidator = new IntTextBoxValidator([cxTextBox, cyTextBox, widthTextBox, mSizeTextBox]);
        }

        /// <summary>
        /// ��� �������� ����� �������������� �������� � controls
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
            => FormWorker.FillControls();

        /// <summary>
        /// ������� �������� ��� �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            => FormWorker.Dispose();

        /// <summary>
        /// �������������� OnPain, ����� ����� �������������� ���������
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
            => FormWorker.Draw();

        /// <summary>
        /// ������ � textBoxes ������ �����
        /// </summary>
        private void textBox_KeyPressOnlyDigits(object sender, KeyPressEventArgs e)
            => IntTextBoxValidator.KeyPressCheck(e);

        /// <summary>
        /// ���������� ����� (���� ��������, ���� ���������)
        /// </summary>
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            // ��������� ��������� ��������
            saveFileDialog.Filter = string.Join('|', 
                Constants.ImageFileExtensions.Select(x => $"{x.Key.ToUpper()} Files (*.{x.Key})|*.{x.Key}"));

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower().Replace(".", string.Empty);

                // ��������� ����������
                if (fileExtension == "ini")
                {
                    // ��� ��� ������ save
                }
                else
                {
                    var bmp = FormWorker.GetImage();
                    bmp.Save(saveFileDialog.FileName, Constants.ImageFileExtensions[fileExtension]);
                }
            }
        }

        #region �����������
        private void colorLineCB_SelectedIndexChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void fillColorCB_SelectedIndexChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void transitionType1_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void transitionType2_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();
        private void circleCheckBox_CheckedChanged(object sender, EventArgs e) => FormWorker.Draw();

        private void cxTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.ProcessLimit((TextBox)sender, e);
            FormWorker.Draw();
        }

        private void cyTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.ProcessLimit((TextBox)sender, e);
            FormWorker.Draw();
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.ProcessLimit((TextBox)sender, e);
            FormWorker.Draw();
        }

        private void mSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.ProcessLimit((TextBox)sender, e);
            FormWorker.Draw();
        }
        #endregion
    }
}
