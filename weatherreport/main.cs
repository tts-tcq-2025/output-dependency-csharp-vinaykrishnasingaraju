using System;
using System.Diagnostics;

namespace TemperatureSpace
{
    class Weather
    {
        internal static string Report(IWeatherSensor sensor)
        {
            int precipitation = sensor.Precipitation();
            // precipitation < 20 is a sunny day
            string report = "Sunny Day";

            if (sensor.TemperatureInC() > 25)
            {
                if (precipitation >= 20 && precipitation < 60)
                    report = "Partly Cloudy";
                else if (sensor.WindSpeedKMPH() > 50)
                    report = "Alert, Stormy with heavy rain";
            }
            return report;
        }

        private static void TestRainy()
        {
            IWeatherSensor sensor = new SensorStub();
            string report = Weather.Report(sensor);
            Debug.Assert(report.Contains("rain"));
        }

        private static void TestHighPrecipitation()
        {
            IWeatherSensor sensor = new HighPrecipitationStub();
            string report = Weather.Report(sensor);
            Debug.Assert(report.Contains("rain"));
        }

        private static void TestLowPrecipitation()
        {
            IWeatherSensor sensor = new LowPrecipitationStub();
            string report = Weather.Report(sensor);
            Debug.Assert(report.Contains("Sunny"));
        }

        private static void TestHighWindLowPrecipitation()
        {
            IWeatherSensor sensor = new HighWindLowPrecipitationStub();
            string report = Weather.Report(sensor);
            Debug.Assert(report.Contains("windy")); // Strengthened test to expose the bug
        }

        static void Main(string[] args)
        {
            TestRainy();
            TestHighPrecipitation();
            TestLowPrecipitation();
            TestHighWindLowPrecipitation();
            Console.WriteLine("All is well (maybe!)");
        }
    }
}

