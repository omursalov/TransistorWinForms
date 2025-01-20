using System.Reflection;
using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class FormWorker
    {
        private MainForm mainForm;

        private IDictionary<string, Color> colors = Data.Constants.Colors;

        private StateModel stateModel;

        /// <summary>
        /// IMPORTANT
        /// </summary>
        private bool initFlag = false;

        public FormWorker(MainForm mainForm, StateModel stateModel)
        {
            this.mainForm = mainForm;
            this.stateModel = stateModel;
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
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool checkIntTextBoxValue(TextBox textBox)
        {
            int value;

            if (textBox.Text == string.Empty)
            {
                //MessageBox::Show("TextBox не может быть пустым");
                return false;
            }

            if (!int.TryParse(textBox.Text, out value))
            {
                //MessageBox::Show("Вводите только цифры в TextBox");
                return false;
            }

            if (value == 0)
            {
                //MessageBox::Show("Не может быть 0 в TextBox");
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
            using (var g = mainForm.mainPictureBox.CreateGraphics())
            {
                var fillColorText = mainForm.fillColorCB.Text;
                g.Clear(colors[fillColorText]);

                // Ручка: цвет и толщина
                var colorLineText = mainForm.colorLineCB.Text;
                var pp = new Pen(colors[colorLineText], int.Parse(mainForm.widthTextBox.Text));

                //Отрисовка первого транзистора
                g.DrawLine(pp, 326, 314, 356, 314); // Центральная линия стрелки

                // Тут еще разбираться.. Стрелка поворот ее
                if (mainForm.transitionType1.Checked)
                {
                    g.DrawLine(pp, 326, 314, 326 + (M / 4), 301 + (M / 4)); // Наклонная вверх стрелка
                    g.DrawLine(pp, 326, 314, 326 + (M / 4), 327 - (M / 4)); // Наклонная вниз стрелка
                }

                g.DrawLine(pp, 356, 314, 356, 355); // Вертикальная правая линия
                g.DrawLine(pp, 326, 355, 400, 355); // Верхняя линия
                g.DrawLine(pp, 326, 273, 400, 273); // Нижняя линия
                g.DrawLine(pp, 310, 355, 250, 355); // Нижняя левая линия
                g.DrawLine(pp, 310, 273, 310, 355); // Вертикальная левая лииния
                g.DrawLine(pp, 326, 324, 326, 304); // Штрих центральный
                g.DrawLine(pp, 326, 283, 326, 263); // Штрих верхний
                g.DrawLine(pp, 326, 365, 326, 345); // Штрих нижний

                // Нужно круг рисовать?
                if (mainForm.circleCheckBox.Checked)
                    g.DrawEllipse(pp, 256, 244, M * 2, M * 2); // Отрисовка круга*/
            }
        }
    }
}
