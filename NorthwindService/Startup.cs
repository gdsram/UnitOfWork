using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindService.Startup))]
namespace NorthwindService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
