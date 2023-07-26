using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MyWeatherAZApp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run([TimerTrigger("0 0 8 * * 1-5")]TimerInfo myTimer, ILogger log) 
        {
            WeatherProvider weatherProvider = new();
            EmailProvider emailProvider = new(); 

            WeatherData weather = await weatherProvider.GetWeatherData();

            string emailBody = FormatWeatherDataToEmail(weather);

            await emailProvider.SendEmail(emailBody);

            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private string FormatWeatherDataToEmail(WeatherData weatherData) {
            string emailBody = EmailTemplate.GetEmailBody(weatherData);
            return emailBody;
        }
    }
}
