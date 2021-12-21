using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Configs.SubscribeNotificationEvent
{
    public class SubscribeNotificationEventCommand : IRequest<HttpResponseMessage>
    {
        public ConfigsRequest ConfigsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public SubscribeNotificationEventRequestBody SubscribeNotificationEventRequestBody { get; set; }
        public SubscribeNotificationEventCommand(ConfigsRequest configsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            SubscribeNotificationEventRequestBody subscribeNotificationEventRequestBody)
        {
            ConfigsRequest = configsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            SubscribeNotificationEventRequestBody = subscribeNotificationEventRequestBody;
        }
    }
}
