using Owin;
using Publishers.API.Client.MembershipService.App_Start;

namespace Publishers.API.Client.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            IdentityConfig.ConfigAuth(app);
        }
    }
}