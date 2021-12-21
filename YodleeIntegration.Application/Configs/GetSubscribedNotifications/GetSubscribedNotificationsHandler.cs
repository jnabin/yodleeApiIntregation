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

namespace YodleeIntegration.Application.Configs.GetSubscribedNotifications
{
    public class GetSubscribedNotificationsHandler : BaseHandler.BaseHandler, IRequestHandler<GetSubscribedNotificationsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetSubscribedNotificationsHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetSubscribedNotificationsHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetSubscribedNotificationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                var response = await _serviceHttpClient.GetAsync(
                    $"{request.ConfigsRequest.Endpoint}?{GetParamsQuery(request.ConfigsRequest.QueryParameters)}");
                await SaveNotificationsEventAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveNotificationsEventAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var notificationEventResponse =
                    JsonSerializer.Deserialize<GetNotificationsEventResponse>(await response.Content.ReadAsStringAsync());
                
                if(notificationEventResponse.Event!=null)
                    foreach (var responseItem in notificationEventResponse.Event)
                    {
                        await SaveNotificationsEventToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveNotificationsEventToDbAsync(NotificationEvent notificationEvent)
        {

            var result = await CheckNotificationsEventAvailability(notificationEvent);

            if (result)
            {
                notificationEvent.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeNotificationEventRepository.Update(notificationEvent);
            }
            else
            {
                _unitOfWork.YodleeNotificationEventRepository.Add(notificationEvent);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckNotificationsEventAvailability(NotificationEvent notificationEvent)
        {
            var isExistNotificationEvent = await _unitOfWork.YodleeNotificationEventRepository.
                SingleOrDefaultAsync(x => x.EntityId == notificationEvent.EntityId);

            if (isExistNotificationEvent != null)
            {
                return true;
            }

            return false;
        }
    }
}