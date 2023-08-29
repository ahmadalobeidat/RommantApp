using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RommanyAPI.Interfaces;

namespace RommanyAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
        }
        public string CreateToken(UserLogin userLogin)
        {
            var claims = new List<Claim>{
                    new Claim(JwtRegisteredClaimNames.NameId , userLogin.UserName),
            };

            var creds = new SigningCredentials(_key , SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                SigningCredentials = creds,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(2),
            };

            var tokenHandler =  new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}