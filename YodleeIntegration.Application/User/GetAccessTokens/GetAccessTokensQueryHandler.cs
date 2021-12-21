using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.User.GetAccessTokens
{
    public class GetAccessTokensQueryHandler
        : BaseHandler.BaseHandler, IRequestHandler<GetAccessTokensQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetAccessTokensQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetAccessTokensQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetAccessTokensQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

                var responseMessage = await _serviceHttpClient.GetAsync(request.AccessTokensRequest.Endpoint,
                    request.AccessTokensRequest.QueryParameters);

                await SaveAccessTokenAsync(responseMessage);

                await LogHttpRequest(responseMessage, string.Empty);

                return responseMessage;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveAccessTokenAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var userAccessResponse =
                    JsonConvert.DeserializeObject<UserAccessToken>(
                        await response.Content.ReadAsStringAsync());

                if(userAccessResponse != null)
                    foreach(var responseItem in userAccessResponse.AccessToken.AccessTokens)
                    {
                        await SaveUserToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveUserToDbAsync(AccessTokens accessToken)
        {

            var result = await CheckAvailability(accessToken);

            if (result)
            {
                accessToken.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAccessTokensRepository.Update(accessToken);
            }
            else
            {
                _unitOfWork.YodleeAccessTokensRepository.Add(accessToken);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAvailability(AccessTokens accessTokens)
        {
            var isExistToken = await _unitOfWork.YodleeAccessTokensRepository.
                SingleOrDefaultAsync(
                x => x.AppId == accessTokens.AppId);

            if (isExistToken != null)
            {
                return true;
            }

            return false;
        }
    }
}
