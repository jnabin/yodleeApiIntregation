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

namespace YodleeIntegration.Application.Holdings.GetSecurityDetails
{
    public class GetSecurityDetailsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetSecurityDetailsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetSecurityDetailsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetSecurityDetailsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetSecurityDetailsQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.HoldingsRequest.Endpoint}?{GetParamsQuery(request.HoldingsRequest.QueryParameters)}");
            try
            {
                await SaveSecurityDetailsAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveSecurityDetailsAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<GetSecurityDetailsResponse>(await response.Content.ReadAsStringAsync());

                if(accountResponse.Holding!=null)
                    foreach (var responseItem in accountResponse.Holding)
                    {
                        await SaveSecurityDetailsToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveSecurityDetailsToDbAsync(SecurityHolding securityHolding)
        {

            var result = await CheckAccountAvailability(securityHolding);

            if (result)
            {
                securityHolding.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeSecurityHoldingRepository.Update(securityHolding);
            }
            else
            {
                _unitOfWork.YodleeSecurityHoldingRepository.Add(securityHolding);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(SecurityHolding securityHolding)
        {
            var isExistsecurityHolding = await _unitOfWork.YodleeSecurityHoldingRepository.
                SingleOrDefaultAsync(x => x.EntityId == securityHolding.EntityId);

            if (isExistsecurityHolding != null)
            {
                return true;
            }

            return false;
        }
       
    }
}