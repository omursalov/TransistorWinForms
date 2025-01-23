using TransistorWinForms.Data;

namespace TransistorWinForms.Models
{
    public class CircleDrawModel
    {
        /// <summary>
        /// X и Y - координаты центра
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Ширина и длинна квадрата,
        /// в который вписан круг
        /// </summary>
        public int Width { get; set; }
        public int Height { get; set; }

        private MainForm mainForm;

        public CircleDrawModel(MainForm mainForm)
            => this.mainForm = mainForm;

        public void Execute(Graphics graphics, Pen pen)
        {
            var cx = int.Parse(mainForm.cxTextBox.Text);
            var cy = int.Parse(mainForm.cyTextBox.Text);
            var mSize = int.Parse(mainForm.mSizeTextBox.Text);
            var height = mainForm.mainPictureBox.Height;
            X = cx * Constants.SCALE - mSize;
            Y = -(cy * Constants.SCALE + mSize) + height;
            Width = mSize * 2;
            Height = mSize * 2;
            graphics.DrawEllipse(pen, X, Y, Width, Height);
        }
    }
}