using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChart
{
    internal class WeatherService
    {
        private static string Url { get { return "https://weather.rambler.ru/api/v3/ndays/?n=7&url_path=v-izhevske"; } }
        public static string GetData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            return client.SendAsync(request).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
