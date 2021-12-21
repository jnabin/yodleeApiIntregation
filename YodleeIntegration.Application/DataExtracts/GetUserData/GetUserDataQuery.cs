using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.DataExtracts;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.DataExtracts.GetUserData
{
    public class GetUserDataQuery
        : IRequest<HttpResponseMessage>
    {
        public UserDataRequest GetUserDataRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetUserDataQuery(
            UserDataRequest getUserDataRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            GetUserDataRequest = getUserDataRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}