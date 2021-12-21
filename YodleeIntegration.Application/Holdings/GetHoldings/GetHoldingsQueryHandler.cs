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

namespace YodleeIntegration.Application.Holdings.GetHoldings
{
    public class GetHoldingsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetHoldingsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetHoldingsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetHoldingsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetHoldingsQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
            var response = await _serviceHttpClient.GetAsync(
                $"{request.HoldingsRequest.Endpoint}?{GetParamsQuery(request.HoldingsRequest.QueryParameters)}");
            try
            {

                await SaveHoldingsAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveHoldingsAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var holdingResponse =
                    JsonSerializer.Deserialize<GetHoldingsResponse>(await response.Content.ReadAsStringAsync());

                if(holdingResponse.Holding!=null)
                    foreach (var responseItem in holdingResponse.Holding)
                    {
                        await SaveHoldingsToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveHoldingsToDbAsync(Holding holding)
        {

            var result = await CheckAccountAvailability(holding);

            if (result)
            {
                holding.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeHoldingRepository.Update(holding);
            }
            else
            {
                _unitOfWork.YodleeHoldingRepository.Add(holding);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(Holding holding)
        {
            var isExistHolding = await _unitOfWork.YodleeHoldingRepository.
                SingleOrDefaultAsync(x => x.EntityId == holding.EntityId);

            if (isExistHolding != null)
            {
                return true;
            }

            return false;
        }

    }
}