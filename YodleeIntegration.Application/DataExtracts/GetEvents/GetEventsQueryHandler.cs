using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.DataExtracts.GetEvents
{
    public class GetEventsQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<GetEventsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetEventsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetEventsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //This is where the execution happen from entry point
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                var u = await _serviceHttpClient.GetAsync(request.GetEventsRequest.Endpoint,
                    request.GetEventsRequest.QueryParameters);
                return await _serviceHttpClient.GetAsync(request.GetEventsRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}