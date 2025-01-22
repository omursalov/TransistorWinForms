using TransistorWinForms.Data;

namespace TransistorWinForms.Models
{
    public class StateModel
    {
        private IDictionary<string, string> _data
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string ColorLine => _data[nameof(ColorLine)];
        public string FillColor => _data[nameof(FillColor)];
        public string TransitionType => _data[nameof(TransitionType)];
        public bool Circle => bool.Parse(_data[nameof(Circle)]);
        public int Cx => int.Parse(_data[nameof(Cx)]);
        public int Cy => int.Parse(_data[nameof(Cy)]);
        public int LineWidth => int.Parse(_data[nameof(LineWidth)]);
        public int MSize => int.Parse(_data[nameof(MSize)]);

        /// <summary>
        /// Работаем с State.ini при запуске проги
        /// </summary>
        public StateModel(string value)
        {
            var items = value.Split(Environment.NewLine);

            if (items.All(x => x.StartsWith(";")))
            {
                _data.TryAdd(nameof(Constants.ColorLine), Constants.ColorLine);
                _data.TryAdd(nameof(Constants.FillColor), Constants.FillColor);
                _data.TryAdd(nameof(Constants.TransitionType), Constants.TransitionType);
                _data.TryAdd(nameof(Constants.Circle), Constants.Circle.ToString());
                _data.TryAdd(nameof(Constants.Cx), Constants.Cx.ToString());
                _data.TryAdd(nameof(Constants.Cy), Constants.Cy.ToString());
                _data.TryAdd(nameof(Constants.LineWidth), Constants.LineWidth.ToString());
                _data.TryAdd(nameof(Constants.MSize), Constants.MSize.ToString());
            }
            else
            {
                foreach (var item in items)
                {
                    var arr = item.Split('=');
                    _data.Add(arr[0].Trim(), arr[1].Trim());
                }
            }
        }
    }
}