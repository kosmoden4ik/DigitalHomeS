using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DigitalHomeS.Startup))]
namespace DigitalHomeS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
