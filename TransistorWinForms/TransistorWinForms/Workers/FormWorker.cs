using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class FormWorker
    {
        private MainForm mainForm;

        private IDictionary<string, Color> colors;

        private StateModel stateModel;

        private bool initFlag = false;

        public FormWorker(MainForm mainForm)
            => this.mainForm = mainForm;

        /// <summary>
        /// Установить значения в контролы формы
        /// </summary>
        public void SetValues(StateModel state)
        {
            // Разбираемся с элементами в выпадающих списках
            /*colorLineCB->Items->Clear();
            for (int i = 0; i < colorTexts->Length; i++)
                colorLineCB->Items->Add(colorTexts[i]);

            fillColorCB->Items->Clear();
            for (int i = 0; i < colorTexts->Length; i++)
                fillColorCB->Items->Add(colorTexts[i]);

            // Подставляем значения по умолчанию
            mainForm.colorLineCB->Text = colorLine;
            mainForm.fillColorCB->Text = fillColor;

            if (transitionType->Contains("n"))
                transitionType1->Checked = true;
            else if (transitionType->Contains("p"))
                transitionType2->Checked = true;
            else
                throw new Exception("Неизвестный тип канала");*/

            mainForm.circleCheckBox.Checked = circle;
            mainForm.cxTextBox.Text = cx.ToString();
            mainForm.cyTextBox.Text = cy.ToString();

            mainForm.widthTextBox.Text = lineWidth.ToString();
            mainForm.mSizeTextBox.Text = mSize.ToString();

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

            if (int.TryParse(textBox.Text, out value))
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

        // Тут еще разбираться.. Забыл, как ресурсы пушить в код
        private void displayError()
        {
            using (var g = mainForm.mainPictureBox.CreateGraphics())
            {
                //fillColorText = fillColorCB->Text;
                //g.Clear(getColorByText(fillColorText));
            }
        }

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
                displayError();
                return;
            }

            int M = int.Parse(mainForm.cxTextBox.Text); // Рекомендуемое значение М=70 для вписывания

            // Точка центра, от которой идет масштабирование 256 и 244
            int Cx = 256;
            int Cy = 244;

            // Цвет заливки
            using (var g = mainForm.mainPictureBox.CreateGraphics())
            {
                /*String ^ fillColorText = mainForm.fillColorCB.Text;
                g.Clear(getColorByText(fillColorText));

                // Ручка: цвет и толщина
                String ^ colorLineText = colorLineCB->Text;
                Pen ^ pp = gcnew Pen(getBrushByText(colorLineText), Int32::Parse(widthTextBox->Text));

                //Отрисовка первого транзистора
                g->DrawLine(pp, 326, 314, 356, 314); // Центральная линия стрелки

                // Тут еще разбираться.. Стрелка поворот ее
                if (transitionType1->Checked)
                {
                    g->DrawLine(pp, 326, 314, 326 + (M / 4), 301 + (M / 4)); // Наклонная вверх стрелка
                    g->DrawLine(pp, 326, 314, 326 + (M / 4), 327 - (M / 4)); // Наклонная вниз стрелка
                }

                g->DrawLine(pp, 356, 314, 356, 355); // Вертикальная правая линия
                g->DrawLine(pp, 326, 355, 400, 355); // Верхняя линия
                g->DrawLine(pp, 326, 273, 400, 273); // Нижняя линия
                g->DrawLine(pp, 310, 355, 250, 355); // Нижняя левая линия
                g->DrawLine(pp, 310, 273, 310, 355); // Вертикальная левая лииния
                g->DrawLine(pp, 326, 324, 326, 304); // Штрих центральный
                g->DrawLine(pp, 326, 283, 326, 263); // Штрих верхний
                g->DrawLine(pp, 326, 365, 326, 345); // Штрих нижний

                // Нужно круг рисовать?
                if (mainForm.circleCheckBox.Checked)
                    g->DrawEllipse(pp, 256, 244, M * 2, M * 2); // Отрисовка круга*/
            }
        }
    }
}
