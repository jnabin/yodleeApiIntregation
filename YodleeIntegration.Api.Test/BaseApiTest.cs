using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Api.Test
{
    public class BaseApiTest
    {
        protected Mock<IMediator> _mockMediatr;
        protected Mock<IBaseControllerService> _baseControllerMock = new Mock<IBaseControllerService>();
        protected Mock<IConfiguration> _configuration;
        protected HttpClient _client;

        public BaseApiTest()
        {
            _mockMediatr = new Mock<IMediator>();
            _configuration = new Mock<IConfiguration>();
            _configuration.Setup(x => x[It.IsAny<string>()]).Returns("SecretKey10125779374235322");
            WebApplicationFactory<Startup> feature = new WebApplicationFactory<Startup>();
            _client = feature.CreateClient();
            _baseControllerMock.Setup(x => x.GetYodleeConfigureSettings()).
               Returns(Task.FromResult((new YodleeConfiguration(), new YodleeAccessToken(), "1")));
        }

        protected Task<HttpResponseMessage> MediatrMockReturns(HttpStatusCode responseMethod,
            HttpMethod requestMethod, HttpContent content = null) {

            return Task.FromResult(new HttpResponseMessage(responseMethod)
            {
                Content = content,
                StatusCode = responseMethod,
                RequestMessage = new HttpRequestMessage
                {
                    Method = requestMethod
                }
            });
        }
    }
}
