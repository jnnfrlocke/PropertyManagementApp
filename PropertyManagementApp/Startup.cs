using Microsoft.Owin;
using Owin;
using PropertyManagementApp.Apis;
using Stripe;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(PropertyManagementApp.Startup))]
namespace PropertyManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            StripeConfiguration.SetApiKey(Credentials.StripeSecretKey);
        }

        //public void ConfigureServices()
        //{
        //    services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
        //}
    }
}
