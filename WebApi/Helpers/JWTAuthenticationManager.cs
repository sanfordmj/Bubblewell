using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace WebApi.Helpers
{
    /// <summary>
    /// Concrete implementation of AuthenticationManager
    /// </summary>
    public class JWTAuthenticationManager : IAuthenticationManager
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly IHeaderDictionary? _headers;
        private readonly IConfiguration? _configuration;
        private readonly AuthenticationScheme _scheme;
        public JWTAuthenticationManager()
        {
            _headers = null;
            _configuration = null;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        /// <summary>
        /// Overloaded contstructor for paramters;
        /// </summary>
        /// <param name="token"></param>
        /// <param name="configuration"></param>
        public JWTAuthenticationManager(IHeaderDictionary headers, IConfiguration configuration, AuthenticationScheme scheme) 
        {
            _headers = headers;
            _configuration=configuration;
            _scheme = scheme;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        /// <summary>
        /// Authenticate()
        /// </summary>
        /// <returns></returns>
        public AuthenticateResult Authenticate()
        {
            return AuthenticateAsync().Result;
        }

        /// <summary>
        /// AuthenticateAsync()
        /// </summary>
        /// <returns>AuthenticateResult</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            try
            {
                if(_headers == null)
                    throw new HttpRequestException("Required header values not set.");

                string? _authorizationHeader = _headers.Authorization;
                if (string.IsNullOrEmpty(_authorizationHeader))
                    throw new HttpRequestException("Required header values not set.");

                string token = "";
                if (_authorizationHeader.StartsWith("Bearer"))
                    token = _authorizationHeader.Substring("Bearer".Length).Trim();
                else if (_authorizationHeader.StartsWith("JWT"))
                    token = _authorizationHeader.Substring("JWT".Length).Trim();
                else throw new HttpRequestException("Required header values not set.");


                if (_configuration == null)
                    throw new ArgumentNullException("Required configuration settings not set");

                string? IssuerSigningKey = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:IssuerSigningKey"];
                string? Issuer = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Issuer"];
                string? ValidAudience = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Audience"];

                if (string.IsNullOrEmpty(IssuerSigningKey))
                    throw new ArgumentNullException("SigningKey is null");

                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(IssuerSigningKey));

                if (string.IsNullOrEmpty(Issuer))
                    throw new ArgumentNullException("Issuer is null");

                if (string.IsNullOrEmpty(ValidAudience))
                    throw new ArgumentNullException("ValidAudience is null");

                var securityToken = _jwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;
                if (securityToken == null)
                    throw new HttpRequestException("Valid header values not set.");

                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Issuer,
                    ValidAudience = ValidAudience,
                    IssuerSigningKey = mySecurityKey
                };

                ClaimsPrincipal principal = null!;


                TokenValidationResult result = await _jwtSecurityTokenHandler.ValidateTokenAsync(token, validationParameters);

                if (!result.IsValid)
                    throw new HttpRequestException("Valid header values not set.");

                var userId = securityToken.Claims.First(claim => claim.Type == "UserId").Value;

                var claims = new List<Claim>
                    {
                        new Claim("UserId", userId)
                    };
                var identity = new ClaimsIdentity(claims, "JWT");
                principal = new ClaimsPrincipal(identity);
                
                var ticket = new AuthenticationTicket(principal, _scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return AuthenticateResult.Fail("Unauthorized");
            }

        }

    }
}
