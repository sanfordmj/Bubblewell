

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
            var token = await Sender.Send(query, cancellationToken);
            return Ok(token);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateToken([FromBody] CreateUserTokenRequest request, CancellationToken cancellationToken)
        {
            var mySecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes("asdv234234^&%&^%&^hjsdfb2%%%"));
            var myIssuer = "http://localhost/gardenservice.signit/";
            var myAudience = "http://dockergardenservice.com/";

            Guid Id = Guid.Parse("2f32bba9-2e90-422c-b386-cc16b0e398de");
            var query = new GetUserByIdQuery(Id);
            var userResponse = await Sender.Send(query, cancellationToken);
            User user = userResponse.Adapt<User>();

            PasswordHasher<User> hasher = new PasswordHasher<User>();

            PasswordVerificationResult result =  hasher.VerifyHashedPassword(user, user.Hash, request.Password);

            //var Myhash = hasher.HashPassword(user.Adapt<User>(), request.Password);


            //var userQuery = new GetUserByHashQuery(hash);
            //var user = await Sender.Send(userQuery, cancellationToken);

            var claims = new System.Security.Claims.Claim[]
            {
                new System.Security.Claims.Claim("UserId", user.Id.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(365),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(mySecurityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var command = request.Adapt<CreateUserTokenCommand>();
            var tokenId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetToken), new { tokenId }, token);
        }


        private string HashPassword(string plainPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainPassword!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
