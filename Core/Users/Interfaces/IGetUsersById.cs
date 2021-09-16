using System;
using System.Threading.Tasks;

namespace Core.Users.Interfaces
{
    public interface IGetUsersById
    {
        Task<Users.Model.Users> Execute(Guid usersId);
    }
}
