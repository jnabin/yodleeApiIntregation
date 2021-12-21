using MediatR;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Application.Authorization.SaveAccessToken
{
    public class SaveAccessTokenCommand : IRequest
    {
        public YodleeAccessToken YodleeAccessToken { get; }

        public SaveAccessTokenCommand(YodleeAccessToken yodleeAccessToken)
        {
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
