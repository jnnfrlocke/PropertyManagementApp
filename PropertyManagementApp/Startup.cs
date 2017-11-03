using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyManagementApp.Startup))]
namespace PropertyManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
