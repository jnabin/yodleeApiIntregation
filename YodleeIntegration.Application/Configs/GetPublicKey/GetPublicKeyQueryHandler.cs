using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Configs.GetPublicKey
{
    public class GetPublicKeyQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetPublicKeyQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetPublicKeyQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetPublicKeyQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetPublicKeyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                var response = await _serviceHttpClient.GetAsync(request.PublicKeyRequest.Endpoint);
                await SavePublicKeyAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SavePublicKeyAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var publicKeyResponse =
                    JsonSerializer.Deserialize<GetPublicKeyResponse>(await response.Content.ReadAsStringAsync());

                if(publicKeyResponse.PublicKey!=null)
                    await SavePublicKeyToDbAsync(publicKeyResponse.PublicKey); 
            }
        }

        private async Task SavePublicKeyToDbAsync(PublicKey publicKey)
        {

            var result = await CheckPublicKeyAvailability(publicKey);

            if (result)
            {
                publicKey.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleePublicKeyRepository.Update(publicKey);
            }
            else
            {
                _unitOfWork.YodleePublicKeyRepository.Add(publicKey);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckPublicKeyAvailability(PublicKey publicKey)
        {
            var isExistAccount = await _unitOfWork.YodleePublicKeyRepository.
                SingleOrDefaultAsync(x => x.EntityId == publicKey.EntityId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }
    }
}