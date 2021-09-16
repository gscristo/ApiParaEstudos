namespace SocialAuth.Model
{
    public enum SocialProvider
    {
        UNDEFINED,
        Google,
        Facebook,

    }
    public class SocialSecret
    {
        public string AppSecret { get; set; }
        public string Provider { get; set; }
        public SocialProvider ProviderEnum
        {
            get
            {
                switch (this.Provider.ToUpper())
                {
                    case "GOOGLE":
                        return SocialProvider.Google;

                    case "FACEBOOK":
                        return SocialProvider.Facebook;

                    default:
                        return SocialProvider.UNDEFINED;

                }
            }
        }

    }
}