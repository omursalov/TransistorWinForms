﻿namespace TransistorWinForms.Data
{
    public static class Constants
    {
        public static string ColorLine = "черный";
        public static string FillColor = "белый";
        public static string TransitionType = "p-канальный";
        public static bool Circle = true;
        public static int Cx = 100;
        public static int Cy = 100;
        public static int LineWidth = 3;
        public static int MSize = 100;

        public static IDictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            { "черный", Color.Black }
        };
    }
}