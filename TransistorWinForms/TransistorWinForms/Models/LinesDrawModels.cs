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
        }
    }
}