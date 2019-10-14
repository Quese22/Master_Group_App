using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterGroupWebApp.Startup))]
namespace MasterGroupWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
