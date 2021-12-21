using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.GetProviderCount
{
    public class GetProviderCountQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetProviderCountQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetProviderCountQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetProviderCountQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetProviderCountQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.ProvidersRequest.Endpoint}?{GetParamsQuery(request.ProvidersRequest.QueryParameters)}");
            try
            {
                await SaveProviderCountAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }
        protected async Task SaveProviderCountAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var providerResponse =
                    JsonConvert.DeserializeObject<GetProvidersCountResponse>(
                        await response.Content.ReadAsStringAsync());

                if(providerResponse != null)
                    await SaveProviderCountToDbAsync(providerResponse.ProviderCount);

            }
        }

        protected async Task SaveProviderCountToDbAsync(ProviderCount providerCount)
        {

            var result = await CheckProviderCountAvailability(providerCount);

            if (result)
            {
                providerCount.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeProviderCountRepository.Update(providerCount);
            }
            else
            {
                _unitOfWork.YodleeProviderCountRepository.Add(providerCount);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckProviderCountAvailability(ProviderCount providerCount)
        {
            var isExistProviderCount = await _unitOfWork.YodleeProviderCountRepository.
                SingleOrDefaultAsync(
                x => x.EntityId == providerCount.EntityId);

            if (isExistProviderCount != null)
            {
                return true;
            }

            return false;
        }

    }
}