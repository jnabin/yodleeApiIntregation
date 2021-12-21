using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Configs.GetPublicKey
{
    public class GetPublicKeyQuery : IRequest<HttpResponseMessage>
    {
        public PublicKeyRequest PublicKeyRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public GetPublicKeyQuery(PublicKeyRequest publicKeyRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken)
        {
            PublicKeyRequest = publicKeyRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }

    }
}
