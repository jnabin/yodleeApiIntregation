using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Configurations.GetYodleeConfiguration
{
    public class GetYodleeConfigurationQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetYodleeConfigurationQuery, YodleeConfiguration>
    {
        public GetYodleeConfigurationQueryHandler(IUnitOfWork unitOfWork,
             ILogger<GetYodleeConfigurationQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
        }

        public async Task<YodleeConfiguration> Handle(GetYodleeConfigurationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.YodleeConfigurationRepository.SingleOrDefaultAsync(x => x.IsActive);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}