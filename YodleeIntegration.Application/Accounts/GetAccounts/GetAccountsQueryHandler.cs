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

namespace YodleeIntegration.Application.Accounts.GetAccounts
{
    public class GetAccountsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetAccountsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetAccountsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetAccountsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            try
            {                   
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var response =  await _serviceHttpClient.GetAsync(
                    $"{request.AccountsRequest.Endpoint}?{GetParamsQuery(request.AccountsRequest.QueryParameters)}");

                await SaveAccountAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveAccountAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<AccountResponse>(await response.Content.ReadAsStringAsync());

                if(accountResponse.Account!=null)
                    foreach(var responseItem in accountResponse.Account)
                    {
                        await SaveAccountToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveAccountToDbAsync(Account account)
        {

            var result = await CheckAccountAvailability(account);

            if (result)
            {
                account.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAccountRepository.Add(account);
            }
            else
            {
                _unitOfWork.YodleeAccountRepository.Update(account);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(Account account)
        {
            var isExistAccount = await _unitOfWork.YodleeAccountRepository.
                SingleOrDefaultAsync(x => x.YodleeAccountId == account.YodleeAccountId);

            if(isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}