using System.Threading.Tasks;

namespace Core.Interfaces
{
   public interface IUpdateUsers
    {
        Task<bool> Execute(Users.Model.Users users);
    }
}
