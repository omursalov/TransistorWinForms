namespace TransistorWinForms.Workers
{
    public class FormWorker
    {
        private MainForm mainForm;

        private StateWorker stateWorker;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        /// <summary>
        /// Если true, значит все controls уже инициализированы
        /// </summary>
        public bool InitFlag { get; private set; }

        public FormWorker(MainForm mainForm, StateWorker stateWorker)
        {
            this.mainForm = mainForm;
            this.stateWorker = stateWorker;
        }

        /// <summary>
        /// Установить значения в контролы формы
        /// </summary>
        public void FillControls()
        {
            var stateModel = stateWorker.Get();

            // Разбираемся с элементами в выпадающих списках
            mainForm.colorLineCB.Items.Clear();
            mainForm.fillColorCB.Items.Clear();

            foreach (var color in colors)
            {
                mainForm.colorLineCB.Items.Add(color.Key);
                mainForm.fillColorCB.Items.Add(color.Key);
            }

            // Подставляем значения по умолчанию
            mainForm.colorLineCB.Text = stateModel.ColorLine;
            mainForm.fillColorCB.Text = stateModel.FillColor;

            if (stateModel.TransitionType.Contains("n"))
                mainForm.transitionType1.Checked = true;
            else if (stateModel.TransitionType.Contains("p"))
                mainForm.transitionType1.Checked = true;
            else
                throw new Exception("Неизвестный тип канала");

            mainForm.circleCheckBox.Checked = stateModel.Circle;
            mainForm.cxTextBox.Text = stateModel.Cx.ToString();
            mainForm.cyTextBox.Text = stateModel.Cy.ToString();

            mainForm.widthTextBox.Text = stateModel.LineWidth.ToString();
            mainForm.mSizeTextBox.Text = stateModel.MSize.ToString();

            InitFlag = true;
        }
    }
}