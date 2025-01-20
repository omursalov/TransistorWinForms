using System.Reflection;
using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class FormWorker : IDisposable
    {
        private MainForm mainForm;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        private StateModel stateModel;

        private Bitmap bitmap;
        private Graphics graphics;

        /// <summary>
        /// IMPORTANT
        /// </summary>
        private bool initFlag = false;

        public FormWorker(MainForm mainForm, StateModel stateModel)
        {
            this.mainForm = mainForm;
            this.stateModel = stateModel;
            bitmap = new Bitmap(mainForm.mainPictureBox.Width, mainForm.mainPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Установить значения в контролы формы
        /// </summary>
        public void FillControls()
        {
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
        /// В textBox только цифры
        /// </summary>
        private bool checkIntTextBoxValue(TextBox textBox)
        {
            int value;

            if (textBox.Text == string.Empty
                || !int.TryParse(textBox.Text, out value)
                || value == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Отрисуем для понятности..
        /// </summary>
        private void DrawTemp()
            => mainForm.mainPictureBox.Image
                = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.TEMP_DRAW_RESOURCE_NAME));

        /// <summary>
        /// Нарисовать картинку
        /// </summary>
        public void Draw()
        {
            // Надо точно знать, что все инициализировано
            if (!initFlag)
                return;

            // Проверка textBoxes
            if (!checkIntTextBoxValue(mainForm.cxTextBox)
                || !checkIntTextBoxValue(mainForm.cyTextBox)
                || !checkIntTextBoxValue(mainForm.widthTextBox)
                || !checkIntTextBoxValue(mainForm.mSizeTextBox))
            {
                DrawTemp();
                return;
            }

            int M = int.Parse(mainForm.cxTextBox.Text); // Рекомендуемое значение М=70 для вписывания

            // Точка центра, от которой идет масштабирование 256 и 244
            int Cx = 256;
            int Cy = 244;

            // Цвет заливки
            // graphics = mainForm.mainPictureBox.CreateGraphics();

            var fillColorText = mainForm.fillColorCB.Text;
            graphics.Clear(colors[fillColorText]);

            // Ручка: цвет и толщина
            var colorLineText = mainForm.colorLineCB.Text;
            var pp = new Pen(colors[colorLineText], int.Parse(mainForm.widthTextBox.Text));

            //Отрисовка первого транзистора
            graphics.DrawLine(pp, 326, 314, 356, 314); // Центральная линия стрелки

            // Тут еще разбираться.. Стрелка поворот ее
            if (mainForm.transitionType1.Checked)
            {
                graphics.DrawLine(pp, 326, 314, 326 + (M / 4), 301 + (M / 4)); // Наклонная вверх стрелка
                graphics.DrawLine(pp, 326, 314, 326 + (M / 4), 327 - (M / 4)); // Наклонная вниз стрелка
            }

            graphics.DrawLine(pp, 356, 314, 356, 355); // Вертикальная правая линия
            graphics.DrawLine(pp, 326, 355, 400, 355); // Верхняя линия
            graphics.DrawLine(pp, 326, 273, 400, 273); // Нижняя линия
            graphics.DrawLine(pp, 310, 355, 250, 355); // Нижняя левая линия
            graphics.DrawLine(pp, 310, 273, 310, 355); // Вертикальная левая лииния
            graphics.DrawLine(pp, 326, 324, 326, 304); // Штрих центральный
            graphics.DrawLine(pp, 326, 283, 326, 263); // Штрих верхний
            graphics.DrawLine(pp, 326, 365, 326, 345); // Штрих нижний

            // Нужно круг рисовать?
            if (mainForm.circleCheckBox.Checked)
                graphics.DrawEllipse(pp, 256, 244, M * 2, M * 2); // Отрисовка круга*/

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