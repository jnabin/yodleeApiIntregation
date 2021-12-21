using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.ProvidersAccounts.UpdateProviderAccount
{
    public class UpdateProviderAccountHandler : BaseHandler.BaseHandler, IRequestHandler<UpdateProviderAccountCommand,
        HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public UpdateProviderAccountHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<UpdateProviderAccountHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(UpdateProviderAccountCommand request,
            CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration,
                  request.YodleeAccessToken));

            var response = await _serviceHttpClient.PutAsync(request.ProviderAccountRequestBody,
                request.ProvidersAccountRequest.Endpoint);

            try
            {
                await SaveProviderAccountAsync(response);

                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }
    }
}