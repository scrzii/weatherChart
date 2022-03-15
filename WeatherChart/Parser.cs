using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChart
{
    internal class Parser
    {
        public static IEnumerable<int> Parse(string data)
        {
            return new List<int> { -5, 10, -18, 28, -16, 6, 1, -30, 6, 4 };
        }
    }
}
