using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Verification.VerifyChallengeDeposit
{
    public class VerifyChallengeDepositCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<VerifyChallengeDepositCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public VerifyChallengeDepositCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<VerifyChallengeDepositCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(VerifyChallengeDepositCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //This is where the execution happen from entry point
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var response =  await _serviceHttpClient.PutAsync(request.VerifyChallengeDepositRequestBody,
                    request.VerifyChallengeDepositRequest.Endpoint);

                await SaveVerficationStatusAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}