using MediatR;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Application.Authorization.DeleteAccessTokenDb
{
    public class DeleteAccessTokenDbCommand : IRequest
    {
        public YodleeAccessToken YodleeAccessToken { get; }

        public DeleteAccessTokenDbCommand(YodleeAccessToken yodleeAccessToken)
        {
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}