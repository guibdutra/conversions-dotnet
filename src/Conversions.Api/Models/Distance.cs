using System;

namespace Conversions.Api.Models;

public class Distance
{
    public double Miles { get; }
    public double Km { get; }

    public Distance(double milhas)
    {
        if (milhas <= 0)
        {
            throw new ArgumentException(
                "Distance in Miles must be greater than zero.");
        }

        Miles = milhas;
        Km = Math.Round(milhas * 1.609, 3);
    }
}