using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    internal class TokenGenController
    {
        private readonly GardenServicesDbContext? _gardenDbContext;
        private readonly ILogger<TokenGenController>? _logger;




        public TokenGenController(ILogger<TokenGenController> logger, )
        {
            this._logger = logger;
            this._gardenDbContext = gardenServicesDbContext;
        }


        [HttpPost]
        public async Task<ActionResult<string>> PostTokenGen(int IX_User)
        {
            var mySecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes("asdv234234^&%&^%&^hjsdfb2%%%"));
            var myIssuer = "http://localhost/gardenservice.signit/";
            var myAudience = "http://dockergardenservice.com/";

            var claims = new System.Security.Claims.Claim[]
            {
                new System.Security.Claims.Claim("IxUser", IX_User.ToString())
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
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
