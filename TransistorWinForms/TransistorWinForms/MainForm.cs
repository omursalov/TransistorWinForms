using TransistorWinForms.Data;
using TransistorWinForms.Models;
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
            StateWorker = new StateWorker(this);
            FormWorker = new FormWorker(this, StateWorker);
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
            saveFileDialog.Filter += "|INI Files (*.ini)|*.ini";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower().Replace(".", string.Empty);

                // ��������� ����������
                if (fileExtension == "ini")
                    File.WriteAllText(saveFileDialog.FileName, StateWorker.GetIni());
                else
                {
                    var bmp = FormWorker.GetImage();
                    bmp.Save(saveFileDialog.FileName, Constants.ImageFileExtensions[fileExtension]);
                }
            }
        }

        #region �����������
        private void colorLineCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void fillColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void transitionType1_CheckedChanged(object sender, EventArgs e)
        {
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void transitionType2_CheckedChanged(object sender, EventArgs e)
        {
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void circleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void cxTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.TextChangedCheck((TextBox)sender, e);
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void cyTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.TextChangedCheck((TextBox)sender, e);
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.TextChangedCheck((TextBox)sender, e);
            StateWorker.Update();
            FormWorker.Draw();
        }

        private void mSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            IntTextBoxValidator.TextChangedCheck((TextBox)sender, e);
            StateWorker.Update();
            FormWorker.Draw();
        }
        #endregion

        /// <summary>
        /// �������������� OnPain, ����� ����� �������������� ���������
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
            => FormWorker.Draw();

        public string GetTransitionType()
            => transitionType1.Checked ? "n-���������"
            : transitionType2.Checked ? "p-���������"
            : "����������";
    }
}