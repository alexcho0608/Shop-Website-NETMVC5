using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopSite.Server.Startup))]
namespace ShopSite.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
