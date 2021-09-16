using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Api.SocialAuth.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialAuth.Model;

namespace Api.SocialAuth.Core
{

    public class JwtGenerator : IJwtGenerator

    {
        readonly RsaSecurityKey _key;

        public JwtGenerator(IOptions<AuthSettings> settings)
        {
            RSA privateRSA = RSA.Create();
            privateRSA.ImportRSAPrivateKey(Convert.FromBase64String(settings.Value.PrivateKey), out _);
            _key = new RsaSecurityKey(privateRSA);
        }

        public string CreateUserAuthToken(Guid UsersId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "Projeto API",
                Issuer = "AuthService",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, UsersId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}