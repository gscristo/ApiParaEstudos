using System.Threading.Tasks;
using SocialAuth.Model;

namespace SocialAuth.Interfaces
{
    public interface ITokenValidate
    {
        Task<SocialUser> Validate();
    }
}