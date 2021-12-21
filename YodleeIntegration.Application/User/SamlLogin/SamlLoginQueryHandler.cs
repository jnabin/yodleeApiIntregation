using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.User.SamlLogin
{
    public class SamlLoginQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<SamlLoginQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public SamlLoginQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<SamlLoginQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(SamlLoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //This is where the execution happen from entry point
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration,
                    request.YodleeAccessToken));

                var responseMessage = await _serviceHttpClient.PostJsonEncodedAsync(
                    request.SamlLoginRequest.QueryParameters, request.SamlLoginRequest.Endpoint);

                await SaveUserAsync(responseMessage);

                await LogHttpRequest(responseMessage, request.SamlLoginRequest.QueryParameters, "");

                return responseMessage;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}