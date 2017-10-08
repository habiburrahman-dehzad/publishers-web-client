using System.Web.Mvc;

namespace Publishers.API.Client.MembershipService.App_Start
{
    public static class DependencyResolverConfig
    {
        public static IDependencyResolver Current { get; set; }
    }
}
