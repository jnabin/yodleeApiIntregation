using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.DataExtracts;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.DataExtracts.GetEvents
{
    public class GetEventsQuery
        : IRequest<HttpResponseMessage>
    {
        public EventsRequest GetEventsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetEventsQuery(
            EventsRequest getEventsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            GetEventsRequest = getEventsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}