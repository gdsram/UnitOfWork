using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitOfWork.Startup))]
namespace UnitOfWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
