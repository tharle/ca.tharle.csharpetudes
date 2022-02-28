using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtilities
{
    class WeatherUtilities
    {
        static public float FahrenheiToCelsius(float temperatureF)
        {
            return (temperatureF - 32) / 1.8f;
        }

        static public float CelsiusToFahrenhei(float temperatureC)
        {
            return temperatureC * 1.8f + 32;
        }

        /// <summary>
        ///  The hider is de index, the lower the confort.
        /// </summary>
        /// <param name="temperatureF"></param>
        /// <param name="humidityPercent"></param>
        /// <returns></returns>
        static private float ConfortIndex(float temperatureF, float humidityPercent) 
        {
            // Probablu not a very reliable formula
            return (temperatureF + humidityPercent) / 4; ;
        }

        static public void Report(string location, float temperatureC, float humidity) 
        {
            var temperatureF = CelsiusToFahrenhei(temperatureC);
            Console.WriteLine($"Confort Index for {location}: {ConfortIndex(temperatureF, humidity)}");
        }
    }
}
