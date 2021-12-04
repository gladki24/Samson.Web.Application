using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Samson.Web.Application.Identity.Configuration;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Identity.Services
{
    [Service]
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtConfiguration _jwtConfiguration;

        public AuthenticationService(IJwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration ?? throw new ArgumentNullException(nameof(jwtConfiguration));
        }

        public string GenerateJwtToken(string login, string id, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtConfiguration.Key);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, login),
                new Claim("id", id)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}