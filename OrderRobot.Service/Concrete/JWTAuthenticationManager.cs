using Microsoft.IdentityModel.Tokens;
using OrderRobot.Service.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace OrderRobot.Service.Concrete
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string key;
        private readonly Dictionary<string, string> users = new Dictionary<string, string>
        {
            {"admin","password"},{"admin2","password2"}
        };

        public JWTAuthenticationManager(string key)
        {
            this.key = key;
        }



        public string Authenticate(string username, string password)
        {
            if (!users.Any(t=>t.Key==username&&t.Value==password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
