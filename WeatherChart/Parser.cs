using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChart
{
    #region Json entities

    internal class JsonResult
    {
        [JsonProperty("range_weather")]
        public OneDay[] RangeWeather { get; set; }
    }

    internal class OneDay
    {
        [JsonProperty("forecast")]
        public Dictionary<string, DayPart> Forecast { get; set; }
    }

    internal class DayPart
    {
        [JsonProperty("temperature")]
        public int Temperature { get; set; }
        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
    }

    #endregion

    internal class Parser
    {
        public static IEnumerable<int> Parse(string data)
        {
            var result = JsonConvert.DeserializeObject<JsonResult>(data);
            foreach (var day in result.RangeWeather)
            {
                foreach (var dayPart in day.Forecast)
                {
                    yield return dayPart.Value.Temperature;
                }
            }
        }
    }
}
