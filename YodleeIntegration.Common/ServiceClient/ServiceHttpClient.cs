using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YodleeIntegration.Common.Model;

namespace YodleeIntegration.Common.ServiceClient
{
    public class ServiceHttpClient : IServiceHttpClient
    {
        private readonly HttpClient _httpClient;

        public ServiceHttpClient(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }

        public void AddHeaders(HeaderKeyValue headerKeyValue)
        {
            if (headerKeyValue != null)
            {
                foreach (var item in headerKeyValue.HeaderKeyValues)
                {
                    _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
        }

        public async Task<HttpResponseMessage> PostWithOutRequestBody(string endpoint)
        {
            return await _httpClient.PostAsync(endpoint, null!);
        }

        public async Task<HttpResponseMessage> PostFormEncodedAsync(List<KeyValuePair<string, string>> param, string endpoint)
        {
            return await _httpClient.PostAsync(endpoint, new FormUrlEncodedContent(param));
        }

        public async Task<HttpResponseMessage> PostJsonEncodedAsync<TParam>(TParam param, string endpoint)
        {
            var content = JsonSerializer.Serialize(param);
            return await _httpClient.PostAsync(endpoint, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _httpClient.GetAsync(endpoint);
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint, IEnumerable<KeyValuePair<string, string>> queryParameters)
        {
            var uriBuilder = new UriBuilder(endpoint);
            using var content = new FormUrlEncodedContent(queryParameters);
            uriBuilder.Query = await content.ReadAsStringAsync();
            return await _httpClient.GetAsync(uriBuilder.ToString());
        }

        public async Task<HttpResponseMessage> PutAsync<TParam>(TParam param, string endpoint)
        {
            var content = JsonSerializer.Serialize(param);
            return await _httpClient.PutAsync(endpoint, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _httpClient.DeleteAsync(endpoint);
        }
    }
}