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

namespace YodleeIntegration.Application.Transactions.GetTransactionsWithoutQueryParams
{
    public class GetTransactionsWithoutParamsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetTransactionsWithoutParamsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetTransactionsWithoutParamsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetTransactionsWithoutParamsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetTransactionsWithoutParamsQuery request, CancellationToken cancellationToken)
        {
            try
            {

                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                var response =  await _serviceHttpClient.GetAsync(request.TransactionsRequest.Endpoint);

                await SaveTransactionCategorizationRuleAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
        private async Task SaveTransactionCategorizationRuleAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var ruleResponse =
                    JsonSerializer.Deserialize<GetTransactionCategorizationRulesResponse>(
                        await response.Content.ReadAsStringAsync());
                if(ruleResponse.TxnRules!=null)
                foreach (var responseItem in ruleResponse.TxnRules)
                {
                    await SaveTransactionCategorizationRuleToDbAsync(responseItem);
                }
            }
        }

        private async Task SaveTransactionCategorizationRuleToDbAsync(TransactionCategorizationRule rule)
        {

            var result = await CheckTransactionCategorizationRuleAvailability(rule);

            if (result)
            {
                rule.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeTransactionCategorizationRuleRepository.Update(rule);
            }
            else
            {
                _unitOfWork.YodleeTransactionCategorizationRuleRepository.Add(rule);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckTransactionCategorizationRuleAvailability(TransactionCategorizationRule rule)
        {
            var isExistAccount = await _unitOfWork.YodleeTransactionCategorizationRuleRepository.
                SingleOrDefaultAsync(x => x.TransactionCategorizationId == rule.TransactionCategorizationId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}