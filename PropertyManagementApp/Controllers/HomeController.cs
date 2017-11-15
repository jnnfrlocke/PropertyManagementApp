using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using PropertyManagementApp.Apis;
using Stripe;


namespace PropertyManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Stripe charge
        public ActionResult Error()
        {
            return View();
        }
        
        [Authorize(Roles = "Resident")]
        public ActionResult PayRent(string stripeEmail, string stripeToken, int? amount)
        {
            StripeConfiguration.SetApiKey(Credentials.StripeSecretKey);
            //var token = model.Token;

            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            int? paymentAmount = amount * 100;

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken,
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {

                Amount = amount,// 500 charges $5.00
                Description = "Payment Amount",
                Currency = "usd",
                CustomerId = customer.Id,
                ReceiptEmail = customer.Email,
                //SourceTokenOrExistingSourceId = 
            });
            return View();
        }
        
        [Authorize(Roles = "Resident")]
        public ActionResult Charge()
        {
            return View();
        }
        // End Stripe
        
        public ActionResult Maps()
        {
            GoogleMaps newMap = new GoogleMaps();
            newMap.GetFormattedUrl();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}