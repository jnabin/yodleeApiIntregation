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

namespace YodleeIntegration.Application.Accounts.GetHistoricalAccounts
{
    public class GetHistoricalAccountsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetHistoricalAccountsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetHistoricalAccountsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetHistoricalAccountsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetHistoricalAccountsQuery request, CancellationToken cancellationToken)
        {
            try
            {                   
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var response =  await _serviceHttpClient.GetAsync(
                    $"{request.AccountsRequest.Endpoint}?{GetParamsQuery(request.AccountsRequest.QueryParameters)}");

                await SaveHistoricalAccountsAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveHistoricalAccountsAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<HistoricalAccountResponseBody>(await response.Content.ReadAsStringAsync());

                if(accountResponse.Account!=null)
                    foreach(var responseItem in accountResponse.Account)
                    {
                        await SaveHistoricalAccountsToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveHistoricalAccountsToDbAsync(HistoricalAccount account)
        {

            var result = await CheckAccountAvailability(account);

            if (result)
            {
                account.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeHistoricalAccountRepository.Update(account);
            }
            else
            {
                _unitOfWork.YodleeHistoricalAccountRepository.Add(account);
            }
            
            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(HistoricalAccount account)
        {
            var isExistAccount = await _unitOfWork.YodleeHistoricalAccountRepository.
                SingleOrDefaultAsync(x => x.YoldeeHistoricalAccountId == account.YoldeeHistoricalAccountId);

            if(isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}