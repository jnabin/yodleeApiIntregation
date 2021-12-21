using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YodleeIntegration.Common.Model;

namespace YodleeIntegration.Common.ServiceClient
{
    public interface IServiceHttpClient
    {
        void AddHeaders(HeaderKeyValue headerKeyValue);

        Task<HttpResponseMessage> PostFormEncodedAsync(List<KeyValuePair<string, string>> param, string endpoint);

        Task<HttpResponseMessage> PostJsonEncodedAsync<TParam>(TParam param, string endpoint);

        Task<HttpResponseMessage> GetAsync(string endpoint);

        Task<HttpResponseMessage> GetAsync(string endpoint, IEnumerable<KeyValuePair<string, string>> queryParameters);

        Task<HttpResponseMessage> PutAsync<TParam>(TParam param, string url);

        Task<HttpResponseMessage> DeleteAsync(string endpoint);

        Task<HttpResponseMessage> PostWithOutRequestBody(string endpoint);
    }
}