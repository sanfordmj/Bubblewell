


using Application.Users.Queries.GetUserById;
using Application.UserTokens.Commands.CreateUserToken;
using Application.UserTokens.Queries.GetUserTokenById;
using Asp.Versioning;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Presentation.Controllers
{
    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [Route("api/v{version:ApiVersion}/[Controller]")]
    [ApiController]
    [AllowAnonymous]
    public sealed class TokenGenController : ApiController
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenGenController>? _logger;
        public TokenGenController(ILogger<TokenGenController>? logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("tokenId:guid")]
        [ProducesResponseType(typeof(GetUserTokenByIdQuery), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetToken(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetUserTokenByIdQuery(Id);
            var tokenResponse = await Sender.Send(query, cancellationToken);
            return Ok(tokenResponse.Token);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateToken([FromBody] CreateUserTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
              
                string? IssuerSigningKey = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:IssuerSigningKey"];
                string? Issuer = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Issuer"];
                string? ValidAudience = _configuration["AuthenticationConfiguration:JwtBearerConfiguration:TokenValidationConfiguration:Audience"];

                if (string.IsNullOrEmpty(IssuerSigningKey))
                    throw new ArgumentNullException("SigningKey is null");

                if (string.IsNullOrEmpty(Issuer))
                    throw new ArgumentNullException("Issuer is null");

                if (string.IsNullOrEmpty(ValidAudience))
                    throw new ArgumentNullException("ValidAudience is null");


                var mySecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(IssuerSigningKey));

                var query = new GetUserByUsernameOrEmailQuery(request.UserName);
                var userResponse = await Sender.Send(query, cancellationToken);
                User user = userResponse.Adapt<User>();

                if (user == null)
                    throw new UnauthorizedAccessException("User is not authorized");

                PasswordHasher<User> hasher = new PasswordHasher<User>();                
                PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.Hash ??= "", request.Password);

                if(result == PasswordVerificationResult.Failed)
                    throw new UnauthorizedAccessException("User is not authorized");

                var claims = new Dictionary<string, object>();
                claims.Add("UserId", user.Id.ToString());

                var tokenHandler = new JwtSecurityTokenHandler();

                DateTime expire = DateTime.UtcNow.AddDays(365);
                var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Claims = claims,
                    Expires = expire,
                    Issuer = Issuer,
                    Audience = ValidAudience,
                    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(mySecurityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                string mytoken = tokenHandler.WriteToken(token);

                CreateUserTokenCommand command = new CreateUserTokenCommand(new Guid(), user.Id, tokenHandler.WriteToken(token), DateTime.UtcNow, expire, false, false, DateTime.UtcNow, false);

                var tokenId = await Sender.Send(command, cancellationToken);

                GetUserTokenByIdQuery getUserTokenByIdQuery = new GetUserTokenByIdQuery(tokenId);
                GetUserTokenByIdQueryResponse getUserTokenByIdQueryResponse = await Sender.Send(getUserTokenByIdQuery, cancellationToken);

                return CreatedAtAction(nameof(GetToken), new { getUserTokenByIdQueryResponse.Id, getUserTokenByIdQueryResponse.Token });

            }
            catch
            {
                throw;
            }
        }
    }
}
