using System.ComponentModel.DataAnnotations;

namespace SocialAuth.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string AppSecret { get; set; }

        [Required]
        public string Provider { get; set; }

    }
}