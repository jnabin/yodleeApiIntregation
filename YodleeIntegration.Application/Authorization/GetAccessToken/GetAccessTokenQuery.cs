using MediatR;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Application.Authorization.GetAccessToken
{
    public class GetAccessTokenQuery : IRequest<YodleeAccessToken>
    {
        public GetAccessTokenQuery()
        {
        }
    }
}
