using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialAuth.Model;
using System;
using System.Security.Cryptography;

namespace SocialAuth.Core
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private IOptions<AuthSettings> _authSettings;
        public ConfigureJwtBearerOptions(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings;

        }
        public void Configure(string name, JwtBearerOptions options)
        {
            RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(_authSettings.Value.PublicKey), out _);

            options.IncludeErrorDetails = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new RsaSecurityKey(rsa),
                ValidateIssuer = true,
                ValidIssuer = "AuthService",
                ValidateAudience = true,
                ValidAudience = "Projeto API",
                CryptoProviderFactory = new CryptoProviderFactory()
                {
                    CacheSignatureProviders = false
                }
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}