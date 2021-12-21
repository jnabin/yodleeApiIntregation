using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.User.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<UpdateUserDetailsCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public UpdateUserDetailsCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<UpdateUserDetailsCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var responseMessage = await _serviceHttpClient.PutAsync(request.UpdateUserDetailsRequestBody,
                    request.UserRequest.Endpoint);
                await LogHttpRequest(responseMessage, request.UpdateUserDetailsRequestBody, request.UserRequest.Username);
                return responseMessage;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
    }
}