using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Publishers.API.Client.Web.Startup))]
namespace Publishers.API.Client.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
