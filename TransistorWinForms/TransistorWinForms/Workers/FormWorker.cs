using System.Reflection;
using TransistorWinForms.Data;

namespace TransistorWinForms.Workers
{
    public class FormWorker : IDisposable
    {
        private MainForm mainForm;

        private StateWorker stateWorker;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        private Bitmap bitmap;
        private Graphics graphics;

        /// <summary>
        /// IMPORTANT
        /// </summary>
        private bool initFlag = false;

        public FormWorker(MainForm mainForm, StateWorker stateWorker)
        {
            this.mainForm = mainForm;
            this.stateWorker = stateWorker;
            bitmap = new Bitmap(mainForm.mainPictureBox.Width, mainForm.mainPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
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

            initFlag = true;
        }

        /// <summary>
        /// В textBox только цифры, еще и лимиты проверяем
        /// </summary>
        private bool validateIntTextBox(TextBox textBox)
            => textBox.Text != string.Empty
                && int.TryParse(textBox.Text, out int value);

        /// <summary>
        /// Отрисуем для понятности..
        /// </summary>
        private void DrawTemp()
            => mainForm.mainPictureBox.Image
                = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.TEMP_DRAW_RESOURCE_NAME));

        /// <summary>
        /// Нарисовать картинку.
        /// Данный метод можно отрефачить + математику поправить,
        /// но это не для меня..
        /// </summary>
        public void Draw()
        {
            // Надо точно знать, что все инициализировано
            if (!initFlag)
                return;

            // Проверка textBoxes
            if (!validateIntTextBox(mainForm.cxTextBox)
                || !validateIntTextBox(mainForm.cyTextBox)
                || !validateIntTextBox(mainForm.widthTextBox)
                || !validateIntTextBox(mainForm.mSizeTextBox))
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
            graphics.DrawLine(pp, 
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
                -(cy * x) + height - (mSize / lineM) - (mSize / 2) + lineM);

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
    }
}