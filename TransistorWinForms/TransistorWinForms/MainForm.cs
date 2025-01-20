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
        /// Загрузка формы
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
        /// Вводим в textBoxes только цифры
        /// </summary>
        private void textBox_KeyPressOnlyDigits(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        /// <summary>
        /// Сохранение файла (либо картинка, либо состояние)
        /// </summary>
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Установка возможных форматов (rtf, txt, ini, можете добавить свои)
            saveFileDialog.Filter = "BMP Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|INI Files (*.ini)|*.ini";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower();

                // Обработка расширений
                if (fileExtension == ".bmp")
                {
                    // Сохранение в формате RTF
                    //richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
                }
                else if (fileExtension == ".png")
                {
                    // Сохранение в формате TXT
                    //richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                }
                else if (fileExtension == ".ini")
                {
                    // Сохранение в формате INI
                    // ...
                }
            }
        }
    }
}
