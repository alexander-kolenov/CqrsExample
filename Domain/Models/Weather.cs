using System.ComponentModel;

namespace Domain.Models;

public class Weather
{
   [Description("Temperature in degrees Celsius")]
   public double Temperature { get; set; }

   //public double Humidity { get; set; }

   //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

   // public string? Summary { get; set; }
}
