using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.ProvidersAccounts
{
    public class GetProvidersAccountQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetProvidersAccountQuery,
        HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetProvidersAccountQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetProvidersAccountQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetProvidersAccountQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.ProvidersAccountRequest.Endpoint}?{GetParamsQuery(request.ProvidersAccountRequest.QueryParameters)}");

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