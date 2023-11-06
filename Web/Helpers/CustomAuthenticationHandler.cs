using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace Web.Helpers
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

            if(_configuration == null) 
            {
                return AuthenticateResult.Fail("Unauthorized configuration");
            }

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");

            string? authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }


            IAuthenticationManager? authenticationManager = null;

            if (authorizationHeader.StartsWith("JWT", StringComparison.OrdinalIgnoreCase))
            {
                authenticationManager = new JWTAuthenticationManager(authorizationHeader, _configuration);
            }else{
                return AuthenticateResult.Fail("Unauthorized");
            }

            return await authenticationManager.AuthenticateAsync();
        }
    }
}
