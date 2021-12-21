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

namespace YodleeIntegration.Application.Holdings
{
    public class GetAssetClassificationListQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetAssetClassificationListQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetAssetClassificationListQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetAssetClassificationListQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetAssetClassificationListQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
            var response = await _serviceHttpClient.GetAsync(request.HoldingsRequest.Endpoint);
            try
            {

                await SaveAssetClassificationListAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveAssetClassificationListAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<GetAssetClassificationListResponse>(await response.Content.ReadAsStringAsync());

                foreach (var responseItem in accountResponse.AssetClassificationList)
                {
                    await SaveAssetClassificationListToDbAsync(responseItem);
                }
            }
        }

        private async Task SaveAssetClassificationListToDbAsync(AssetClassificationList assetClassificationList)
        {

            var result = await CheckAccountAvailability(assetClassificationList);

            if (result)
            {
                assetClassificationList.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAssetClassificationListRepository.Update(assetClassificationList);
            }
            else
            {
                _unitOfWork.YodleeAssetClassificationListRepository.Add(assetClassificationList);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(AssetClassificationList assetClassificationList)
        {
            var isExistassetClassificationList = await _unitOfWork.YodleeAssetClassificationListRepository.
                SingleOrDefaultAsync(x => x.EntityId == assetClassificationList.EntityId);

            if (isExistassetClassificationList != null)
            {
                return true;
            }
            return false;
        }
        public bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) &&
                uriResult.Scheme == Uri.UriSchemeHttps;
        }
    }
}