using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.ProvidersAccounts.GetUserProfileDetails
{
    public class GetUserProfileDetailsQueryHandler : BaseHandler.BaseHandler, IRequestHandler<GetUserProfileDetailsQuery,
        HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public GetUserProfileDetailsQueryHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<GetUserProfileDetailsQueryHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(GetUserProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.GetAsync(
                $"{request.ProvidersAccountRequest.Endpoint}?{GetParamsQuery(request.ProvidersAccountRequest.QueryParameters)}");

            try
            {             
                await SaveProviderAccountProfileAsync(response);

                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        protected async Task SaveProviderAccountProfileAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var profileResponse =
                    JsonConvert.DeserializeObject<UserProfileDetailsResponse>(
                        await response.Content.ReadAsStringAsync());
                if(profileResponse.ProviderAccount!=null)
                foreach(var responseItem in profileResponse.ProviderAccount)
                {
                    await SaveProviderAccountProfileToDbAsync(responseItem);
                }                

            }
        }

        protected async Task SaveProviderAccountProfileToDbAsync(ProviderAccountProfile profile)
        {

            var result = await CheckProfileAvailability(profile);

            if (result)
            {
                profile.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeProviderAccountProfileRepository.Update(profile);
            }
            else
            {
                _unitOfWork.YodleeProviderAccountProfileRepository.Add(profile);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckProfileAvailability(ProviderAccountProfile profile)
        {
            var isExistUser = await _unitOfWork.YodleeProviderAccountProfileRepository.
                SingleOrDefaultAsync(
                x => x.YodleeUserProfileDetailProviderAccountId == profile.YodleeUserProfileDetailProviderAccountId);

            if (isExistUser != null)
            {
                return true;
            }

            return false;
        }
    }
}
