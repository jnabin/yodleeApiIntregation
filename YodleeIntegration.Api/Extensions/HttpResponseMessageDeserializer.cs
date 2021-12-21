using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;

namespace YodleeIntegration.Api.Extensions
{
    public static class HttpResponseMessageDeserializer
    {
        public static object Deserialize<T>(this HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(content);
            }

            return (JsonSerializer.Deserialize<ErrorDetail>(content) ?? new ErrorDetail()).ErrorCode = response.StatusCode.ToString();
        }

        public static async Task<object> DeserializeAsync<T>(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(content);
            }

            return (JsonSerializer.Deserialize<ErrorDetail>(content) ?? new ErrorDetail()).ErrorCode = response.StatusCode.ToString();
        }
    }
}