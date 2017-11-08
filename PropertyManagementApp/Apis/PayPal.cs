using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace PropertyManagementApp.Apis
{
    public class PayPal
    {
        public void StartPaypal()
        {
            // Get a reference to the config
            var config = ConfigManager.Instance.GetProperties();

            // Use OAuthTokenCredential to request an access token from PayPal
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(Credentials.PayPalApiKey);

            var payment = Payment.Get(apiContext, "PAY-0XL713371A312273YKE2GCNI");
        }

        

    }
}