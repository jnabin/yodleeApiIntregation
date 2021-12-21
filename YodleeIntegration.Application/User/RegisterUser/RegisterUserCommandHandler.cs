using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.User.RegisterUser
{
    public class RegisterUserCommandHandler
        : BaseHandler.BaseHandler, IRequestHandler<RegisterUserCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<RegisterUserCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var responseMessage = await _serviceHttpClient.PostJsonEncodedAsync(request.UpdateUserDetailsRequestBody,
                request.UserRequest.Endpoint);

            try
            {
                await SaveUserAsync(responseMessage);
                await LogHttpRequest(responseMessage, request.UpdateUserDetailsRequestBody, request.UserRequest.Username);

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