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

namespace YodleeIntegration.Application.Transactions.GetTransactions
{
    public class GetTransactionsCountQueryHandler : BaseHandler.BaseHandler,
        IRequestHandler<GetTransactionsCountQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetTransactionsCountQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetTransactionsCountQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetTransactionsCountQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
            
            var response = await _serviceHttpClient.GetAsync(
                $"{request.TransactionsRequest.Endpoint}?{GetParamsQuery(request.TransactionsRequest.QueryParameters)}");

            try
            {     
                await SaveTransactionAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveTransactionAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var transactionResponse =
                    JsonConvert.DeserializeObject<GetTransactionsCountResponse>(await response.Content.ReadAsStringAsync());
                    
                if(transactionResponse != null)
                    await SaveTransactionCountToDbAsync(transactionResponse.Transaction);
            }
        }

        private async Task SaveTransactionCountToDbAsync(Transaction transaction)
        {

            var result = await CheckTransactionCountAvailability(transaction);

            if (result)
            {
                transaction.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeTransactionRepository.Update(transaction);
            }
            else
            {
                _unitOfWork.YodleeTransactionRepository.Add(transaction);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckTransactionCountAvailability(Transaction transaction)
        {
            var isExistAccount = await _unitOfWork.YodleeTransactionRepository.
                SingleOrDefaultAsync(x => x.YodleeTransactionId == transaction.YodleeTransactionId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}