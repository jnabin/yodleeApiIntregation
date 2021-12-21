using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.User.UpdateUserDetails
{
    public class UpdateUserDetailsCommand
        : IRequest<HttpResponseMessage>
    {
        public UserRequest UserRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public UpdateUserDetailsRequestBody UpdateUserDetailsRequestBody { get; set; }

        public UpdateUserDetailsCommand(
            UserRequest userRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken,
            UpdateUserDetailsRequestBody updateUserDetailsRequestBody
        )
        {
            UserRequest = userRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            UpdateUserDetailsRequestBody = updateUserDetailsRequestBody;
        }
    }
}