using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Authorization.DeleteApiKey
{
    internal class DeleteApiKeyCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<DeleteApiKeyCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public DeleteApiKeyCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<DeleteApiKeyCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(DeleteApiKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                //await DeleteApiKeyAsync();
                return await _serviceHttpClient.DeleteAsync(request.AuthorizationUserApiKeyRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}