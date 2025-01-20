using TransistorWinForms.Models;

namespace TransistorWinForms
{
    public partial class MainForm : Form
    {
        private FormModel FormModel;

        public MainForm()
        {
            InitializeComponent();
            FormModel = new FormModel(this);
        }

        private void MainForm_Load(object sender, EventArgs e) => FormModel.SetDefault();

        private void setDefaultBtn_Click(object sender, EventArgs e) => FormModel.SetDefault();
    }
}
