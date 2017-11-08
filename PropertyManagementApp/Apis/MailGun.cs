using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PropertyManagementApp.Apis
{
    public class MailGun
    {
        public MailGun()
        {
        }

        private string _mailGunApiKey = Properties.Settings.Default.MailGunApiKey;

        public string MailGunApiKey => _mailGunApiKey;

        public IRestResponse SendToSingleEmail(string email, string subject, string body, string from, string unit, string building)
        {
            string sender = "Mailgun Sandbox <postmaster@sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"From {from} in unit {unit} of {building}\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }
        
        // You can see a record of this email in your logs: https://mailgun.com/app/logs .

        // You can send up to 300 emails/day from this sandbox server.
        // Next, you should add your own domain so you can send 10,000 emails/month for free.
    }
}