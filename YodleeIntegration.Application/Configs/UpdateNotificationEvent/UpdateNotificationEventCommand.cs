using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Configs.UpdateNotificationEvent
{
    public class UpdateNotificationEventCommand : IRequest<HttpResponseMessage>
    {
        public ConfigsRequest ConfigsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public UpdateNotificationEventRequestBody UpdateNotificationEventRequest { get; set; }
        public UpdateNotificationEventCommand(ConfigsRequest configsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            UpdateNotificationEventRequestBody updateNotificationEventRequestBody)
        {
            ConfigsRequest = configsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            UpdateNotificationEventRequest = updateNotificationEventRequestBody;
        }
    }
}
