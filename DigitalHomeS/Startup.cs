using DigitalHomeS.Models;
using DigitalHomeS.Services;
using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(DigitalHomeS.Startup))]
namespace DigitalHomeS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
           
        }
        public void ConfigurationServices(ServiceCollection services)
        {
            
          //  services.Add(<IChangeStatuse, ChangeStatus>(DeviceModels));
        }
    }
}
