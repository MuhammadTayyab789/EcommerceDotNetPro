using EcommerceDotNetPro.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceDotNetPro.BusinessLogic.JWT
{
    public class TokenService
    {

        private readonly jwtsettings _jwtsettings;
        public TokenService(jwtsettings JWT)
        {
            _jwtsettings = JWT;
        }


        public string GenerateToken(string username)
        {
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            Console.WriteLine("claims " + claims);
            Console.WriteLine("jwtkey "+ _jwtsettings.Key);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Console.WriteLine("creds" + creds);

            var token = new JwtSecurityToken(

                issuer: _jwtsettings.Issuer,
                audience: _jwtsettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtsettings.TokenLifetime),
                signingCredentials: creds
                );
            Console.WriteLine("Token "+ token);
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
