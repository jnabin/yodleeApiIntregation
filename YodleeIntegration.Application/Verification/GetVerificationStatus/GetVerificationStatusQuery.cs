using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Verification.GetVerificationStatus
{
    public class GetVerificationStatusQuery
        : IRequest<HttpResponseMessage>
    {
        public VerificationStatusRequest GetVerificationStatusRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetVerificationStatusQuery(
            VerificationStatusRequest getVerificationStatusRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            GetVerificationStatusRequest = getVerificationStatusRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}