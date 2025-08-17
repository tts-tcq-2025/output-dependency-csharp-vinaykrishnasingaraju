using System;
using System.Text;

namespace misalignedspace
{
    internal struct ColorPair
    {
        public int Index;
        public string Major;
        public string Minor;
    }

    public static class Misaligned
    {
        private static readonly string[] MajorColors = { "White", "Red", "Black", "Yellow", "Violet" };
        private static readonly string[] MinorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };

        // Hidden buggy function
        private static ColorPair[] GenerateColorMap_Buggy()
        {
            var colorMap = new ColorPair[MajorColors.Length * MinorColors.Length];
            int count = 0;

            for (int i = 0; i < MajorColors.Length; i++)
            {
                for (int j = 0; j < MinorColors.Length; j++)
                {
                    colorMap[count].Index = count + 1;
                    colorMap[count].Major = MajorColors[i];
                    colorMap[count].Minor = MinorColors[i]; // <-- BUG
                    count++;
                }
            }

            return colorMap;
        }

        // Fixed function
        private static ColorPair[] GenerateColorMap_Fixed()
        {
            var colorMap = new ColorPair[MajorColors.Length * MinorColors.Length];
            int count = 0;

            for (int i = 0; i < MajorColors.Length; i++)
            {
                for (int j = 0; j < MinorColors.Length; j++)
                {
                    colorMap[count].Index = count + 1;
                    colorMap[count].Major = MajorColors[i];
                    colorMap[count].Minor = MinorColors[j]; // FIXED
                    count++;
                }
            }

            return colorMap;
        }

        // Shared formatter
        private static string GenerateOutputString(ColorPair[] colorMap)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in colorMap)
            {
                sb.AppendLine($"{pair.Index} | {pair.Major} | {pair.Minor}");
            }
            return sb.ToString();
        }

        // Public entry points (for testing both versions)
        public static int PrintColorMap_Buggy(Action<string> outputFunc)
        {
            var colorMap = GenerateColorMap_Buggy();
            var output = GenerateOutputString(colorMap);
            outputFunc(output);
            return colorMap.Length;
        }

        public static int PrintColorMap_Fixed(Action<string> outputFunc)
        {
            var colorMap = GenerateColorMap_Fixed();
            var output = GenerateOutputString(colorMap);
            outputFunc(output);
            return colorMap.Length;
        }
    }
}

