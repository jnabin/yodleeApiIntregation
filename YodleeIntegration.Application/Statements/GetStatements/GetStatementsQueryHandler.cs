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

namespace YodleeIntegration.Application.Statements.GetStatements
{
    public class GetStatementsQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<GetStatementsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetStatementsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetStatementsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetStatementsQuery request, CancellationToken cancellationToken)
        {
            //This is where the execution happen from entry point
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(request.StatementsRequest.Endpoint);

            try
            {

                await SaveStatementAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveStatementAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var statementResponse =
                    JsonConvert.DeserializeObject<GetStatementsResponse>(await response.Content.ReadAsStringAsync());

                if(statementResponse != null)
                    foreach (var responseItem in statementResponse.Statement)
                    {
                        await SaveStatementToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveStatementToDbAsync(Statement statement)
        {

            var result = await CheckStatementAvailability(statement);

            if (result)
            {
                statement.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeStatementRepository.Update(statement);
            }
            else
            {
                _unitOfWork.YodleeStatementRepository.Add(statement);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckStatementAvailability(Statement statement)
        {
            var isExistAccount = await _unitOfWork.YodleeStatementRepository.
                SingleOrDefaultAsync(x => x.YodleeStatementId == statement.YodleeStatementId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}