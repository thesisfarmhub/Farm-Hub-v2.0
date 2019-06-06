using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmHub.Startup))]
namespace FarmHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
