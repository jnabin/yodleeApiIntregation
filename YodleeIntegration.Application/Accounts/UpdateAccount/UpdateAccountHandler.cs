using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Accounts.UpdateAccount
{
    public class UpdateAccountHandler : BaseHandler.BaseHandler, IRequestHandler<UpdateAccountCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public UpdateAccountHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<UpdateAccountHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                return await _serviceHttpClient.PutAsync(request.UpdateAccountRequestBody, request.AccountsRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
      
    }
}