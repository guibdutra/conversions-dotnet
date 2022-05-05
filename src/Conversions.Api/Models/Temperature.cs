using System;

namespace Conversions.Api.Models;

public class Temperature
{
    public double Fahrenheit { get; init; }
    public double Celsius { get; init; }
    public double Kelvin { get; init; }

    public Temperature(double temperaturaFahrenheit)
    {
        if (temperaturaFahrenheit < -459.67)
        {
            throw new ArgumentException(
                $"Invalid temperature on the Fahrenheit scale: {temperaturaFahrenheit}");
        }

        Fahrenheit = temperaturaFahrenheit;
        Celsius = Math.Round((temperaturaFahrenheit - 32.0) / 1.8, 2);
        Kelvin = Math.Round(Celsius + 273.15, 2);
    }
}