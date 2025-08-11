using System;
using System.Diagnostics;
using System.Linq;

namespace MisalignedSpace
{
    class Misaligned
    {
        private static readonly string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
        private static readonly string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };

        // Generates the color map as strings, consistent with the converted C++ logic
        public static string[] GenerateColorMap()
        {
            string[] colorMap = new string[majorColors.Length * minorColors.Length];
            int index = 0;

            for (int i = 0; i < majorColors.Length; i++)
            {
                for (int j = 0; j < minorColors.Length; j++)
                {
                    colorMap[index++] = $"{i * minorColors.Length + j} | {majorColors[i]} | {minorColors[j]}";
                }
            }

            return colorMap;
        }

        // Validates the generated color map
        public static void TestColorMap()
        {
            var colorMap = GenerateColorMap();

            // Check first entry
            Debug.Assert(colorMap[0] == "0 | White | Blue", "First entry is incorrect");

            // Check last entry
            Debug.Assert(colorMap[colorMap.Length - 1] == "24 | Violet | Slate", "Last entry is incorrect");

            // Check total number of entries
            Debug.Assert(colorMap.Length == 25, "Color map does not contain 25 entries");

            // Check each entry format and uniqueness
            foreach (var entry in colorMap)
            {
                Debug.Assert(entry.Contains("|"), "Entry does not contain '|' separator");

                string[] parts = entry.Split('|');
                Debug.Assert(parts.Length == 3, "Entry is not properly formatted with three parts");

                bool isIndexValid = int.TryParse(parts[0].Trim(), out int index);
                Debug.Assert(isIndexValid, "Index is not a valid number");
                Debug.Assert(index >= 0 && index < 25, "Index is out of range");
            }

            // Check for duplicates
            Debug.Assert(colorMap.Distinct().Count() == colorMap.Length, "Duplicate entries found in the color map");
        }

        static void Main(string[] args)
        {
            TestColorMap();
            Console.WriteLine("All is well (maybe!)");
        }
    }
}


