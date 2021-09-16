using DataAccess.Entities;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUsersRepository : IRepository<Users>
    {
        Task<Users> Login(string Usuario, string Senha);
    }
}
