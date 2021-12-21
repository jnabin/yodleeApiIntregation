using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.ProvidersAccounts.UpdateAccountPreferences
{
    public class UpdateAccountPreferencesHandler : BaseHandler.BaseHandler, IRequestHandler<UpdateAccountPreferencesCommand, HttpResponseMessage>
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public UpdateAccountPreferencesHandler(IUnitOfWork unitOfWork,
            IServiceHttpClient serviceHttpClient, ILogger<UpdateAccountPreferencesHandler> logger
        ) : base(unitOfWork, logger)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        public async Task<HttpResponseMessage> Handle(UpdateAccountPreferencesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _serviceHttpClient.AddHeaders(GetHeadersWithJwt(request.YodleeConfiguration, request.YodleeAccessToken));
                return await _serviceHttpClient.PutAsync(request.UpdateAccountPreferencesRequestBody, request.ProvidersAccountRequest.Endpoint);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, new EventId(ex.HResult), ex.Message);
                throw;
            }
        }
       
    }
}