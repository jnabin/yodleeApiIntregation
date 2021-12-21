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

namespace YodleeIntegration.Application.Accounts.AddManualAccount
{
    public class AddManualAccountCommandHandler : BaseHandler.BaseHandler,
        IRequestHandler<AddManualAccountCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public AddManualAccountCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<AddManualAccountCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(AddManualAccountCommand request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.PostJsonEncodedAsync(
                request.AddManualAccountRequestBody, request.AccountsRequest.Endpoint);

            try
            {
                await SaveAddManualResponseAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveAddManualResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<AddManualAccountResponseBody>(
                        await response.Content.ReadAsStringAsync());

                if(accountResponse.Account!=null)
                    foreach (var responseItem in accountResponse.Account)
                    {
                        await SaveAddManualResponseToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveAddManualResponseToDbAsync(AddManualResponseAccount account)
        {

            var result = await CheckAvailability(account);

            if (result)
            {
                account.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAddManualResponseAccountRepository.Update(account);
            }
            else
            {
                _unitOfWork.YodleeAddManualResponseAccountRepository.Add(account);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAvailability(AddManualResponseAccount account)
        {
            var isExistAccount = await _unitOfWork.YodleeAddManualResponseAccountRepository.
                SingleOrDefaultAsync(
                x => x.YodleeAddManualResponseAccountId == account.YodleeAddManualResponseAccountId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}