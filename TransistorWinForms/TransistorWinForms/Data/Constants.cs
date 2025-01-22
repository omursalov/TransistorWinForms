using System.Drawing.Imaging;

namespace TransistorWinForms.Data
{
    public static class Constants
    {
        #region Значения по умолчанию
        public static string ColorLine = "черный";
        public static string FillColor = "белый";
        public static string TransitionType = "p-канальный";
        public static bool Circle = true;
        public static int Cx = 100;
        public static int Cy = 100;
        public static int LineWidth = 3;
        public static int MSize = 100;
        #endregion

        #region Лимиты по textBoxes
        public static IDictionary<string, int> IntTextBoxLimits
            = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "cxTextBox", 100 },
            { "cyTextBox", 100 },
            { "widthTextBox", 5 },
            { "mSizeTextBox", 100 }
        };
        #endregion

        public static IDictionary<string, Color> Colors =
            new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
        {
            { "черный", Color.Black },
            { "белый", Color.White },
            { "зеленый", Color.Green },
            { "красный", Color.Red },
            { "синий", Color.Blue }
        };

        public static string STATE_RESOURCE_NAME = "TransistorWinForms.Data.State.ini";
        public static string TEMP_DRAW_RESOURCE_NAME = "TransistorWinForms.Content.temp.png";

        public static IDictionary<string, ImageFormat> ImageFileExtensions =
            new Dictionary<string, ImageFormat>(StringComparer.OrdinalIgnoreCase)
        {
            { "png", ImageFormat.Png },
            { "gif", ImageFormat.Gif },
            { "bmp", ImageFormat.Bmp },
            { "jpeg", ImageFormat.Jpeg }
        };
    }
}