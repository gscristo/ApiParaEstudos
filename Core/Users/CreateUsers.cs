using Core.Infrastructure.Exceptions;
using Core.Interfaces;
using Core.Users.Validators;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CreateUsers : ICreateUsers
    {
        IUsersRepository _usersRepository;
        private readonly UsersValidator _usersValidator;

        public CreateUsers(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _usersValidator = UsersValidator.Validate().CreateUsersValidator();
        }

        public async Task<Users.Model.Users> Execute(Users.Model.Users users)
        {
            var UsersValidated = _usersValidator.Validate(users);

            if (!UsersValidated.IsValid)
            {
                throw new ApiDomainException(UsersValidated.Errors);
            }

            users.UsersId = await _usersRepository.InsertAsync(users);

            return users;

        }
    }
}
