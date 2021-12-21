using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Application.Authorization.GenerateAccessToken
{
    public class GenerateAccessTokenCommandHandler : BaseHandler.BaseHandler, IRequestHandler<GenerateAccessTokenDataCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GenerateAccessTokenCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GenerateAccessTokenCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GenerateAccessTokenDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //This is where the execution happen from entry point
                _serviceHttpClient.AddHeaders(GetHeadersWithLoginName(request.YodleeConfiguration));

                var response = await _serviceHttpClient.PostFormEncodedAsync(
                    GetRequestBody(request.AuthorizationUserTokenRequest),
                    request.AuthorizationUserTokenRequest.Endpoint);

                await SaveTokenAsync(response);

                await LogHttpRequest(response, request.AuthorizationUserTokenRequest, request.Username);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private static List<KeyValuePair<string, string>> GetRequestBody(AuthorizationUserTokenRequest authorizationUserTokenRequest)
        {
            return new List<KeyValuePair<string, string>>
            {
                SetClient(authorizationUserTokenRequest),
                SetSecret(authorizationUserTokenRequest)
            };
        }

        private static KeyValuePair<string, string> SetClient(AuthorizationUserTokenRequest authorizationUserTokenRequest)
        {
            return new KeyValuePair<string, string>("clientId", authorizationUserTokenRequest.ClientId);
        }

        private static KeyValuePair<string, string> SetSecret(AuthorizationUserTokenRequest authorizationUserTokenRequest)
        {
            return new KeyValuePair<string, string>("secret", authorizationUserTokenRequest.Secret);
        }

        private async Task SaveTokenAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var tokenResponse =
                    JsonSerializer.Deserialize<AuthorizationUserTokenResponse>(await response.Content.ReadAsStringAsync());
                await SaveTokenToDbAsync(tokenResponse!.Token.Map());
            }
        }

        private async Task SaveTokenToDbAsync(YodleeAccessToken yodleeAccessToken)
        {
            var lastToken = await _unitOfWork.YodleeAccessTokenRepository.SingleOrDefaultAsync(x => x.IsActive);
            if (lastToken != null)
            {
                await _unitOfWork.YodleeAccessTokenRepository.RemoveAsync(lastToken);
            }

            await _unitOfWork.YodleeAccessTokenRepository.AddAsync(yodleeAccessToken);
            await _unitOfWork.CompleteAsync();
        }
    }
}