namespace TemperatureSpace
{
    /// <summary>
    /// This is a stub for a weather sensor. For the sake of testing 
    /// we create a stub that generates weather data and allows us to
    /// test the other parts of this application in isolation
    /// without needing the actual Sensor during development
    /// </summary>
    internal class SensorStub : IWeatherSensor
    {
        int IWeatherSensor.Humidity()
        {
            return 72;
        }

        int IWeatherSensor.Precipitation()
        {
            return 70;
        }

        double IWeatherSensor.TemperatureInC()
        {
            return 26;
        }

        int IWeatherSensor.WindSpeedKMPH()
        {
            return 52;
        }
    }

    internal class HighPrecipitationStub : IWeatherSensor
    {
        int IWeatherSensor.Humidity() {
            return 80;
        }

        int IWeatherSensor.Precipitation() {
            return 70;
        }

        double IWeatherSensor.TemperatureInC() {
            return 26;
        }

        int IWeatherSensor.WindSpeedKMPH() {
            return 10; 
        }
    }

    internal class LowPrecipitationStub : IWeatherSensor {
        int IWeatherSensor.Humidity() {
            return 50;
        }

        int IWeatherSensor.Precipitation() {
            return 10; 
        }

        double IWeatherSensor.TemperatureInC() {
            return 30; 
        }

        int IWeatherSensor.WindSpeedKMPH() {
            return 5; 
        }
    }

    internal class HighWindLowPrecipitationStub : IWeatherSensor {
        int IWeatherSensor.Humidity() {
            return 40; // Low humidity
        }

        int IWeatherSensor.Precipitation() {
            return 5; // Low precipitation
        }

        double IWeatherSensor.TemperatureInC() {
            return 20; // Moderate temperature
        }

        int IWeatherSensor.WindSpeedKMPH() {
            return 80; // High wind speed
        }
    }
}
