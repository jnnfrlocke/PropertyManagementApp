using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Apis
{
    public class MailGun
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SendSimpleMessage().Content.ToString());
        }

        public IRestResponse SendSimpleMessage()
        {
            string email = "jen@jllocke.com"; // may need to send this in as a parameter

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api", "key-8809769e2ac9045d78fd4e9ef51fe639");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org>");
            request.AddParameter("to", email);
            //request.AddParameter("to", "Jen Locke <jenlocke643@msn.com>");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomeness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }


        //public static RestResponse SendSimpleMessage()
        //{
        //    RestClient client = new RestClient();
        //    client.BaseUrl = "https://api.mailgun.net/v3";
        //    client.Authenticator =
        //    new HttpBasicAuthenticator("api",
        //                              "key-8809769e2ac9045d78fd4e9ef51fe639");
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", "sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org", ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox42d69fe14b4c419d8b540852c478490b.mailgun.org>");
        //    request.AddParameter("to", "Jennifer Locke <jnnfrlocke@gmail.com>");
        //    request.AddParameter("subject", "Hello Jennifer Locke");
        //    request.AddParameter("text", "Congratulations Jennifer Locke, you just sent an email with Mailgun!  You are truly awesome!");
        //    request.Method = Method.POST;
        //    return client.Execute(request);
        //}

        // You can see a record of this email in your logs: https://mailgun.com/app/logs .

        // You can send up to 300 emails/day from this sandbox server.
        // Next, you should add your own domain so you can send 10,000 emails/month for free.
    }
}