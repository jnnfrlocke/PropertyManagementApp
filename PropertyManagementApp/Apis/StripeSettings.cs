using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Apis
{
    public class StripeSettings
    {
        public class StripeApiSettings
        {
            public string StripeSecretKey { get; set; }
            public string StripePublishableKey { get; set; }
        }
    }
}