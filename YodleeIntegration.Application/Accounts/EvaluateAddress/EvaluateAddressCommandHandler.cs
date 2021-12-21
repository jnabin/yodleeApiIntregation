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

namespace YodleeIntegration.Application.Accounts.EvaluateAddress
{
    public class EvaluateAddressCommandHandler : BaseHandler.BaseHandler, IRequestHandler<EvaluateAddressCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public EvaluateAddressCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<EvaluateAddressCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(EvaluateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!CheckURLValid(request.EvaluateAddressRequest.Endpoint.ToString()))
                    throw new Exception("The Requested Url Is Invaild");

                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
               var response= await _serviceHttpClient.PostJsonEncodedAsync(request.EvaluateAddressRequestBody, request.EvaluateAddressRequest.Endpoint);
                await SaveEvaluateAddressAsync(response);
                await LogHttpRequest(response, string.Empty);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }

        private async Task SaveEvaluateAddressAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var accountResponse =
                    JsonSerializer.Deserialize<EvaluateAddressResponse>(await response.Content.ReadAsStringAsync());
                if(accountResponse.Address!=null)
                foreach (var responseItem in accountResponse.Address)
                {
                    await SaveEvaluateAddressToDbAsync(responseItem);
                }
            }
        }

        private async Task SaveEvaluateAddressToDbAsync(Address address)
        {

            var result = await CheckAccountAvailability(address);

            if (result)
            {
                address.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeAddressRepository.Update(address);
            }
            else
            {
                _unitOfWork.YodleeAddressRepository.Add(address);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckAccountAvailability(Address address)
        {
            var isExistAccount = await _unitOfWork.YodleeAddressRepository.
                SingleOrDefaultAsync(x => x.EntityId == address.EntityId);

            if (isExistAccount != null)
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