using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICreateUsers
    {
        Task<Users.Model.Users> Execute(Users.Model.Users users);
    }
}
