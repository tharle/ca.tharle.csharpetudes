using System;
using MyUtilities;

namespace MyFirstProgram
{
    class CheckConfort
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Where should we go in May?");
            WeatherUtilities.Report("San Francisco", WeatherUtilities.FahrenheiToCelsius(65), 73);
            WeatherUtilities.Report("Québec", 23, 80); 
        }
    }
}