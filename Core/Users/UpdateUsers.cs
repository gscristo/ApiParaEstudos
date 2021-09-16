using Core.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Users
{
    public class UpdateUsers : IUpdateUsers
    {
        IUsersRepository _usersRepository;

        public UpdateUsers(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> Execute(Users.Model.Users users)
        {
            return await _usersRepository.UpdateAsync(users);
        }
    }
}
