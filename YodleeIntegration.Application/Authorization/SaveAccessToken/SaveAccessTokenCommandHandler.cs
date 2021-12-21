using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;

namespace YodleeIntegration.Application.Authorization.SaveAccessToken
{
    public class SaveAccessTokenCommandHandler : BaseHandler.BaseHandler, IRequestHandler<SaveAccessTokenCommand>
    {
        public SaveAccessTokenCommandHandler(IUnitOfWork unitOfWork, ILogger<SaveAccessTokenCommandHandler> logger) : base(unitOfWork, logger)
        {
        }

        public async Task<Unit> Handle(SaveAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var lastToken = await _unitOfWork.YodleeAccessTokenRepository.SingleOrDefaultAsync(x => x.IsActive);
            if (lastToken != null)
            {
                await _unitOfWork.YodleeAccessTokenRepository.RemoveAsync(lastToken);
            }

            await _unitOfWork.YodleeAccessTokenRepository.AddAsync(request.YodleeAccessToken);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}