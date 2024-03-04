using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.InventoryControl.Service.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(string email, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("3h9RtE2FpWb5ZKxvDc6S7GyP4NqXaVwL")),
                    SecurityAlgorithms.HmacSha256)
            };
            var chaveToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(chaveToken);
        }
    }
}
