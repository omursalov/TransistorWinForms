using TransistorWinForms.Data;

namespace TransistorWinForms.Models
{
    public class StateModel
    {
        public string ColorLine { get; private set; }
        public string FillColor { get; private set; }
        public string TransitionType { get; private set; }
        public bool Circle { get; private set; }
        public int Cx { get; private set; }
        public int Cy { get; private set; }
        public int LineWidth { get; private set; }
        public int MSize { get; private set; }

        public StateModel(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                ColorLine = Constants.ColorLine;
                FillColor = Constants.FillColor;
                TransitionType = Constants.TransitionType;
                Circle = Constants.Circle;
                Cx = Constants.Cx;
                Cy = Constants.Cy;
                LineWidth = Constants.LineWidth;
                MSize = Constants.MSize;
            }
            else
            {

            }
        }
    }
}