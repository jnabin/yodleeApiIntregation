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

namespace YodleeIntegration.Application.Accounts.GetLatestBalances
{
    public class GetLatestBalancesQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetLatestBalancesQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetLatestBalancesQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetLatestBalancesQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetLatestBalancesQuery request, CancellationToken cancellationToken)
        {
            try
            {                   
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var response =  await _serviceHttpClient.GetAsync(
                    $"{request.AccountsRequest.Endpoint}?{GetParamsQuery(request.AccountsRequest.QueryParameters)}");

                await SaveLatestBalancesAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveLatestBalancesAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<GetLatestBalancesResponseBody>(await response.Content.ReadAsStringAsync());
                
                if(accountResponse.AccountBalance!=null)
                    foreach(var responseItem in accountResponse.AccountBalance)
                    {
                        await SaveLatestBalancesToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveLatestBalancesToDbAsync(AccountBalance accountBalance)
        {

            var result = await CheckAccountAvailability(accountBalance);

            if (result)
            {
                accountBalance.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAccountBalanceRepository.Update(accountBalance);
            }
            else
            {
                _unitOfWork.YodleeAccountBalanceRepository.Add(accountBalance);
            }
            
            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(AccountBalance accountBalance)
        {
            var isExistaccountBalance = await _unitOfWork.YodleeAccountBalanceRepository.
                SingleOrDefaultAsync(x => x.EntityId == accountBalance.EntityId);

            if(isExistaccountBalance != null)
            {
                return true;
            }
            return false;
        }
    }
}