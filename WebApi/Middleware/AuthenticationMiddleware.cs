using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Net;

namespace WebApi.Middleware
{
    internal sealed class AuthenticationMiddleware
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task Invoke(HttpContext context)
        {

            var response = context.Response;
            response.ContentType = "application/json";

            try
            {
                IHeaderDictionary headers = context.Request.Headers;

                string? _authorizationHeader = headers.Authorization;
                if(string.IsNullOrEmpty(_authorizationHeader))
                    throw new HttpRequestException("Required header values not set.");

                if (_configuration == null)
                    throw new ArgumentNullException("Required configuration settings not set");

                string? IssuerSigningKey = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:IssuerSigningKey"];
                string? Issuer = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Issuer"];
                string? ValidAudience = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Audience"];

                if (string.IsNullOrEmpty(IssuerSigningKey))
                    throw new ArgumentNullException("SigningKey is null");

                if (string.IsNullOrEmpty(Issuer))
                    throw new ArgumentNullException("Issuer is null");

                if (string.IsNullOrEmpty(ValidAudience))
                    throw new ArgumentNullException("ValidAudience is null");

                string token = _authorizationHeader.Substring(3).Trim();

                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(IssuerSigningKey));

                var securityToken = jwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;
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
               

                    TokenValidationResult result = await jwtSecurityTokenHandler.ValidateTokenAsync(token, validationParameters);

                    if(!result.IsValid)
                        throw new HttpRequestException("Valid header values not set.");

                
                    var userId = securityToken.Claims.First(claim => claim.Type == "UserId").Value;

                    var claims = new List<Claim>
                    {
                        new Claim("UserId", userId)
                    };

                    principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
                    context.User = principal;
                
                //Pass to the next middleware
                await _next(context);
            }
            catch (Exception error) {

                switch (error)
                {
                    case HttpRequestException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;                    
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }



    }
}
