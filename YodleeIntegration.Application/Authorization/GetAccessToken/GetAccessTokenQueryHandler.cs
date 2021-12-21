using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Application.Authorization.GetAccessToken
{
    public class GetAccessTokenQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetAccessTokenQuery, YodleeAccessToken>
    {
        public GetAccessTokenQueryHandler(IUnitOfWork unitOfWork,
             ILogger<GetAccessTokenQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
        }

        public async Task<YodleeAccessToken> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.YodleeAccessTokenRepository.SingleOrDefaultAsync(x => x.IsActive);
        }
    }
}