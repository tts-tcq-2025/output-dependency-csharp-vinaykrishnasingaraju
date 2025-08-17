using System;

namespace misalignedspace
{
    class MisalignedTest
    {
        private static string capturedOutput = "";

        private static void CaptureOutput(string text)
        {
            capturedOutput = text;
        }

        private static readonly string ExpectedOutput =
            "1 | White | Blue\n" +
            "2 | White | Orange\n" +
            "3 | White | Green\n" +
            "4 | White | Brown\n" +
            "5 | White | Slate\n" +
            "6 | Red | Blue\n" +
            "7 | Red | Orange\n" +
            "8 | Red | Green\n" +
            "9 | Red | Brown\n" +
            "10 | Red | Slate\n" +
            "11 | Black | Blue\n" +
            "12 | Black | Orange\n" +
            "13 | Black | Green\n" +
            "14 | Black | Brown\n" +
            "15 | Black | Slate\n" +
            "16 | Yellow | Blue\n" +
            "17 | Yellow | Orange\n" +
            "18 | Yellow | Green\n" +
            "19 | Yellow | Brown\n" +
            "20 | Yellow | Slate\n" +
            "21 | Violet | Blue\n" +
            "22 | Violet | Orange\n" +
            "23 | Violet | Green\n" +
            "24 | Violet | Brown\n" +
            "25 | Violet | Slate\n";

        private static void ReportTestResult(string testName, bool passed)
        {
            Console.WriteLine($"--- {testName} ---");
            if (passed)
            {
                Console.WriteLine("TEST PASSED ");
            }
            else
            {
                Console.WriteLine("TEST FAILED ");
                Console.WriteLine("\n--- Actual Output ---");
                Console.WriteLine(capturedOutput);
                Console.WriteLine("\n--- Expected Output ---");
                Console.WriteLine(ExpectedOutput);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Run buggy version
            capturedOutput = "";
            Misaligned.PrintColorMap_Buggy(CaptureOutput);
            bool passedBuggy = (capturedOutput == ExpectedOutput);
            ReportTestResult("Buggy Implementation", passedBuggy);

            // Run fixed version
            /*capturedOutput = "";
            Misaligned.PrintColorMap_Fixed(CaptureOutput);
            bool passedFixed = (capturedOutput == ExpectedOutput);
            ReportTestResult("Fixed Implementation", passedFixed);
            */
        }
    }
}
