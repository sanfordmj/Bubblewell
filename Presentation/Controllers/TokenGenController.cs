

using Application.Routes.Queries.GetRouteById;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserByHash;
using Application.Users.Queries.GetUserById;
using Application.UserTokens.Commands.CreateUserToken;
using Application.UserTokens.Queries.GetUserTokenById;
using Asp.Versioning;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        
        private readonly ILogger<TokenGenController>? _logger;

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
                var mySecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authentication"));
                var myIssuer = "http://localhost/gardenservice.signit/";
                var myAudience = "http://dockergardenservice.com/";

                var query = new GetUserByUsernameOrEmailQuery(request.UserName);
                var userResponse = await Sender.Send(query, cancellationToken);
                User user = userResponse.Adapt<User>();

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string outhash = hasher.HashPassword(user, request.Password);

                PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.Hash ??= "", request.Password);

                var claims = new Dictionary<string, object>();
                claims.Add("UserId", user.Id.ToString());

                var tokenHandler = new JwtSecurityTokenHandler();

                DateTime expire = DateTime.UtcNow.AddDays(365);
                var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Claims = claims,
                    Expires = expire,
                    Issuer = myIssuer,
                    Audience = myAudience,
                    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(mySecurityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                string mytoken = tokenHandler.WriteToken(token);

                CreateUserTokenCommand command = new CreateUserTokenCommand(new Guid(), user.Id, tokenHandler.WriteToken(token), DateTime.Now, expire, false, false);

                var tokenId = await Sender.Send(command, cancellationToken);

                GetUserTokenByIdQuery getUserTokenByIdQuery = new GetUserTokenByIdQuery(tokenId);
                GetUserTokenByIdQueryResponse getUserTokenByIdQueryResponse = await Sender.Send(getUserTokenByIdQuery, cancellationToken);

                return CreatedAtAction(nameof(GetToken), new { getUserTokenByIdQueryResponse.Id, getUserTokenByIdQueryResponse.Token });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
