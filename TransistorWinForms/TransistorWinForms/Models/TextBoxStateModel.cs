namespace TransistorWinForms.Models
{
    public class TextBoxStateModel
    {
        public string Name { get; private set; }
        public string Text { get; private set; }
        public int SelectionStart { get; private set; }

        public TextBoxStateModel(TextBox textBox, int needSelectionStart)
        {
            Name = textBox.Name;
            Text = textBox.Text;
            SelectionStart = needSelectionStart;
        }

        public void Set(string text, int selectionStart)
        {
            Text = text;
            SelectionStart = selectionStart;
        }

        public void Set(int selectionStart)
            => SelectionStart = selectionStart;
    }
}
