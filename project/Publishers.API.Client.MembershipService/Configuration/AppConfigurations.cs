using System;

namespace Publishers.API.Client.MembershipService.Configuration
{
    public class AppConfigurations : IConfiguration
    {
        Lazy<string> _lazyEmailApiKey;
        Lazy<string> _lazyDomainForApiKey;
        Lazy<string> _lazyFromName;
        Lazy<string> _lazyFromEmail;
        IConfigurationManager _configurationManager;

        public AppConfigurations(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
            _lazyEmailApiKey = new Lazy<string>(() => _configurationManager.AppSettings["EmailApiKey"]);
            _lazyDomainForApiKey = new Lazy<string>(() => _configurationManager.AppSettings["DomainForApiKey"]);
            _lazyFromName = new Lazy<string>(() => _configurationManager.AppSettings["FromName"]);
            _lazyFromEmail = new Lazy<string>(() => _configurationManager.AppSettings["TechnicalEmail"]);
        }

        public string EmailApiKey => _lazyEmailApiKey.Value;

        public string DomainForApiKey => _lazyDomainForApiKey.Value;

        public string FromName => _lazyFromName.Value;

        public string FromEmail => _lazyFromEmail.Value;
    }
}