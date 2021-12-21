using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Verification.GetVerificationStatus
{
    public class GetVerificationStatusQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<GetVerificationStatusQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetVerificationStatusQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetVerificationStatusQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetVerificationStatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //This is where the execution happen from entry point
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var response =  await _serviceHttpClient.GetAsync(request.GetVerificationStatusRequest.Endpoint);

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