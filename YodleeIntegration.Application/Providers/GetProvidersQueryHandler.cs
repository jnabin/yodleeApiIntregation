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

namespace YodleeIntegration.Application.Providers
{
    public class GetProvidersQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetProvidersQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetProvidersQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetProvidersQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.ProvidersRequest.Endpoint}?{GetParamsQuery(request.ProvidersRequest.QueryParameters)}");

            try
            {
                await SaveProviderAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }
        protected async Task SaveProviderAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var providerResponse =
                    JsonSerializer.Deserialize<ProvidersResponse>(
                        await response.Content.ReadAsStringAsync());


                if (providerResponse.Provider != null)
                {

                    foreach (var responseItem in providerResponse.Provider)
                    {
                        await SaveProviderToDbAsync(responseItem);
                    }
                }
            }
        }

        protected async Task SaveProviderToDbAsync(Provider provider)
        {

            var result = await CheckProviderAvailability(provider);

            if (result)
            {
                provider.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeProviderRepository.Update(provider);
            }
            else
            {
                _unitOfWork.YodleeProviderRepository.Add(provider);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckProviderAvailability(Provider provider)
        {
            var isExistUser = await _unitOfWork.YodleeProviderRepository.
                SingleOrDefaultAsync(
                x => x.YodleeProviderId == provider.YodleeProviderId);

            if (isExistUser != null)
            {
                return true;
            }

            return false;
        }

    }
}