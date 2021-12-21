using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;

namespace YodleeIntegration.Api.Extensions
{
    public static class HttpResponseMessageActionResult
    {
        public static async Task<IActionResult> GetActionResultAsync<T>(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(content) ? SuccessResult("", response.StatusCode) :
                response.IsSuccessStatusCode
                ? SuccessResult(JsonSerializer.Deserialize<T>(content), response.StatusCode)
                : ErrorResult(JsonSerializer.Deserialize<ErrorDetail>(content) ?? new ErrorDetail(), response.StatusCode);
        }

        private static IActionResult SuccessResult<T>(T input, HttpStatusCode statusCode)
        {
            var result = new ObjectResult(input)
            {
                StatusCode = (int)statusCode
            };
            return result;
        }

        private static IActionResult SuccessResult(string input, HttpStatusCode statusCode)
        {
            var result = new ObjectResult(input)
            {
                StatusCode = (int)statusCode
            };
            return result;
        }

        private static IActionResult ErrorResult(ErrorDetail input, HttpStatusCode statusCode)
        {
            input.StatusCode = (int)statusCode;
            var result = new ObjectResult(input)
            {
                StatusCode = input.StatusCode
            };
            return result;
        }
    }
}