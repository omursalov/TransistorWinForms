using System.Reflection;
using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    /// <summary>
    /// Связан с файлом .INI
    /// </summary>
    public class StateWorker
    {
        private MainForm mainForm;
        private StateModel stateModel;

        /// <summary>
        /// Получает состояние рисунка.
        /// Если что-то уже меняли в проге, забираем состояние,
        /// если нет, берем то, что по умолчанию.
        /// Во внедренные ресурсы нельзя ничего писать, так что с EXE файлом
        /// будет папка Data\State.ini.. Вроде, норм.
        /// </summary>
        public StateWorker(MainForm mainForm)
        {
            this.mainForm = mainForm;
            stateModel = new StateModel(File.ReadAllText(Constants.STATE_FILE_NAME));
        }

        public StateModel Get() => stateModel;

        public string GetIni() => File.ReadAllText(Constants.STATE_FILE_NAME);

        /// <summary>
        /// Это уже когда на форме что-то меняем,
        /// возможно, можно было лучше сделать, пофиг..
        /// </summary>
        public void Update()
        {
            File.WriteAllText(Constants.STATE_FILE_NAME,
                $@"ColorLine = {mainForm.colorLineCB.Text}
FillColor = {mainForm.fillColorCB.Text}
TransitionType = {mainForm.GetTransitionType()}
Circle = {mainForm.circleCheckBox.Checked.ToString().ToLower()}
Cx = {mainForm.cxTextBox.Text}
Cy = {mainForm.cyTextBox.Text}
LineWidth = {mainForm.widthTextBox.Text}
MSize = {mainForm.mSizeTextBox.Text}");
        }
    }
}