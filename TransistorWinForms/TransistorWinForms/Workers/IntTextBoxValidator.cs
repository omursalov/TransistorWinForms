using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class IntTextBoxValidator
    {
        private bool _processedFlag = false;

        private IList<TextBoxStateModel> _states = new List<TextBoxStateModel>();

        public IntTextBoxValidator(IList<TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                var limit = Constants.IntTextBoxLimits[textBox.Name];
                _states.Add(new TextBoxStateModel(textBox, limit.ToString().Length));
            }
        }

        /// <summary>
        /// Только цифры
        /// </summary>
        public bool KeyPressCheck(KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        /// <summary>
        /// Не проверяю в словаре наличие key,
        /// полагаем, что все настроено уже.. В будущем можно сделать.
        /// Сюда может зайти 2 раза, поэтому используем _processedFlag.
        /// </summary>
        public void ProcessLimit(TextBox textBox, EventArgs e)
        {
            var state = _states
                .FirstOrDefault(x => x.Name.Equals(textBox.Name, StringComparison.OrdinalIgnoreCase));

            if (state == null || textBox.Text == string.Empty)
                return;

            if (_processedFlag)
            {
                _processedFlag = false;
                if (state.SelectionStart == 0)
                    state.Set(Constants.IntTextBoxLimits[textBox.Name].ToString().Length);
                textBox.SelectionStart = state.SelectionStart;
                return;
            }

            var value = int.Parse(textBox.Text);

            if (value > Constants.IntTextBoxLimits[textBox.Name])
            {
                _processedFlag = true;
                textBox.Text = state.Text;
            }
            else
                state.Set(textBox.Text, textBox.SelectionStart);
        }
    }
}