namespace SocialAuth.Model
{
    public class SocialUser
    {
        public SocialUser()
        {
            this.IsVerified = false;
        }

        public string SocialUserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }

    }
}