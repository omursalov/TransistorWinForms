using System.Reflection;
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
        /// Тут получим состояние проги (бывшее или default)
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StateWorker = new StateWorker(this);
            FormWorker = new FormWorker(this, StateWorker);
            IntTextBoxValidator = new IntTextBoxValidator([cxTextBox, cyTextBox, widthTextBox, mSizeTextBox]);
        }

        /// <summary>
        /// При загрузке формы инициализируем значения в controls
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
            => FormWorker.FillControls();

        /// <summary>
        /// Очистка ресурсов при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            => FormWorker.Dispose();

        /// <summary>
        /// Вводим в textBoxes только цифры
        /// </summary>
        private void textBox_KeyPressOnlyDigits(object sender, KeyPressEventArgs e)
            => IntTextBoxValidator.KeyPressCheck(e);

        /// <summary>
        /// Сохранение файла (либо картинка, либо состояние)
        /// </summary>
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Установка возможных форматов
            saveFileDialog.Filter = string.Join('|',
                Constants.ImageFileExtensions.Select(x => $"{x.Key.ToUpper()} Files (*.{x.Key})|*.{x.Key}"));
            saveFileDialog.Filter += "|INI Files (*.ini)|*.ini";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower().Replace(".", string.Empty);

                // Обработка расширений
                if (fileExtension == "ini")
                    File.WriteAllText(saveFileDialog.FileName, StateWorker.GetIni());
                else
                {
                    var bmp = FormWorker.GetImage();
                    bmp.Save(saveFileDialog.FileName, Constants.ImageFileExtensions[fileExtension]);
                }
            }
        }

        private void iniLoadBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            // Установка возможных форматов
            openFileDialog.Filter = "INI Files (*.ini)|*.ini";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                StateWorker.Update(File.ReadAllText(fileName));
                FormWorker.FillControls();
                FormWorker.Draw();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.STATE_RESOURCE_NAME);
            using var reader = new StreamReader(stream);
            StateWorker.Update(reader.ReadToEnd());
            FormWorker.FillControls();
            FormWorker.Draw();
        }

        #region Перерисовка
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
        /// Переопределяем OnPain, чтобы лучше контролировать отрисовку
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
            => FormWorker.Draw();

        public string GetTransitionType()
            => transitionType1.Checked ? "n-канальный"
            : transitionType2.Checked ? "p-канальный"
            : "неизвестно";
    }
}