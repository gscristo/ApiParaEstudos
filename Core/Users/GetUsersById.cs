using Core.Users.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Users
{
    public class GetUsersById : IGetUsersById

    {
        IUsersRepository _usersRepository;

        public GetUsersById(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Users.Model.Users> Execute(Guid usersId)
        {
            return await _usersRepository.GetByIdAsync(usersId);
        }
    }
}
