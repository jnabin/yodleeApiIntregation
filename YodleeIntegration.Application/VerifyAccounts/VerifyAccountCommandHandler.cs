using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.VerifyAccounts
{
    public class VerifyAccountCommandHandler : BaseHandler.BaseHandler,
        IRequestHandler<VerifyAccountCommand,
            HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public VerifyAccountCommandHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<VerifyAccountCommandHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));

            var response = await _serviceHttpClient.PostJsonEncodedAsync(request.VerifyAccountRequestBody,
                request.VerifyAccountRequest.Endpoint);
            try
            {
                await SaveVerifyAccountAsync(response);
                await LogHttpRequest(response, string.Empty);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                return response;
            }
        }

        private async Task SaveVerifyAccountAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var transactionResponse =
                    JsonConvert.DeserializeObject<VerifyAccountResponseBody>(await response.Content.ReadAsStringAsync());

                if(transactionResponse != null)
                    await SaveVerifyAccountToDbAsync(transactionResponse.VerifyAccount);
            }
        }

        private async Task SaveVerifyAccountToDbAsync(VerifyAccountDTO verifyAccountDTO)
        {

            var result = await CheckVerifyAccountAvailability(verifyAccountDTO);

            if (result)
            {
                verifyAccountDTO.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeVerifyAccountDTORepository.Update(verifyAccountDTO);
            }
            else
            {
                _unitOfWork.YodleeVerifyAccountDTORepository.Add(verifyAccountDTO);
            }

            await _unitOfWork.CompleteAsync();
        }

        private async Task<bool> CheckVerifyAccountAvailability(VerifyAccountDTO verifyAccountDTO)
        {
            var isExistAccount = await _unitOfWork.YodleeVerifyAccountDTORepository.
                SingleOrDefaultAsync(x => x.EntityId == verifyAccountDTO.EntityId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }

    }
}