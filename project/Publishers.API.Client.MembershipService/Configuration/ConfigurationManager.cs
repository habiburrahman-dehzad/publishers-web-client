using System.Collections.Specialized;

namespace Publishers.API.Client.MembershipService.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        public NameValueCollection AppSettings
        {
            get { return System.Configuration.ConfigurationManager.AppSettings; }
        }
    }
}