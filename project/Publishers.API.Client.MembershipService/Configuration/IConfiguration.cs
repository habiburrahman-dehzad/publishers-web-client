using System;

namespace Publishers.API.Client.MembershipService.Configuration
{
    public interface IConfiguration
    {
        String EmailApiKey { get; }

        String DomainForApiKey { get; }

        String FromName { get; }

        String FromEmail { get; }
    }
}