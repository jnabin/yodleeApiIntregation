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

namespace YodleeIntegration.Application.Holdings.GetHoldingTypeList
{
    public class GetHoldingTypeListQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetHoldingTypeListQuery, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetHoldingTypeListQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetHoldingTypeListQuery> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetHoldingTypeListQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
            var response = await _serviceHttpClient.GetAsync(request.HoldingsRequest.Endpoint);
            try
            {
                
                await SaveHoldingTypeListAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveHoldingTypeListAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<GetHoldingTypeListResponse>(await response.Content.ReadAsStringAsync());

                if(accountResponse.HoldingType!=null)
                    foreach (var responseItem in accountResponse.HoldingType)
                    {
                        await SaveHoldingTypeListToDbAsync(responseItem);
                    }
            }
        }

        private async Task SaveHoldingTypeListToDbAsync(string holdingType)
        {
            var result = await CheckAccountAvailability(holdingType);
            HoldingType holdingTypeObject = new HoldingType();
            holdingTypeObject.holdingType = holdingType;
            if (result)
            {
                holdingTypeObject.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeHoldingTypeRepository.Update(holdingTypeObject);
            }
            else
            {
                _unitOfWork.YodleeHoldingTypeRepository.Add(holdingTypeObject);
            }
            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(string holdingType)
        {
            var isExistholdingType = await _unitOfWork.YodleeHoldingTypeRepository.
                SingleOrDefaultAsync(x => x.holdingType == holdingType);

            if (isExistholdingType != null)
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