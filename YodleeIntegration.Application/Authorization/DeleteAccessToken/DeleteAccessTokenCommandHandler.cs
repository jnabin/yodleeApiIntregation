using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Authorization.DeleteAccessToken
{
    public class DeleteAccessTokenCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<DeleteAccessTokenCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public DeleteAccessTokenCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<DeleteAccessTokenCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(DeleteAccessTokenCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var message = await _serviceHttpClient.DeleteAsync(request.BaseRequest.Endpoint);

                return message;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}