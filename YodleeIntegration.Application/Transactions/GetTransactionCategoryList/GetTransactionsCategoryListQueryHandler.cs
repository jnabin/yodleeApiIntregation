using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Transactions.GetTransactionCategoryList
{
    public class GetTransactionsCategoryListQueryHandler : BaseHandler.BaseHandler,
        IRequestHandler<GetTransactionsCategoryListQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetTransactionsCategoryListQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetTransactionsCategoryListQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetTransactionsCategoryListQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.TransactionsRequest.Endpoint}?{GetParamsQuery(request.TransactionsRequest.QueryParameters)}");

            try
            {
                await SaveTransactionsCategoryListAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveTransactionsCategoryListAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var transactionResponse =
                    JsonConvert.DeserializeObject<GetTransactionCategoryListResponse>(
                        await response.Content.ReadAsStringAsync());

                if(transactionResponse != null)
                    foreach (var responseItem in transactionResponse.TransactionCategory)
                    {
                        await SaveTransactionsCategoryListToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveTransactionsCategoryListToDbAsync(TransactionCategory transaction)
        {

            var result = await CheckTransactionsCategoryListAvailability(transaction);

            if (result)
            {
                transaction.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeTransactionCategoryRepository.Update(transaction);
            }
            else
            {
                _unitOfWork.YodleeTransactionCategoryRepository.Add(transaction);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckTransactionsCategoryListAvailability(TransactionCategory transaction)
        {
            var isExistAccount = await _unitOfWork.YodleeTransactionCategoryRepository.
                SingleOrDefaultAsync(x => x.YodleeTransactionCategoryId == transaction.YodleeTransactionCategoryId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}
