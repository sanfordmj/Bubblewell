using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using WebApi.Helpers;

namespace WebApi.CustomHandlers
{
    public sealed class CustomAuthenticationHandler : AuthenticationHandler<TokenAuthenticationOptions>
    {

        private readonly IConfiguration _configuration;
        public CustomAuthenticationHandler(
                IOptionsMonitor<TokenAuthenticationOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock,
                IConfiguration configuration)
                : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            JWTAuthenticationManager authenticationManager = new JWTAuthenticationManager(Request.Headers, _configuration, this.Scheme);
           
            return await authenticationManager.AuthenticateAsync();
        }
    }
}
