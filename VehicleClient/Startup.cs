using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleClient.Startup))]
namespace VehicleClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
