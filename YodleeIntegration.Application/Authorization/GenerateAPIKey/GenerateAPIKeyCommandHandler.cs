using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Authorization.GenerateApiKey
{
    public class GenerateApiKeyCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<GenerateApiKeyCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GenerateApiKeyCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GenerateApiKeyCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GenerateApiKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                var message = await _serviceHttpClient.PostFormEncodedAsync(request.AuthorizationUserApiKeyRequest.QueryParameters.ToList(), request.AuthorizationUserApiKeyRequest.Endpoint);
                // Todo: Save API Key To DB
                return message;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}