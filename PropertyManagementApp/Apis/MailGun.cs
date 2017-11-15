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

        public IRestResponse SendToSingleEmail(string email, string subject, string body, string from, string unit, string building)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"From {from} in unit {unit} of {building}\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }
        
        public IRestResponse SendFromMgrToResident(string residentEmail, string subject, string body, string resident)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", residentEmail);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"From Your Building Manager:\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendFromMgrToBuilding(string residentEmail, string subject, string body, string building)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", residentEmail);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"{building}\nFrom Your Building Manager:\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendFromResidentToResident(string residentEmail, string subject, string body, string resident, string buildingName, string unit, string sendersEmail)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", residentEmail);
            request.AddParameter("to", sendersEmail);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"From {resident}, in unit {unit} of {buildingName}:\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendFromResidentToBuilding(string residentEmail, string subject, string body, string building, string resident, string unit)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", residentEmail);
            request.AddParameter("subject", subject);
            request.AddParameter("text", $"To {building}\nFrom {resident} in unit {unit}:\n{body}");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendServiceRequest(string email, string name, string location, string unit, string typeOfService, string details, string urgency, string dateSubmitted)
        {
            string sender = "Mailgun <mailgun@mg.jenniferlocke.work>";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", email);
            request.AddParameter("subject", "Service Request");
            request.AddParameter("text", $"From {name} in {unit} of {location}\nType of Service: {typeOfService}\nDetails: {details}\nUrgency: {urgency}\nDate Submitted: {dateSubmitted}");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendAvailableUnitRequest(string name, string emailAddress, string subject, string body)
        {
            string sender = $"{name} {emailAddress}";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", Credentials.MailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.jenniferlocke.work", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", "hello@jenniferlocke.work");
            request.AddParameter("subject", subject);
            request.AddParameter("text", body);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}