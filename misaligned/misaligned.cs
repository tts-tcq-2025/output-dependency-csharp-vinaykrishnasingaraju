using System;
using System.Diagnostics;
using System.Linq;

namespace MisalignedSpace {
    class Misaligned {
        static string[] GenerateColorMap() {
            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            string[] colorMap = new string[25];
            int index = 0;
            for (int i = 0; i < majorColors.Length; i++) {
                for (int j = 0; j < minorColors.Length; j++) {
                    colorMap[index++] = $"{i * 5 + j} | {majorColors[i]} | {minorColors[j]}";
                }
            }
            return colorMap;
        }

        static void TestColorMap() {
            string[] colorMap = GenerateColorMap();

            // Test: First and last entries
            Debug.Assert(colorMap[0] == "0 | White | Blue", "First entry is incorrect");
            Debug.Assert(colorMap[24] == "24 | Violet | Slate", "Last entry is incorrect");

            // Test: Total number of entries
            Debug.Assert(colorMap.Length == 25, "Color map does not contain 25 entries");

            // Test: Alignment and formatting
            foreach (var entry in colorMap) {
                Debug.Assert(entry.Contains("|"), "Entry does not contain '|' separator");
                string[] parts = entry.Split('|');
                Debug.Assert(parts.Length == 3, "Entry is not properly formatted with three parts");

                // Test: Index is numeric and matches the expected format
                int index;
                Debug.Assert(int.TryParse(parts[0].Trim(), out index), "Index is not a valid number");
                Debug.Assert(index >= 0 && index < 25, "Index is out of range");
            }

            // Test: No duplicate entries
            Debug.Assert(colorMap.Distinct().Count() == colorMap.Length, "Duplicate entries found in the color map");
        }

        static void Main(string[] args) {
            TestColorMap();
            Console.WriteLine("All is well (maybe!)");
        }
    }
}
