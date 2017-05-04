using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FourSeasonsWebShop.Startup))]
namespace FourSeasonsWebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
