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
    }
}