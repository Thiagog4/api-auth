using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_auth.models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api_auth.services
{
    public class TokenService
    {

        public static string GenerateToken(Usuario usuario, IConfiguration _configuration)
        {
            //inicia Iconfiguration

             var jwtConfig = _configuration.GetSection("JwtSettings");
                    var Secretkey = jwtConfig["JwtApiSecret"];
                    var key = Encoding.ASCII.GetBytes(Secretkey!);

                    var ClaimsList = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, usuario.Id.ToString()),
                            new Claim(ClaimTypes.Sid, usuario.Nome.ToString()),
                            new Claim(ClaimTypes.GroupSid, usuario.Token!.ToString()),
                        };
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(ClaimsList),
                        Issuer = jwtConfig["JwtIssuer"],
                        Audience = jwtConfig["JwtAudience"],
                        IssuedAt = DateTime.Now,
                        NotBefore = DateTime.Now,
                        Expires = DateTime.Now.AddHours(Convert.ToInt32(jwtConfig["JwtDurationHours"])),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                    return tokenString;

        }
    }
}