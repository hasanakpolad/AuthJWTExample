using AuthJWTExample.DTOes;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJWTExample.Auth
{
    public class TokenProvider
    {
        IConfiguration configuration;
        public TokenProvider(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string CreateToken(LoginDto model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.Iss,configuration.GetValue<string>("JWT:Issuer")),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,DateTime.Now.AddMinutes(20).ToString()),
                //new Claim("UserName",model.),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key")));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration.GetValue<string>("JWT:Issuer"),
                configuration.GetValue<string>("JWT:Audience"),
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}