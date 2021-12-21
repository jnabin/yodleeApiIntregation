using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Verification.VerifyChallengeDeposit
{
    public class VerifyChallengeDepositCommand
        : IRequest<HttpResponseMessage>
    {
        public VerifyChallengeDepositRequest VerifyChallengeDepositRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public VerifyChallengeDepositRequestBody VerifyChallengeDepositRequestBody { get; set; }

        public VerifyChallengeDepositCommand(
            VerifyChallengeDepositRequest verifyChallengeDepositRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            VerifyChallengeDepositRequestBody verifyChallengeDepositRequestBody
        )
        {
            VerifyChallengeDepositRequest = verifyChallengeDepositRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            VerifyChallengeDepositRequestBody = verifyChallengeDepositRequestBody;
        }
    }
}