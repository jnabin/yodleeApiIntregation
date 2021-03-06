using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Configs.SubscribeNotificationEvent
{
    public class SubscribeNotificationEventHandler : BaseHandler.BaseHandler, IRequestHandler<SubscribeNotificationEventCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public SubscribeNotificationEventHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<SubscribeNotificationEventHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(SubscribeNotificationEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                return await _serviceHttpClient.PostJsonEncodedAsync(request.SubscribeNotificationEventRequestBody, request.ConfigsRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}