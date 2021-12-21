using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Verification.InitiaiteMatchingServiceandChallengeDeposit
{
    public class InitializeChallengeDepositQuery
        : IRequest<HttpResponseMessage>
    {
        public InitializeChallengeDepositRequest InitializeChallengeDepositRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public InitializeChallengeDepositRequestBody InitializeChallengeDepositRequestBody { get; set; }

        public InitializeChallengeDepositQuery(
            InitializeChallengeDepositRequest initializeChallengeDepositRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            InitializeChallengeDepositRequestBody initializeChallengeDepositRequestBody
        )
        {
            InitializeChallengeDepositRequest = initializeChallengeDepositRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            InitializeChallengeDepositRequestBody = initializeChallengeDepositRequestBody;
        }
    }
}