using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Application.Startup))]
namespace Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
