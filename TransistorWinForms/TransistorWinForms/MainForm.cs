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
            FormWorker = new FormWorker(this);
            StateWorker = new StateWorker();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormWorker.SetValues(StateWorker.Get());
            FormWorker.Draw();
        }

        private void setDefaultBtn_Click(object sender, EventArgs e) => FormWorker.SetValues();
    }
}
