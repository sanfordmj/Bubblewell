using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web.Helpers
{
    /// <summary>
    /// Concrete implementation of AuthenticationManager
    /// </summary>
    public class JWTAuthenticationManager : IAuthenticationManager
    {
        private readonly string? _authorizationHeader;
        private readonly IConfiguration? _configuration;

        public JWTAuthenticationManager()
        {
            _authorizationHeader = "";
            _configuration = null;
        }
        /// <summary>
        /// Overloaded contstructor for paramters;
        /// </summary>
        /// <param name="token"></param>
        /// <param name="configuration"></param>
        public JWTAuthenticationManager(string authorizationHeader, IConfiguration configuration) 
        {
            _authorizationHeader = authorizationHeader;
            _configuration=configuration;
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
            if (string.IsNullOrEmpty(_authorizationHeader)) {
                throw new ArgumentNullException("jwt token required");
            }
            if (_configuration == null)
            {
                throw new ArgumentNullException("configuration settings required");
            }

            string token = _authorizationHeader.Substring("JWT".Length).Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            
            string? myKeyValue = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:IssuerSigningKey"];
            if (myKeyValue == null)
                throw new NullReferenceException("IssuerSigningKey is null");

            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(myKeyValue));

            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            if (securityToken == null)
                throw new NullReferenceException();

            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Issuer"],
                ValidAudience = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Audience"],
                IssuerSigningKey = mySecurityKey
            };

            ClaimsPrincipal principal = null!;
            try
            {
               
                TokenValidationResult result = await tokenHandler.ValidateTokenAsync(token, validationParameters);

                var IxUser = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "IxUser").Value);

                var claims = new List<Claim>
                {
                    new Claim("IxUser", IxUser.ToString())
                };

                principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return AuthenticateResult.Fail("Unauthorized");
            }

            var ticket = new AuthenticationTicket(principal, "Token-Based Authentication");
            return AuthenticateResult.Success(ticket);
        }

    }
}
