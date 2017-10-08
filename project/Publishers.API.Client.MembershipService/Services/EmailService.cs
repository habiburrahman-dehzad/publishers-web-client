using Microsoft.AspNet.Identity;
using Publishers.API.Client.MembershipService.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace Publishers.API.Client.MembershipService.Services
{
    public interface IEmailService : IIdentityMessageService
    {

    }

    public class EmailService : IEmailService
    {
        IRestRequest _restRequest;
        IRestClient _restClient;
        IConfiguration _appConfiguration;
        IAuthenticator _authenticator;

        public EmailService(IRestRequest restRequest, IRestClient restClient, IConfiguration appConfiguration, IAuthenticator authenticator)
        {
            _restRequest = restRequest;
            _restClient = restClient;
            _appConfiguration = appConfiguration;
            _authenticator = authenticator;
        }

        public Task SendAsync(IdentityMessage message)
        {
            SendRegistrationMessage(message);
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public void PrepareRestClientAndRequest(string destination, string subject, string body)
        {
            _restClient.BaseUrl = new Uri("https://api.mailgun.net/v2");
            _restClient.Authenticator = _authenticator;

            _restRequest.AddParameter("domain", _appConfiguration.DomainForApiKey, ParameterType.UrlSegment);
            _restRequest.Resource = "{domain}/messages";
            _restRequest.AddParameter("from", _appConfiguration.FromName + " <" + _appConfiguration.FromEmail + ">");
            _restRequest.AddParameter("to", "User <" + destination + ">");
            _restRequest.AddParameter("subject", subject);
            _restRequest.AddParameter("html", body);
            _restRequest.Method = Method.POST;
        }
        public IRestResponse SendRegistrationMessage(IdentityMessage message)
        {
            PrepareRestClientAndRequest(message.Destination, message.Subject, message.Body);

            IRestResponse executor = _restClient.Execute(_restRequest);

            return executor;
        }
    }
}
