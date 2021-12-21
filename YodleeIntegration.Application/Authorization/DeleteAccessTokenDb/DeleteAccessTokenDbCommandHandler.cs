using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;

namespace YodleeIntegration.Application.Authorization.DeleteAccessTokenDb
{
    public class DeleteAccessTokenDbCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<DeleteAccessTokenDbCommand>
    {
        public DeleteAccessTokenDbCommandHandler(IUnitOfWork unitOfWork,
             ILogger<DeleteAccessTokenDbCommandHandler> logger
            ) : base(unitOfWork, logger)
        {
        }

        public async Task<Unit> Handle(DeleteAccessTokenDbCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var accessTokenQuery =
                    await _unitOfWork.YodleeAccessTokenRepository.SingleOrDefaultAsync(x => x.IsActive);
                if (accessTokenQuery == null) return Unit.Value;
                await _unitOfWork.YodleeAccessTokenRepository.RemoveAsync(accessTokenQuery);
                await _unitOfWork.CompleteAsync();
                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}