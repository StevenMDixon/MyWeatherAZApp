using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyWeatherAZApp
{
    public class WeatherProvider
    {
        private HttpClient client;

        public WeatherProvider() 
        {
            this.client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData()
        {
            WeatherData weatherData = null;
            CoordinateData coordata = getLatLon();
            string weatherApiKey = getWeatherCredentials();

            string path = $"https://api.openweathermap.org/data/2.5/weather?lat={coordata.Latitude}&lon={coordata.Longitude}&appid={weatherApiKey}&units=imperial";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                weatherData = await response.Content.ReadAsAsync<WeatherData>();
            }
            return weatherData;
        }

        private string getWeatherCredentials()
        {
            return Environment.GetEnvironmentVariable("WEATHER_API_KEY");
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
