using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Accounts.DeleteAccount
{
    public class DeleteAccountHandler : BaseHandler.BaseHandler, IRequestHandler<DeleteAccountCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public DeleteAccountHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<DeleteAccountHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {

                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                return await _serviceHttpClient.DeleteAsync(request.AccountsRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}