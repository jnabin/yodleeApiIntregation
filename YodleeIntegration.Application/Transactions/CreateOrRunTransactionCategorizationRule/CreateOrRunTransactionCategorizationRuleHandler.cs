using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Transactions.CreateOrRunTransactionCategorizationRule
{
    public class CreateOrRunTransactionCategorizationRuleHandler : BaseHandler.BaseHandler, IRequestHandler<CreateOrRunTransactionCategorizationRuleCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public CreateOrRunTransactionCategorizationRuleHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<CreateOrRunTransactionCategorizationRuleHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(CreateOrRunTransactionCategorizationRuleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!CheckURLValid(request.TransactionsRequest.Endpoint.ToString()))
                    throw new Exception("The Requested Url Is Invaild");

                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                return await _serviceHttpClient.PostWithOutRequestBody($"{request.TransactionsRequest.Endpoint}?{GetParamsQuery(request.TransactionsRequest.QueryParameters)}");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
        public bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) &&
                uriResult.Scheme == Uri.UriSchemeHttps;
        }
    }
}