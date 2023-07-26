using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace MyWeatherAZApp
{
    public class EmailProvider
    {
        private MailjetClient client;

        public EmailProvider()
        {
            this.client = new MailjetClient(Environment.GetEnvironmentVariable("MJ_APIKEY_PUBLIC"), Environment.GetEnvironmentVariable("MJ_APIKEY_PRIVATE"));
        }

        public async Task SendEmail(string emailBody)
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "StevenDixon@steven-dixon.com")
               .Property(Send.FromName, "Steven's Daily Weather")
               .Property(Send.Subject, $"Todays Weather: {DateTime.Now}")
               .Property(Send.HtmlPart, $"{emailBody}")
               .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", "StevenDixon1128@gmail.com"}
                 }
                   });

            await this.client.PostAsync(request);
        }
    }
}
