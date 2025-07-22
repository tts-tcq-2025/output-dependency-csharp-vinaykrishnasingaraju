
namespace TemperatureSpace
{    /// <summary>
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
}
