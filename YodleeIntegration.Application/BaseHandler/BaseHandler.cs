using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.Model;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;
using YodleeIntegration.Domain.Model.RequestLog;

namespace YodleeIntegration.Application.BaseHandler
{
    public class BaseHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly ILogger _logger;

        public BaseHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        protected static HeaderKeyValue GetHeadersWithLoginName(YodleeConfiguration yodleeConfiguration)
        {
            return new HeaderKeyValue
            {
                HeaderKeyValues = new List<KeyValuePair<string, string>>
                {
                    new("Api-Version", yodleeConfiguration.ApiVersion),
                    new("loginName", yodleeConfiguration.Username)
                }
            };
        }

        protected async Task SaveVerficationStatusAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var verificationResponse =
                    JsonConvert.DeserializeObject<VerficationResponse>(await response.Content.ReadAsStringAsync());

                if(verificationResponse != null)
                    foreach(var resposneItem in verificationResponse.Verfications)
                    {
                        await SaveVerficationToDbAsync(resposneItem);
                    }
                
            }
        }

        protected async Task SaveVerficationToDbAsync(Verifications verifications)
        {

            var result = await CheckVerificationsAvailability(verifications);

            if (result)
            {
                verifications.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeVerificationsRepository.Update(verifications);
            }
            else
            {
                _unitOfWork.YodleeVerificationsRepository.Add(verifications);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckVerificationsAvailability(Verifications verifications)
        {
            var isExistAccount = await _unitOfWork.YodleeVerificationsRepository.
                SingleOrDefaultAsync(x => x.YodleeVerificationId == verifications.YodleeVerificationId);

            if (isExistAccount != null)
            {
                return true;
            }

            return false;
        }

        protected async Task SaveUserAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var userResponse =
                    JsonConvert.DeserializeObject<UserResponse>(
                        await response.Content.ReadAsStringAsync());

                if(userResponse != null)
                    await SaveUserToDbAsync(userResponse.User);
            }
        }

        protected async Task SaveUserToDbAsync(Users user)
        {

            var result = await CheckAvailability(user);

            if (result)
            {
                user.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeUserRepository.Update(user);
            }
            else
            {
                _unitOfWork.YodleeUserRepository.Add(user);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckAvailability(Users user)
        {
            var isExistUser = await _unitOfWork.YodleeUserRepository.
                SingleOrDefaultAsync(
                x => x.YodleeUserId == user.YodleeUserId);

            if (isExistUser != null)
            {
                return true;
            }

            return false;
        }


        protected async Task SaveProviderAccountAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var providerAccountResponse =
                     JsonConvert.DeserializeObject<ProviderAccountResponseList>(
                        await response.Content.ReadAsStringAsync());

                if(providerAccountResponse != null)
                    foreach (var responseItem in providerAccountResponse.ProviderAccount)
                    {
                        await SaveProviderAccountToDbAsync(responseItem);
                    }

            }
        }

        protected async Task SaveProviderAccountToDbAsync(ProviderAccount account)
        {

            var result = await CheckProviderAccountAvailability(account);

            if (result)
            {
                account.LastModificationTime = DateTime.Now;
                _unitOfWork.YodleeProviderAccountRepository.Update(account);
            }
            else
            {
                _unitOfWork.YodleeProviderAccountRepository.Add(account);
            }

            await _unitOfWork.CompleteAsync();
        }

        protected async Task<bool> CheckProviderAccountAvailability(ProviderAccount account)
        {
            var isExistUser = await _unitOfWork.YodleeProviderAccountRepository.
                SingleOrDefaultAsync(
                x => x.YodleeProviderAccountId == account.YodleeProviderAccountId);

            if (isExistUser != null)
            {
                return true;
            }

            return false;
        }

        protected static HeaderKeyValue GetHeadersWithJwt(YodleeConfiguration yodleeConfiguration, YodleeAccessToken yodleeAccessToken)
        {
            return new HeaderKeyValue
            {
                HeaderKeyValues = new List<KeyValuePair<string, string>>
                {
                    new("Api-Version", yodleeConfiguration.ApiVersion),
                    new("Authorization", $"Bearer {yodleeAccessToken.AccessToken}")
                }
            };
        }

        protected static string GetParamsQuery(IEnumerable<KeyValuePair<string, string>> queryParameters)
        {
            if (queryParameters == null)
            {
                return "";
            }
            return queryParameters.Aggregate("", (current, queryParameter) => current + $"{queryParameter.Key}={queryParameter.Value}&");
        }

        protected async Task LogHttpRequest(HttpResponseMessage response, string username)
        {
            var requestLog = await PrepareRequestLog(response, username);
            if (_unitOfWork.RequestLogRepository != null)
            {
                await _unitOfWork?.RequestLogRepository?.AddAsync(requestLog);
                await _unitOfWork.CompleteAsync();
            }

        }

        protected async Task LogHttpRequest<TParam>(HttpResponseMessage response, TParam param, string username)
        {
            var requestLog = await PrepareRequestLog(response, param, username);
            await _unitOfWork.RequestLogRepository.AddAsync(requestLog);
            await _unitOfWork.CompleteAsync();
        }

        private static async Task<RequestLog> PrepareRequestLog(HttpResponseMessage response, string username)
        {
            return new RequestLog
            {
                Endpoint = response.RequestMessage?.RequestUri?.AbsolutePath,
                Method = response.RequestMessage.Method.Method,
                Response = await response.Content.ReadAsStringAsync(),
                ReasonPhrase = response.ReasonPhrase ?? string.Empty,
                UserName = username
            };
        }

        private static async Task<RequestLog> PrepareRequestLog<TParam>(HttpResponseMessage response, TParam param, string username)
        {
            return new RequestLog
            {
                Endpoint = response.RequestMessage!.RequestUri!.AbsolutePath,
                Method = response.RequestMessage.Method.Method,
                Request = System.Text.Json.JsonSerializer.Serialize(param),
                Response = await response.Content.ReadAsStringAsync(),
                ReasonPhrase = response.ReasonPhrase ?? string.Empty,
                UserName = username
            };
        }
    }
}