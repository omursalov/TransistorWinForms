using System.Reflection;
using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    /// <summary>
    /// Класс, который допиливал наскоряке.
    /// Если зашарить за математику, можно сделать лучше.
    /// </summary>
    public class DrawWorker : IDisposable
    {
        private MainForm mainForm;
        private FormWorker formWorker;
        private StateWorker stateWorker;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        private Bitmap bitmap;
        private Graphics graphics;

        public IntTextBoxValidator intTextBoxValidator { get; private set; }

        #region Фигуры рисунка
        private CircleDrawModel circleDrawModel;
        private LinesDrawModels lineDrawModels;
        #endregion

        public DrawWorker(MainForm mainForm, FormWorker formWorker, IntTextBoxValidator intTextBoxValidator)
        {
            this.mainForm = mainForm;
            this.intTextBoxValidator = intTextBoxValidator;
            bitmap = new Bitmap(mainForm.mainPictureBox.Width, mainForm.mainPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            this.formWorker = formWorker;
            circleDrawModel = new CircleDrawModel(mainForm);
            lineDrawModels = new LinesDrawModels(mainForm);
        }

        /// <summary>
        /// Нарисовать картинку.
        /// Данный метод можно отрефачить + математику поправить,
        /// но это не для меня..
        /// </summary>
        public void Execute()
        {
            // Надо точно знать, что все инициализировано
            if (!formWorker.InitFlag)
               return;

            // Проверка textBoxes
            if (!intTextBoxValidator.Validate(mainForm.cxTextBox)
                || !intTextBoxValidator.Validate(mainForm.cyTextBox)
                || !intTextBoxValidator.Validate(mainForm.widthTextBox)
                || !intTextBoxValidator.Validate(mainForm.mSizeTextBox))
            {
                DrawTemp();
                return;
            }

            var width = mainForm.mainPictureBox.Width;
            var height = mainForm.mainPictureBox.Height;

            var cx = int.Parse(mainForm.cxTextBox.Text);
            var cy = int.Parse(mainForm.cyTextBox.Text);
            var mSize = int.Parse(mainForm.mSizeTextBox.Text); // Масштаб

            // Цвет заливки
            var fillColorText = mainForm.fillColorCB.Text;
            graphics.Clear(colors[fillColorText]);

            // Ручка: цвет и толщина
            var colorLineText = mainForm.colorLineCB.Text;
            var pen = new Pen(colors[colorLineText], int.Parse(mainForm.widthTextBox.Text));

            // Отрисовка всех линий..
            // Вероятно, ужасный код..
            lineDrawModels.Execute(graphics, pen);

            // Нужно круг рисовать?
            if (mainForm.circleCheckBox.Checked)
                circleDrawModel.Execute(graphics, pen); // Отрисовка круга

            mainForm.mainPictureBox.Image = bitmap;
        }

        /// <summary>
        /// Получить картинку
        /// </summary>
        public Image GetImage() => bitmap;

        public void Dispose()
        {
            graphics.Dispose();
            bitmap.Dispose();
        }

        /// <summary>
        /// Отрисуем для понятности..
        /// </summary>
        private void DrawTemp()
            => mainForm.mainPictureBox.Image
                = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.TEMP_DRAW_RESOURCE_NAME));
    }
}