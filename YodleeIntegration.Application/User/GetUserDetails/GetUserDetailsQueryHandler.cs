using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.User.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<GetUserDetailsQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetUserDetailsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetUserDetailsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration,
                    request.YodleeAccessToken));

            var responseMessage = await _serviceHttpClient.GetAsync(request.BaseRequest.Endpoint);

            try
            {
                await SaveUserAsync(responseMessage);
                await LogHttpRequest(responseMessage, string.Empty);

                return responseMessage;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);

                return responseMessage;
            }
        }
    }
}