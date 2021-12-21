using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.VerifyAccounts
{
    public class VerifyAccountCommand : IRequest<HttpResponseMessage>
    {
        public VerifyAccountRequest VerifyAccountRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public VerifyAccountRequestBody VerifyAccountRequestBody { get; set; }

        public VerifyAccountCommand(VerifyAccountRequest verifyAccountRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken, VerifyAccountRequestBody verifyAccountRequestBody)
        {
            VerifyAccountRequest = verifyAccountRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            VerifyAccountRequestBody = verifyAccountRequestBody;
        }
    }
}
