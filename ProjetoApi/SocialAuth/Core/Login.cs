
using Api.SocialAuth.Interfaces;
using Core.Users.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Users
{
   public class Login : ILogin
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtGenerator _jwtGenerator;

        public Login(IUsersRepository usersRepository, IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
            _usersRepository = usersRepository;
        }

        public async Task<Model.Users> Execute(Model.Users user)
        {

            var usersDb = await _usersRepository.Login(user.Usuario, user.Senha);

            Model.Users usersToken = usersDb;

            usersToken.Token = _jwtGenerator.CreateUserAuthToken(user.UsersId);

            return usersToken;
            
        }
    }
}
