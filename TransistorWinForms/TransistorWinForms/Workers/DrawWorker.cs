using System.Reflection;
using TransistorWinForms.Data;

namespace TransistorWinForms.Workers
{
    public class DrawWorker : IDisposable
    {
        private MainForm mainForm;
        private FormWorker formWorker;
        private StateWorker stateWorker;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        private Bitmap bitmap;
        private Graphics graphics;

        public IntTextBoxValidator intTextBoxValidator { get; private set; }

        public DrawWorker(MainForm mainForm, FormWorker formWorker, IntTextBoxValidator intTextBoxValidator)
        {
            this.mainForm = mainForm;
            this.intTextBoxValidator = intTextBoxValidator;
            bitmap = new Bitmap(mainForm.mainPictureBox.Width, mainForm.mainPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            this.formWorker = formWorker;
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

            var x = 5; // 5 к 1 (500x500 pictureBox)

            var width = mainForm.mainPictureBox.Width;
            var height = mainForm.mainPictureBox.Height;

            var cx = int.Parse(mainForm.cxTextBox.Text);
            var cy = int.Parse(mainForm.cyTextBox.Text);
            var mSize = int.Parse(mainForm.mSizeTextBox.Text); // Масштаб (по умолчанию = 100)

            // Цвет заливки
            var fillColorText = mainForm.fillColorCB.Text;
            graphics.Clear(colors[fillColorText]);

            // Ручка: цвет и толщина
            var colorLineText = mainForm.colorLineCB.Text;
            var pp = new Pen(colors[colorLineText], int.Parse(mainForm.widthTextBox.Text));

            var lineM = 10;

            // Штрих сверху
            /*graphics.DrawLine(pp, 
                cx * x, 
                -(cy * x) + height - (mSize / lineM) - (mSize / 2), 
                cx * x, 
                -(cy * x) + height + (mSize / lineM) - (mSize / 2));

            // Штрих центральный
            graphics.DrawLine(pp, 
                cx * x, 
                -(cy * x) + height - (mSize / lineM), 
                cx * x, 
                -(cy * x) + height + (mSize / lineM));

            // Штрих снизу
            graphics.DrawLine(pp,
                cx * x,
                -(cy * x) + height - (mSize / lineM) + (mSize / 2),
                cx * x,
                -(cy * x) + height + (mSize / lineM) + (mSize / 2));

            // Линия слева
            graphics.DrawLine(pp,
                cx * x - mSize / 5,
                -(cy * x) + height - (mSize / lineM) + (mSize / 2),
                cx * x - mSize - mSize / 5,
                -(cy * x) + height - (mSize / lineM) + (mSize / 2));

            // Линия слева (вверх идущая)
            graphics.DrawLine(pp,
                cx * x - mSize / 5,
                -(cy * x) + height - (mSize / lineM) + (mSize / 2) + lineM,
                cx * x - mSize / 5,
                -(cy * x) + height - (mSize / lineM) - (mSize / 2) + lineM);*/

            // Нужно круг рисовать?
            if (mainForm.circleCheckBox.Checked)
                graphics.DrawEllipse(pp, cx * x - mSize, -(cy * x + mSize) + height, mSize * 2, mSize * 2); // Отрисовка круга

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