using TransistorWinForms.Data;

namespace TransistorWinForms.Models
{
    /// <summary>
    /// Убогий класс, но пока так..
    /// Вероятно, можно разбить на список линий..
    /// </summary>
    public class LinesDrawModels
    {
        /// <summary>
        /// Начало линии
        /// </summary>
        public float X1 { get; set; }
        public float Y1 { get; set; }

        /// <summary>
        /// Конец
        /// </summary>
        public float X2 { get; set; }
        public float Y2 { get; set; }

        private MainForm mainForm;

        public LinesDrawModels(MainForm mainForm)
            => this.mainForm = mainForm;

        /// <summary>
        /// Убого, самое жалкое место проги, но как есть..
        /// Кто шарит как сделать лучше?..
        /// TODO: переделать!
        /// </summary>
        public void Execute(Graphics graphics, Pen pen)
        {
            float lineM = Constants.SCALE * 2;
            float cx = float.Parse(mainForm.cxTextBox.Text);
            float cy = float.Parse(mainForm.cyTextBox.Text);
            float mSize = float.Parse(mainForm.mSizeTextBox.Text);
            float height = mainForm.mainPictureBox.Height;

            // Верхняя черточка
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE + (mSize / 2)) + height - (mSize / lineM);
            X2 = X1;
            Y2 = -(cy * Constants.SCALE + (mSize / 2)) + height + (mSize / lineM);
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Средняя черточка
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE) + height - (mSize / lineM);
            X2 = X1;
            Y2 = -(cy * Constants.SCALE) + height + (mSize / lineM);
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Нижняя черточка
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE - (mSize / 2)) + height - (mSize / lineM);
            X2 = X1;
            Y2 = -(cy * Constants.SCALE - (mSize / 2)) + height + (mSize / lineM);
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Черточка слева идущая вверх
            X1 = cx * Constants.SCALE - (mSize / 5);
            Y1 = -(cy * Constants.SCALE) + height - (mSize / Constants.SCALE * 2);
            X2 = X1;
            Y2 = -(cy * Constants.SCALE) + height + (mSize / Constants.SCALE * 2);
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Черточка слева идущая влево
            X1 = cx * Constants.SCALE - (mSize / 5);
            Y1 = -(cy * Constants.SCALE) + height + (mSize / Constants.SCALE * 2);
            X2 = cx * Constants.SCALE - (mSize);
            Y2 = Y1;
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Линия вправо от верхнего штриха
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE + (mSize / 2)) + height;
            X2 = cx * Constants.SCALE + (mSize);
            Y2 = Y1;
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Линия вправо от нижнего штриха
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE - (mSize / 2)) + height;
            X2 = cx * Constants.SCALE + (mSize);
            Y2 = Y1;
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Линия вправо от среднего штриха (короче на 10%)
            float shortLineLength = mSize * 0.9f; // Укорачиваем линию на 10%
            X1 = cx * Constants.SCALE;
            Y1 = -(cy * Constants.SCALE) + height;
            X2 = cx * Constants.SCALE + shortLineLength;
            Y2 = Y1;
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Вертикальная линия вниз от конца короткой горизонтальной линии
            X1 = cx * Constants.SCALE + shortLineLength; // Конец короткой линии
            Y1 = -(cy * Constants.SCALE) + height; // Начало вертикальной линии (на уровне среднего штриха)
            X2 = X1; // Вертикальная линия, поэтому X не меняется
            Y2 = -(cy * Constants.SCALE - (mSize / 2)) + height; // Конец вертикальной линии (на уровне нижнего штриха)
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Наклонные стрелки к горизонтальной линии от среднего штриха
            float arrowLength = shortLineLength * 0.7f; // Длина стрелок (70% от длины линии)
            float arrowAngle = 10 * (float)Math.PI / 180; // Угол наклона стрелок (45 градусов)

            // Левая стрелка (наклон вверх)
            X1 = cx * Constants.SCALE; // Начало стрелки (левая часть линии)
            Y1 = -(cy * Constants.SCALE) + height; // Начало стрелки (на уровне среднего штриха)
            X2 = X1 + arrowLength * (float)Math.Cos(arrowAngle); // Конец стрелки (наклон вверх)
            Y2 = Y1 - arrowLength * (float)Math.Sin(arrowAngle); // Конец стрелки (наклон вверх)
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Правая стрелка (наклон вниз)
            X1 = cx * Constants.SCALE; // Начало стрелки (левая часть линии)
            Y1 = -(cy * Constants.SCALE) + height; // Начало стрелки (на уровне среднего штриха)
            X2 = X1 + arrowLength * (float)Math.Cos(arrowAngle); // Конец стрелки (наклон вниз)
            Y2 = Y1 + arrowLength * (float)Math.Sin(arrowAngle); // Конец стрелки (наклон вниз)
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Зеркальная стрелка (начинается из правой части линии)
            X1 = cx * Constants.SCALE + shortLineLength; // Начало стрелки (правая часть линии)
            Y1 = -(cy * Constants.SCALE) + height; // Начало стрелки (на уровне среднего штриха)
            X2 = X1 - arrowLength * (float)Math.Cos(arrowAngle); // Конец стрелки (наклон вверх)
            Y2 = Y1 - arrowLength * (float)Math.Sin(arrowAngle); // Конец стрелки (наклон вверх)
            graphics.DrawLine(pen, X1, Y1, X2, Y2);

            // Зеркальная стрелка (наклон вниз)
            X1 = cx * Constants.SCALE + shortLineLength; // Начало стрелки (правая часть линии)
            Y1 = -(cy * Constants.SCALE) + height; // Начало стрелки (на уровне среднего штриха)
            X2 = X1 - arrowLength * (float)Math.Cos(arrowAngle); // Конец стрелки (наклон вниз)
            Y2 = Y1 + arrowLength * (float)Math.Sin(arrowAngle); // Конец стрелки (наклон вниз)
            graphics.DrawLine(pen, X1, Y1, X2, Y2);
        }
    }
}