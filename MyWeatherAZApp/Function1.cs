using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MyWeatherAZApp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run([TimerTrigger("0 0 8 * * *")]TimerInfo myTimer, ILogger log) 
        {

            HttpClient client = new HttpClient();

            WeatherData weatherData = null;
            CoordinateData coordata = getLatLon();
            string weatherApiKey = getWeatherCredentials();

            string path = $"https://api.openweathermap.org/data/2.5/weather?lat={coordata.Latitude}&lon={coordata.Longitude}&appid={weatherApiKey}";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                weatherData = await response.Content.ReadAsAsync<WeatherData>();
                log.LogInformation($"{weatherData.coord.lat}");
            } 
            else
            {
                int status = (int)response.StatusCode;
                log.LogInformation(status.ToString());
            }
            
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private string getWeatherCredentials()
        {
            string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            return apiKey;
        }

        private CoordinateData getLatLon()
        {
            CoordinateData coordinateData = new CoordinateData()
            {
                Latitude = 33.985188,
                Longitude = -84.238419
            };

            return coordinateData;
        }
    }
}
