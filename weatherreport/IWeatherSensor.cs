using System;

namespace TemperatureSpace
{
    internal interface IWeatherSensor
    {
        double TemperatureInC();
        int Precipitation();
        int Humidity();
        int WindSpeedKMPH();

    }
}
