using Bargheto.Application.Common.JWT;
using Bargheto.Domain.Entities.UserManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.JWT
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtTokenSetting _settings;

        public JwtTokenGenerator(IOptions<JwtTokenSetting> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_settings.Secret));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim("email", user.Email.Value)
            };

            JwtSecurityToken token = new
                (
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_settings.ExpirationMinutes),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
