using System;

namespace MyFirstProgram
{
    class Temperature 
    {
        public static float FahrenheiToCelsius(float temperatureF)
        {
            return (temperatureF - 32) / 1.8f;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! " + Temperature.FahrenheiToCelsius(350));
        }
    }
}