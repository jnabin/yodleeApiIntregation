using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Accounts.EvaluateAddress
{
    public class EvaluateAddressCommand : IRequest<HttpResponseMessage>
    {
        public EvaluateAddressRequest EvaluateAddressRequest { get; set; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public EvaluateAddressRequestBody EvaluateAddressRequestBody { get; set; }

        public EvaluateAddressCommand(
            EvaluateAddressRequest evaluateAddressRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            EvaluateAddressRequestBody evaluateAddressRequestBody
            )
        {
            EvaluateAddressRequest = evaluateAddressRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            EvaluateAddressRequestBody = evaluateAddressRequestBody;
        }
    }
}
