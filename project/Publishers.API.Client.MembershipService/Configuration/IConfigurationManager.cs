using System.Collections.Specialized;

namespace Publishers.API.Client.MembershipService.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
    }
}
