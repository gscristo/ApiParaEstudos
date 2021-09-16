namespace SocialAuth.Core
{
    using SocialAuth.Model;
    using Google.Apis.Auth;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using System;
    using System.Net.Http;
    using SocialAuth.Interfaces;
    using Microsoft.Extensions.Options;

    public class TokenValidate : ITokenValidate
    {
        SocialSecret _secret;
        AuthSettings _authSettings;
        public TokenValidate(SocialSecret secret, AuthSettings authSettings)
        {
            _secret = secret;
            _authSettings = authSettings;
        }
        public async Task<SocialUser> Validate()
        {
            SocialUser user;

            switch (_secret.ProviderEnum)
            {
                case SocialProvider.Google:
                    user = await this.GoogleValidate(_authSettings.GoogleAppId);
                    break;

                case SocialProvider.Facebook:
                    user = await this.FacebookValidate(_authSettings.FacebookAppId);
                    break;

                default:
                    throw new Exception("Provider not implemented");
            }

            return user;
        }

        private async Task<SocialUser> GoogleValidate(string AppId)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            settings.Audience = new List<string>() { AppId };

            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(_secret.AppSecret, settings);

            return new SocialUser
            {
                Email = payload.Email,
                Name = payload.Name,
                IsVerified = true
            };
        }

        private async Task<SocialUser> FacebookValidate(string AppId)
        {
            var client = new HttpClient();

            var verifyTokenEndPoint = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name", _secret.AppSecret);
            var verifyAppEndpoint = string.Format("https://graph.facebook.com/app?access_token={0}", _secret.AppSecret);

            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic userResponse = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                uri = new Uri(verifyAppEndpoint);
                response = await client.GetAsync(uri);
                content = await response.Content.ReadAsStringAsync();
                dynamic appResponse = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                if (appResponse["id"] != AppId)
                    throw new Exception("Facebook user does not match the AppId and AppSecret");


                return new SocialUser
                {
                    SocialUserId = userResponse["id"],
                    Email = userResponse["email"],
                    Name = userResponse["name"],
                    IsVerified = true
                };
            }

            throw new Exception("Could not connect with identity provider");
        }
    }
}